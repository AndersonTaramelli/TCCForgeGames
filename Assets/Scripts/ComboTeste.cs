using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTeste : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0.0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    public Sword sword;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("1"))
        {
            anim.SetBool("1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("2"))
        {
            anim.SetBool("2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("3"))
        {
            anim.SetBool("3", false);
            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            anim.SetBool("1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("1"))
        {
            anim.SetBool("1", false);
            anim.SetBool("2", true);
        }
        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("2"))
        {
            anim.SetBool("2", false);
            anim.SetBool("3", true);
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
