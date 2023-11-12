using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string         nomeDoLevelJogo;
    [SerializeField] private GameObject     painelMenuInicial;
    [SerializeField] private GameObject     painelOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void Opcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
