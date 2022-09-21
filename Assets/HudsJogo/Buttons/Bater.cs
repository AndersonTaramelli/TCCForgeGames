using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bater : MonoBehaviour
{

    [SerializeField] private bool ataque = false;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        ataque = gameObject.GetComponent<AttackButton>();
    }

    void batendo()
    {
        anim.SetBool("Attack", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
