using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
    public RectTransform backgroundJoystick;
    public RectTransform handleJoystick;
    public float valueX, valueY ; 
    //Vector2 currentPosition;
    Vector3 inputDir; 

    void Start()
    {
        inputDir = Vector3.zero; 

    }

    void Update()
    {
        //Debug.Log("Horizontal value is" + valueX + "Vertical value is" + valueY);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPosition = transform.InverseTransformPoint(eventData.position); 
        RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundJoystick, eventData.position, eventData.pressEventCamera, out currentPosition);

        currentPosition.x = currentPosition.x / backgroundJoystick.sizeDelta.x;
        currentPosition.y = currentPosition.y / backgroundJoystick.sizeDelta.y;

        float x = currentPosition.x * 2;
        float y = currentPosition.y * 2; 

        inputDir = new Vector3(x, y, 0);
        inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

        handleJoystick.anchoredPosition = new Vector3(inputDir.x * (backgroundJoystick.sizeDelta.x / 2.5f),
                inputDir.y * (backgroundJoystick.sizeDelta.y / 2.5f), 0
            ); 

        if(handleJoystick.transform.localPosition.x > 1)
        {
            valueX = 1; 
        }else if(handleJoystick.transform.localPosition.x == 0 )
        {
            valueX = 0; 
        }else
        {
            valueX = -1; 
        }


        if (handleJoystick.transform.localPosition.y > 1)
        {
            valueY = 1;
        }
        else if (handleJoystick.transform.localPosition.y == 0)
        {
            valueY = 0;
        }
        else
        {
            valueY = -1;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localPosition = transform.InverseTransformPoint(eventData.position); 
    }
       
    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        handleJoystick.anchoredPosition = Vector3.zero;
        valueX = 0;
        valueY = 0; 
    }
}
