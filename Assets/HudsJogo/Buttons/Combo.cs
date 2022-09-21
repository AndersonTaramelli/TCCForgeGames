using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator anim;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask TestLayers;

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

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Attack"))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                anim.SetBool("Attack", true);
            
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
    }
    public void attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, TestLayers);

        foreach(Collider Test in hitEnemies)
        {
            Test.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}