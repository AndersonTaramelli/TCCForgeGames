using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float dano = 10;

    public void Awake()
    {
        GetComponent<BoxCollider>().enabled = false;    
    }
    public float getDano()
    {
        return this.dano;
    }

    //void OnTriggerEnter(Collider sword)
    //{
    //sword
    //}

    // void OnTriggerExit(Collider sword)
    // {
    //     sword.enabled = false;
    //  }
}
