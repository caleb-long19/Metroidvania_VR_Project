using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransitions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    // Code would not have been possible without the help of 'VR With Andrew'
    // The link to the tutorial can be found here: https://www.youtube.com/watch?v=3mRI1hu9Y3w&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz
    // Other scripts to supported by VR With Andrew are VRInputModule, and Pointer

    public Color32 defaultColour = Color.yellow;
    public Color32 hoverColour = Color.white;
    public Color32 downColour = Color.grey;

    private Image image = null;

    // This script links with the Pointer script

    private void Awake()
    {
        //Get image component on the button
        image = GetComponent<Image>();
    }

    // Detect if the VR pointer (Raycast) is hovering over the button/image
    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter");
        image.color = hoverColour;
    }

    // Detect if the VR pointer (Raycast) is not hovering over the button/image
    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");
        image.color = defaultColour;
    }

    // Detect if the VR pointer (Raycast) is hovering over the button/image and the trigger has been pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        image.color = downColour;
    }

    // Detect if the VR pointer (Raycast) is hovering over the button/image and the trigger is no longer being pressed
    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");

    }

    // Unused
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        image.color = hoverColour;
    }
}

