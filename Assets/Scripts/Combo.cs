using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator anim;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.2f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;

    public int attackDamage = 10;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            lastClickedTime = Time.time;
            if (noOfClicks == 1)
            {
                anim.SetBool("1", true);
            }
            else
            {
                anim.SetBool("1", false);
            }
            noOfClicks++;
            if (noOfClicks > 1)
            {
                anim.SetBool("Idle", true);
                noOfClicks = 0;
            }
        }
    }

    public void attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, EnemyLayers);

        foreach (Collider Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}