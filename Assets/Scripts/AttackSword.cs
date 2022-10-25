using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    public Animator Anim;

    public int Numclicks = 0;

    public LayerMask EnemyLayers;

    public int AttackDamage = 0;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            Numclicks++;
            if(Numclicks == 1)
            {
                Anim.SetBool("1", true);
            }
            else
            {
                Anim.SetBool("1", false);
                Numclicks = 0;
                Anim.SetBool("Idle", true);
            }
        }
    }
}
