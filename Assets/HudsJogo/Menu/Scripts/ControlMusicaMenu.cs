using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMusicaMenu : MonoBehaviour
{
    [SerializeField] private AudioSource TrilhaSonora;

    public void VolumeTrilha(float value)
    {
        TrilhaSonora.volume = value;
    }
}
