using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intrutor : MonoBehaviour
{

    [SerializeField] GameObject Fundo1;

    [SerializeField] GameObject Fundo2;

    [SerializeField] GameObject Fundo3;

    [SerializeField] GameObject Fundo4;
    
    [SerializeField] GameObject FalarIntrutor;
    
    [SerializeField] GameObject FalaDoIntrutor1;

    [SerializeField] GameObject FalaDoIntrutor2;

    [SerializeField] GameObject FalaDoIntrutor3;

    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject player;

    private int Num = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1.8f)
        {
            Fundo1.SetActive(true);
            FalarIntrutor.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fundo1.SetActive(false);
                Fundo2.SetActive(true);
                FalarIntrutor.SetActive(false);
                FalaDoIntrutor1.SetActive(true);
                Num++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Num == 2)
                {
                    Fundo1.SetActive(false);
                    Fundo2.SetActive(false);
                    Fundo3.SetActive(true);
                    FalarIntrutor.SetActive(false);
                    FalaDoIntrutor1.SetActive(false);
                    FalaDoIntrutor2.SetActive(true);
                    Num++;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Num == 4)
                {
                    Fundo1.SetActive(false);
                    Fundo2.SetActive(false);
                    Fundo3.SetActive(false);
                    Fundo4.SetActive(true);
                    FalarIntrutor.SetActive(false);
                    FalaDoIntrutor1.SetActive(false);
                    FalaDoIntrutor2.SetActive(false);
                    FalaDoIntrutor3.SetActive(true);
                }
            }
        }
        if (Vector3.Distance(player.transform.position, transform.position) > 1.8f)
        {
            Fundo1.SetActive(false);
            Fundo2.SetActive(false);
            Fundo3.SetActive(false);
            Fundo4.SetActive(false);
            FalaDoIntrutor1.SetActive(false);
            FalaDoIntrutor2.SetActive(false);
            FalaDoIntrutor3.SetActive(false);
            FalarIntrutor.SetActive(false);
            Num = 0;
        }
    }
}
