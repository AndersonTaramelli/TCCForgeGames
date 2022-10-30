using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPassoMenu : MonoBehaviour
{
    [SerializeField] private AudioSource TrilhaSonora;

    public void VolumeTrilha(float value)
    {
        TrilhaSonora.volume = value;
    }
}
