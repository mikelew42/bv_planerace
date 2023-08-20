using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ControlMoving : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    Transform Pointer;
    Vector2 initPos;

    public static float pitch = 0f;
    public static float yaw = 0f;
    void Start()
    {
        Pointer = transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
               
         initPos = eventData.position;
        
    }
    public void OnPointerUp(PointerEventData eventData) 
    {
        Pointer.localPosition = Vector3.zero;
        pitch= 0f;
        yaw = 0f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta=eventData.position - initPos;
        float x = delta.x;
        float y=  delta.y;
        if (delta.x * delta.x + delta.y * delta.y > 100 * 100)
        {
            float angle = Vector2.SignedAngle(Vector2.right, eventData.position - (Vector2)transform.position);
            x = 100 * Mathf.Cos(angle * 3.14f / 180f);
            y = 100 * Mathf.Sin(angle * 3.14f / 180f);
        }
        Pointer.localPosition = new Vector3(x, y, 0);
        pitch = x;
        yaw = y;
    }
}
