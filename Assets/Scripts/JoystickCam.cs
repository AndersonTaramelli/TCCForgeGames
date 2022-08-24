using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickCam : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Transform stick;
    public Vector2 axis;
    private Vector2 joystickSize2;

    void Start()
    {
        joystickSize2 = GetComponent<RectTransform>().rect.max;
    }

    private void MoveStick(Vector2 pos)
    {
        stick.position = pos;
        pos.x = Mathf.Clamp(stick.localPosition.x, 0, joystickSize2.x);
        pos.y = Mathf.Clamp(stick.localPosition.y, 0, joystickSize2.y);
        stick.localPosition = pos;

        axis = ((stick.localPosition / joystickSize2) * 2) - Vector2.one;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveStick(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveStick(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        axis = Vector2.zero;
        stick.localPosition = new Vector3(0, 0, 0);
    }
}