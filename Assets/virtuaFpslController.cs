using UnityEngine;
using UnityEngine.EventSystems; 

public class virtuaFpslController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public fpsController fpsController; 
    public float lookVer, lookHor;
    public Transform Handle;

    void Update()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        lookVer = Input.GetAxisRaw("Mouse Y") * fpsController.Sensitivity;
        lookHor = Input.GetAxisRaw("Mouse X") * fpsController.Sensitivity;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Handle.transform.localPosition = transform.InverseTransformPoint(eventData.pressPosition); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lookVer = 0;
        lookHor = 0;
    }
}
