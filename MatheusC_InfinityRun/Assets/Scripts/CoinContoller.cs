using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinContoller : MonoBehaviour
{
    private GameController  _gameController;
    private Rigidbody2D     _moedasRB2D;
    

    // Start is called before the first frame update
    void Start()
    {   
        _gameController = FindAnyObjectByType(typeof(GameController)) as GameController;

        _moedasRB2D = GetComponent<Rigidbody2D>();
        _moedasRB2D.velocity = new Vector2(-6f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)//Colisão moeda
    {
        if (collision.tag == "Player")
        {
            _gameController.Pontos(1);//pega os pontos para mostrar em tela
            _gameController._fxGame.PlayOneShot(_gameController._fxMoedaColetada);//Tocando o efeito do pulo apenas uma vez
            Debug.Log("Pegou a moeda");
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()//Destroi quando sai da tela
    {
        Destroy(this.gameObject);
        Debug.Log("A moeda foi destruida");
    }
}
