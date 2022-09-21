using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTrilha : MonoBehaviour
{
    [SerializeField] private AudioSource TrilhaSonora;

    public void VolumeTrilha(float value)
    {
        TrilhaSonora.volume = value;
    }
}
