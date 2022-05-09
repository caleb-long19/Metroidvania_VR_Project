using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    // Code would not have been possible without the help of 'VR With Andrew'
    // The link to the tutorial can be found here: https://www.youtube.com/watch?v=3mRI1hu9Y3w&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz
    // Other scripts to supported by VR With Andrew are Pointer, and Button Transitions

    //Get VR Camera, and VR Controller Input
    public Camera camera;
    public SteamVR_Input_Sources VRInputSource;
    public SteamVR_Action_Boolean ButtonPresss;

    private GameObject curObject = null;
    private PointerEventData m_PointerEventData = null;

    protected override void Awake()
    {
        base.Awake();
        m_PointerEventData = new PointerEventData(eventSystem);
    }


    public override void Process()
    {
        // Reset pointer data, and the set camera
        m_PointerEventData.Reset();
        m_PointerEventData.position = new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2);

        // Raycast to retrieve pointer event data 
        eventSystem.RaycastAll(m_PointerEventData, m_RaycastResultCache);
        m_PointerEventData.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);

        // Store game object we are currently looking at
        curObject = m_PointerEventData.pointerCurrentRaycast.gameObject;

        // Clear the cache as data has been stored
        m_RaycastResultCache.Clear();

        // Hover (Used in the Button Transition Script)
        HandlePointerExitAndEnter(m_PointerEventData, curObject);

        // Press (Used in the Button Transition Script)
        if (ButtonPresss.GetStateDown(VRInputSource))
        {
            ProcessPress(m_PointerEventData);
        }

        // Release (Used in the Button Transition Script)
        if (ButtonPresss.GetStateUp(VRInputSource))
        {
            ProcessRelease(m_PointerEventData);
        }
    }


    public PointerEventData GetData()
    {
        return m_PointerEventData;
    }


    private void ProcessPress(PointerEventData data)
    {
        // Set Raycast and store the players raycast hit result when they press a button
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // Check for object hit, get the the down handler, and executre the pointer down event (Pointer Script)
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(curObject, data, ExecuteEvents.pointerDownHandler);

        // If no down handler, try and get click handler
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(curObject);

        // Set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = curObject;
    }


    private void ProcessRelease(PointerEventData data)
    {
        // Execute the release up event on the same game oject we pressed down on (Concludes our button press)
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // When we release the button press, store game object that we are currently releasing on
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(curObject);

        // Check if the game object we released up on is the same gameobject stored in the pointer press 
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // clear selected gameobject
        eventSystem.SetSelectedGameObject(null);

        // Reset event data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}