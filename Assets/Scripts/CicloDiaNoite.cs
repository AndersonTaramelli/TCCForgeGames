using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CicloDiaNoite : MonoBehaviour
{

    [SerializeField] private Transform LuzDirecional;

    [SerializeField] private int DuracaoDia;

    private float segundos;

    private float multiplicador;

    void Start()
    {
        multiplicador = 86400 / DuracaoDia;
    }


    void Update()
    {
        segundos += Time.deltaTime * multiplicador;
        if(segundos >= 86400)
        {
            segundos = 0;
        }

        Ceu();
    }

    private void Ceu()
    {
        float rotacaoX = Mathf.Lerp(-90, 270, segundos / 86400);
        LuzDirecional.rotation = Quaternion.Euler(rotacaoX, 0, 0);
    }
}
