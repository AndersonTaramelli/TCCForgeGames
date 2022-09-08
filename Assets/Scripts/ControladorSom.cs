using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorSom : MonoBehaviour
{

    [SerializeField] private AudioSource fundoMusica;

    public void VolumeMusica(float value)
    {
        fundoMusica.volume = value;
    }
}
