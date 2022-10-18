using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int Life = 100;
    public float Speed;
    public Animator anim;

    private CharacterController characterController;

    private JoystickVirtual joystickVirtual;

    [SerializeField]private AudioSource passosAudioSource;
    [SerializeField]private AudioClip[] passosAudioClip;

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

        anim.SetFloat("joystickVirtual.axis.x", joystickVirtual.axis.x);
        anim.SetFloat("joystickVirtual.axis.y", joystickVirtual.axis.y);

        Vector3 direction = new Vector3(joystickVirtual.axis.x, 0, joystickVirtual.axis.y);
        transform.Translate(direction * Time.deltaTime * 8.0f);
        if (joystickVirtual.axis.x != 0 || joystickVirtual.axis.y != 0)
        {
        
        }
        if (joystickVirtual.axis.x == 0 && joystickVirtual.axis.y == 0)
        {
        
        }

    }

    void Attack()
    {
    }

    private void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }
}
