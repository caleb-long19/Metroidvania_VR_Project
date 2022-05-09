using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.InteractionSystem;

public class Pointer : MonoBehaviour
{

    // Code would not have been possible without the help of 'VR With Andrew'
    // The link to the tutorial can be found here: https://www.youtube.com/watch?v=3mRI1hu9Y3w&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz
    // Other scripts to supported by VR With Andrew are VRInputModule, and Button Transitions

    // Length of the raycast
    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;

    public VRInputModule m_InputModule;
    private LineRenderer m_LineRenderer = null;


    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        UpdateLine();
    }


    private void UpdateLine()
    {
        // Use default or set distance for raycast line length
        PointerEventData data = m_InputModule.GetData();

        // If our set distance is not hitting objects at max length, switch to the default length
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;

        // Create Raycast based on the length we previously decided
        RaycastHit hit = CreateRaycast(targetLength);

        // Store end position of the raycast (Default length)
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // Store end position of the raycast based on collision
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        // Set position of the dot to the end of the raycast position
        m_Dot.transform.position = endPosition;

        // Set linerenderer (Visual of the raycast)
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }


    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
