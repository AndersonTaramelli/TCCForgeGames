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

    private float Cowldown = 1.0f;

    private float CowldownTimer;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (CowldownTimer > 0)
        {
            CowldownTimer -= Time.deltaTime;
        }

        if (CowldownTimer < 0)
        {
            CowldownTimer = 0;
        }

        if (Input.GetButtonDown("Fire1") && CowldownTimer == 0)
        {
            Ataque();
            CowldownTimer = Cowldown;
        }
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

    void Ataque()
    {
        Anim.SetTrigger("Ataque");
    }
}
