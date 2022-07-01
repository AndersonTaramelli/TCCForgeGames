using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Life = 100;
    public float Speed;
    public Animator anim;

    public Camera MainCamera;

    public JoystickVirtual joystickVirtual;

    void Awake()
    {
        transform.tag = "Player";
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 direction = new Vector3(joystickVirtual.axis.x, 0, joystickVirtual.axis.y);
        transform.Translate(direction * Time.deltaTime * 8.0f);
        if (joystickVirtual.axis.x != 0 || joystickVirtual.axis.y != 0)
        {
            anim.SetBool("Run", true);
        }
        if (joystickVirtual.axis.x == 0 && joystickVirtual.axis.y == 0)
        {
            anim.SetBool("Run", false);
        }
    }
}
