using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private string nameOfGame; //cena do jogo

    [SerializeField] private GameObject painelMainMenu; //menu principal
    [SerializeField] private GameObject painelSettings; //opções do jogo no menu principal

    public void start()
    {
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene(nameOfGame);
        Time.timeScale = 1;
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

    public void ExitGame()
    {
        Application.Quit(); //fecha o jogo
    }
}
