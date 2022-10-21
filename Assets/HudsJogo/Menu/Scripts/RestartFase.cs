using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFase : MonoBehaviour
{

    [SerializeField] private string nameOfGame;
    [SerializeField] private string nameOfGame2;
    [SerializeField] private GameObject TelaRestart;

    public void start()
    {
        Cursor.visible = true;
    }

    public void Tentar()
    {
        SceneManager.LoadScene(nameOfGame);
    }

    public void Sair()
    {
        SceneManager.LoadScene(nameOfGame2);
    }
}
