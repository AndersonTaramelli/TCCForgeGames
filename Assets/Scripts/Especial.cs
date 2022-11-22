using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour
{
    float dano = 30;
    [SerializeField]GameObject sword;

    public float getDano()
    {
        return this.dano;
    }
    public void AtaqueEspadaEspecial()
    {
        sword.GetComponent<BoxCollider>().enabled = true;
    }

    public void NaoAtaqueEspadaEspecial()
    {
        sword.GetComponent<BoxCollider>().enabled = false;
    }
}
