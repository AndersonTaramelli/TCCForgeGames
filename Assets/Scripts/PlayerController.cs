using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GeneralSword generalSword;

    [SerializeField] private string nameOfGame;

    public int vidaAtual;

    [SerializeField] private int vidaTotal = 100;

    [SerializeField] private BarraDeVida barraDeVida;

    public float Speed;

    public Animator anim;

    private CharacterController characterController;

    [SerializeField] private AudioSource passosAudioSource;

    [SerializeField] private AudioClip[] passosAudioClip;

    float InputX;

    float InputZ;

    Vector3 Direction;

    public Camera MainCamera;

    [SerializeField] private GameObject MenuGame;

    public Rigidbody rb;

    public float JumpForce;

    public LayerMask layerMask;

    public bool IsGrounded;

    [SerializeField]private float GroundCheckSize;

    [SerializeField] private Vector3 GroundCheckPosition;

    public bool CanAtaque;

    private Enemy enemy;

    private float Cowldown = 30.0f;

    private float CowldownTimer;

    GUIStyle Fonte;

    private float Cowldown1 = 1.0f;

    private float CowldownTimer1;

    private int attackDamage = 20;

    void Awake()
    {
        CanAtaque = true;
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        transform.tag = "Player";
        vidaAtual = vidaTotal;
    }

    void Start()
    {
        Fonte = new GUIStyle();
        Cursor.visible = false;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }
    
    void Update()
    {
        if (CanAtaque == true)
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
                anim.SetBool("Correr", true);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Direction) * camrot, 5 * Time.deltaTime);
            }
            if (InputX == 0 && InputZ == 0)
            {
                anim.SetBool("Correr", false);
            }
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

            if (CowldownTimer1 > 0)
            {
                CowldownTimer1 -= Time.deltaTime;
            }

            if (CowldownTimer1 < 0)
            {
                CowldownTimer1 = 0;
            }

            anim.SetBool("Pulo", !IsGrounded);

            if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && CowldownTimer1 == 0)
            {
                rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
                anim.SetBool("Pulo", true);
                CowldownTimer1 = Cowldown1;
            }

        if (vidaAtual == 0)
        {
            vidaAtual = 0;
            Cursor.visible = true;
            CanAtaque = false;
            StartCoroutine("TimeToDeath");
        }

        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Pause();
            AbreMenu();
        }

        if (CowldownTimer > 0)
        {
            CowldownTimer -= Time.deltaTime;
        }

        if (CowldownTimer < 0)
        {
            CowldownTimer = 0;
        }

        if (Input.GetButtonDown("Fire2") && CowldownTimer == 0)
        {
            Heal();
            CowldownTimer = Cowldown;
        }
    }

    void FixedUpdate()
    {
        

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

    public void FechaMenu()
    {
        MenuGame.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    private void Passos()
    {
        passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }

    IEnumerator TimeToDeath()
    {
        anim.SetBool("Morre", true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(nameOfGame);
    }

    void Heal()
    {
        StartCoroutine("TimeToEspecial");
        anim.SetTrigger("Especial");
    }

    IEnumerator TimeToEspecial()
    {
        CanAtaque = false;
        yield return new WaitForSeconds(2);
        CanAtaque = true;
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(50, 250, 400, 20), "Tempo de recarga do especial: " + CowldownTimer.ToString("00"), Fonte);
        Fonte.fontSize = 32;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Excalibur")
        {
            vidaAtual -= attackDamage;
        }
    }
}