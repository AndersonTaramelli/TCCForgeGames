using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Life = 100;
    public float Speed;
    public Animator anim;

    private CharacterController characterController;

    //public FixedTouchField TouchField;

    //protected float CameraAngle;
    //protected float CameraAngleSpeed = 0.2f;

    public JoystickVirtual joystickVirtual;

    //private int joystickVirtual.axis.xHash = Animator.StringToHash("joystickVirtual.axis.x");
    //private int joystickVirtual.axis.yHash = Animator.StringToHash("joystickVirtual.axis.y");

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.tag = "Player";
    }

    void Start()
    {
        
    }

    
    void Update()
    {

        //CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        //Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        //Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

        anim.SetFloat("joystickVirtual.axis.x", joystickVirtual.axis.x);
        anim.SetFloat("joystickVirtual.axis.y", joystickVirtual.axis.y);

        Vector3 direction = new Vector3(joystickVirtual.axis.x, 0, joystickVirtual.axis.y);
        transform.Translate(direction * Time.deltaTime * 8.0f);
        if (joystickVirtual.axis.x != 0 || joystickVirtual.axis.y != 0)
        {
            //anim.SetBool("Run", true);
        }
        if (joystickVirtual.axis.x == 0 && joystickVirtual.axis.y == 0)
        {
            //anim.SetBool("Run", false);
        }
    }

    void Attack()
    {

    }
}
