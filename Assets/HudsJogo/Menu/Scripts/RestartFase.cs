using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFase : MonoBehaviour
{

    [SerializeField] private string nameOfGame; //Button tentar novamente
    [SerializeField] private string nameOfGame2; //Button voltar ao menu principal
    [SerializeField] private GameObject TelaRestart; //tela de restart

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
