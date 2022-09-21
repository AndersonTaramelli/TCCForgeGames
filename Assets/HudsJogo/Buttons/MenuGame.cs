using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{   
    [SerializeField] private string nameOfGame;
    [SerializeField] private GameObject painelMainMenu;
    [SerializeField] private GameObject painelSettings;

    public void Resume()
    {
        painelMainMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        painelMainMenu.SetActive(false);
        painelSettings.SetActive(true);
    }

    public void CloseSettings()
    {
        painelSettings.SetActive(false);
        painelMainMenu.SetActive(true);
    }

    public void Sair()
    {
       SceneManager.LoadScene(nameOfGame);
    }
}
