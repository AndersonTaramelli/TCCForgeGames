using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMenu : MonoBehaviour
{
    //private bool menuOn = false;
    //private GameObject Options;

    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject MenuJogo;

    public void AbreFechaMenu()
    {
        Options.SetActive(true);
        MenuJogo.SetActive(false);
    }
}
