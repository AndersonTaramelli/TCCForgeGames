using System.Collections;
using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    public float Speed;
    
    public int Life = 0;
    
    private int currentHealth;
    
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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (currentHealth == 0)
        {
            CanAttack = false;
            navMesh.destination = transform.position;
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
            player.GetComponent<PlayerController>().vidaAtual -= 10;
            anim.SetBool("attack", true);
        }
    }

    public void TakeDamage(int attackDamage)
    {
        currentHealth -= attackDamage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (currentHealth == 0)
        {
            CanAttack = false;
            navMesh.destination = transform.position;
        }
        anim.SetBool("Die", true);
    }

        IEnumerator TimeToAttack()
        {
        CanAttack = false;
        yield return new WaitForSeconds(1);
        CanAttack = true;
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dragon_slayer")
        {
            currentHealth -= attackDamage;
        }

        if (currentHealth == 0)
        {
            anim.SetBool("Die", true);
        }
    }
}
