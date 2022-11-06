using System.Collections;
using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    public float Speed;
    
    public int Life = 0;
    
    public int currentHealth;
    
    private GameObject player;
    
    private UnityEngine.AI.NavMeshAgent navMesh;
    
    private bool CanAttack;

    public int attackDamage;

    public Animator anim;

    void Start()
    {
        CanAttack = true;
        player = GameObject.FindWithTag ("Player");
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = Life;
    }
    
    void Update()
    {
        Andar();
        navMesh.destination = player.transform.position;
        if (Vector3.Distance(transform.position,player.transform.position) < 1.5f)
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
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Die();
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
            player.GetComponent<PlayerController>().vidaAtual -= 5;
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
           anim.SetBool("Die", true);
        }
    }

        IEnumerator TimeToAttack()
        {
        CanAttack = false;
        yield return new WaitForSeconds(1);
        CanAttack = true;
        }

        IEnumerator AnimAttack()
        {
        anim.SetBool("attack", false);
        yield return new WaitForSeconds(1);
        anim.SetBool("attack", true);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DragonSlayer")
        {
            currentHealth -= attackDamage;
        }
    }
}
