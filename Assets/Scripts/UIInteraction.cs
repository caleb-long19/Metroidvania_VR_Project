using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class UIInteraction : MonoBehaviour
{
    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    public InputModule m_InputModule;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        float targetLength = m_DefaultLength;

        RaycastHit hit = CreateRaycast(targetLength);

        Vector3 endPos = transform.position + (transform.forward * targetLength);

        if (hit.collider != null)
        {
            endPos = hit.point;
        }

        m_Dot.transform.position = endPos;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPos);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
