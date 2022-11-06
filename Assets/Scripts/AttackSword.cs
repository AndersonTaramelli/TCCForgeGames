using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    public Animator Anim;

    public int Numclicks = 0;

    public LayerMask EnemyLayers;

    public int AttackDamage = 0;

    public PlayerController player;

    public Sword sword;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetTrigger("Ataque");
            //Numclicks++;
            //if(Numclicks == 1)
            //{
              //  Anim.SetBool("1", true);
               // Numclicks = 0;
            //}
            //else
            //{
              //  Anim.SetBool("1", false);
               // Numclicks = 0;
            //}
        }
        //Debug.Log("numeros de cliques" + Numclicks);
    }

    public void Atacando()
    {
        player.CanAtaque = false;
    }

    public void NaoAtaca()
    {
        player.CanAtaque = true;
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
