using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{   
    [SerializeField] private string nameOfGame; //Voltar a Tela inicial
    [SerializeField] private GameObject painelMenu; //Menu do pause
    [SerializeField] private GameObject painelSettings; //Opções do jogo

    public void Resume()
    {
        painelMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        painelMenu.SetActive(false);
        painelSettings.SetActive(true);
    }

    public void CloseSettings()
    {
        painelSettings.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void Sair()
    {
       SceneManager.LoadScene(nameOfGame);
    }
}
