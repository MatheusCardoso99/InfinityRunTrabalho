using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserMenu : MonoBehaviour
{
    public Transform _loserMenu;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  Loser();

    }

    public void Loser()
    {
        Debug.Log("perdeu");
        _loserMenu.gameObject.SetActive(true);
        Time.timeScale = 0;//Pause o jogo

    }

    public void JogarNovamente()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Jogo");
        Time.timeScale = 1;

    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
