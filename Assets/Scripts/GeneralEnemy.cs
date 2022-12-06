using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class GeneralEnemy : MonoBehaviour
{
    public float Speed;

    public int Life = 0;

    public int currentHealth;

    private GameObject player;

    private UnityEngine.AI.NavMeshAgent navMesh;

    private bool CanAttack;

    public int attackDamage;

    public Animator anim;

    [SerializeField] private GameObject BossArturia;

    public GeneralSword sword;

    [SerializeField] private BarraDeVida barraDeVida;

    [SerializeField] private string nameofgame;

    void Awake()
    {
        currentHealth = Life;
    }

    void Start()
    {
        CanAttack = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        barraDeVida.AlterarBarraDeVida(currentHealth, Life);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 10.0f)
        {
            Andar();
            navMesh.destination = player.transform.position;
            if (Vector3.Distance(transform.position, player.transform.position) < 1.8f)
            {
                Attack();
            }
            else
            {
                Andar();
                anim.SetBool("attack", false);
            }
            if (currentHealth <= 0)
            {
                Die();
            }
            if (player.GetComponent<PlayerController>().vidaAtual == 0)
            {
                CanAttack = false;
                anim.SetBool("attack", false);
                anim.SetBool("Corre", false);
            }
        }
        else
        {
            navMesh.destination = transform.position;
            anim.SetBool("Corre", false);
        }
        barraDeVida.AlterarBarraDeVida(currentHealth, Life);
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        if (player.GetComponent<PlayerController>().vidaAtual == 0)
        {
            navMesh.destination = player.transform.position;
            anim.SetBool("attack", false);
        }
    }

    void Andar()
    {
        anim.SetBool("Corre", true);
    }

    void Attack()
    {
        if (CanAttack == true)
        {
            StartCoroutine("TimeToAttack");
            StartCoroutine("AnimAttack");
            anim.SetBool("attack", true);
        }
    }

    public void TakeDamage(int attackDamage)
    {
        currentHealth -= attackDamage;
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            CanAttack = false;
            navMesh.destination = transform.position;
            anim.SetBool("attack", false);
            StartCoroutine("TimeToDeath");
        }
    }

    IEnumerator TimeToAttack()
    {
        CanAttack = false;
        yield return new WaitForSeconds(3);
        CanAttack = true;
    }

    IEnumerator AnimAttack()
    {
        anim.SetBool("attack", false);
        yield return new WaitForSeconds(3);
        anim.SetBool("attack", true);
    }

    [System.Obsolete]
    IEnumerator TimeToDeath()
    {
        anim.SetBool("Die", true);
        yield return new WaitForSeconds(4);
        DestroyObject(BossArturia);
        SceneManager.LoadScene(nameofgame);
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DragonSlayer")
        {
            currentHealth -= attackDamage;
        }
    }

    public void AtaqueEspada()
    {
        sword.GetComponent<BoxCollider>().enabled = true;
    }

    public void NaoAtaqueEspada()
    {
        sword.GetComponent<BoxCollider>().enabled = false;
    }
}
