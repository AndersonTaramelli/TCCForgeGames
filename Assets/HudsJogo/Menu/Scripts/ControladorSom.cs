using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{

    [SerializeField] private AudioSource Andando;

    public void VolumeMusica(float value)
    {
        Andando.volume = value;
    }
}
