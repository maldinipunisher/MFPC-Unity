using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class virtuaFpslController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public fpsController fpsController; 
    public float lookVer, lookHor;
    public RectTransform Handle;
    float time;

    void Start()
    {
        //StartCoroutine(Count()); 

    }
    void Update()
    {
        //Debug.Log(Handle.localPosition); 
        //Debug.Log(time);
    }

    public void OnBeginDrag(PointerEventData eventData)
    { 
        Handle.transform.localPosition = transform.InverseTransformPoint(eventData.pressPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Handle.localPosition += (Vector3)eventData.delta;
        

        if (eventData.dragging)
        {
            lookHor = Input.GetAxisRaw("Mouse X");
            lookVer = Input.GetAxisRaw("Mouse Y");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lookHor = 0;
        lookVer = 0;
    }
}
