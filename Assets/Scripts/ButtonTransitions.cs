using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTransitions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 defaultColour = Color.yellow;
    public Color32 hoverColour = Color.white;
    public Color32 downColour = Color.grey;

    private Image image = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData) 
    { 
        print("Enter");
        image.color = hoverColour;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");
        image.color = defaultColour;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        image.color = downColour;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        image.color = hoverColour;
    }
}
