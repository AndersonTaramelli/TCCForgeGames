using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralSword : MonoBehaviour
{
    float dano = 20;

    public void Awake()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    public float getDano()
    {
        return this.dano;
    }
}
