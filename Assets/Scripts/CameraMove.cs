using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;

    private Vector3 origRot;

    public JoystickVirtual joystickVirtual;

    [SerializeField] private Transform lookAt;

    public float rotSpeed = 0.5f;
    public float dir = -1;

    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    void FixedUpdate()
    {

        foreach (Touch touch in Input.touches)
        {
            //if ()
            //{
               
            //}
            //else
            //{
                if (touch.phase == TouchPhase.Began)
                {
                    initTouch = touch;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    float deltaX = initTouch.position.x - touch.position.x;
                    float deltaY = initTouch.position.y - touch.position.y;
                    rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                    rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                    rotX = Mathf.Clamp(rotX, -45f, 45f);
                    cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    initTouch = new Touch();
                }
            //}
        }
    }
}
