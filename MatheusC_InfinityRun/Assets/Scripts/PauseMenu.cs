using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public Transform    _pauseMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenu.gameObject.activeSelf)
            {
                _pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;//Executa o jogo
            }
            else
            {
                _pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;//Pause o jogo
            }
        }                
    }

    public void ResumeGame()
    {
        if (_pauseMenu.gameObject.activeSelf)
        {
            _pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;//Executa o jogo
        }
        else
        {
            _pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;//Pause o jogo
        }
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}

