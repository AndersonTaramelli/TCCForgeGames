using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string nameOfGame;

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

    [SerializeField] private GameObject MenuGame;

    public Rigidbody rb;
    
    public float JumpForce;

    public LayerMask layerMask;
    
    public bool IsGrounded;
    
    public float GroundCheckSize;
    
    public Vector3 GroundCheckPosition;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.tag = "Player";
    }

    void Start()
    {
        vidaAtual = vidaTotal;
        Cursor.visible = false;
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
            SceneManager.LoadScene(nameOfGame);
        }

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Pause();
            AbreMenu();
        }
        
        var groundcheck = Physics.OverlapSphere(transform.position + GroundCheckPosition, GroundCheckSize, layerMask);

        if (groundcheck.Length != 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        anim.SetBool("Jump", !IsGrounded);

        if(IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
            anim.SetBool("Jump", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + GroundCheckPosition, GroundCheckSize); 
    }

    public void AbreMenu()
    {
        MenuGame.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    void Death()
    {
        anim.SetBool("Death", true);
        Cursor.visible = true;
    }

    private void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }
}