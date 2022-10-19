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

    void update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbreMenu();
        }
    }

    public void AbreMenu()
    {
        Options.SetActive(true);
    }
}
