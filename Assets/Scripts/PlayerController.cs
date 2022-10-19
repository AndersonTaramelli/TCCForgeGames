using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int vidaAtual;
    private int vidaTotal = 100;

    [SerializeField] private BarraDeVida barraDeVida;

    public float Speed;
    public Animator anim;

    private CharacterController characterController;

    [SerializeField]private AudioSource passosAudioSource;
    [SerializeField]private AudioClip[] passosAudioClip;

    float InputX;
    float InputZ;
    Vector3 Direction;
    public Camera MainCamera;

    [SerializeField] private GameObject Options;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.tag = "Player";
    }

    void Start()
    {
        vidaAtual = vidaTotal;

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
    
    void Update()
    {

        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        Direction = new Vector3(InputX, 0, InputZ);
        if (InputX != 0 || InputZ != 0)
        {
            var camrot = MainCamera.transform.rotation;
            camrot.x = 0;
            camrot.z = 0;
            transform.Translate(0, 0, Speed * Time.deltaTime);
            anim.SetBool("Run", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direction) * camrot, 5 * Time.deltaTime);
        }
        if (InputX == 0 && InputZ == 0)
        {
            anim.SetBool("Run", false);
        }
        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            Death();
        }

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbreMenu();
        }

    }

    public void AbreMenu()
    {
        Options.SetActive(true);
    }

    void Death()
    {
        anim.SetBool("Death", true);
    }

    private void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }
}