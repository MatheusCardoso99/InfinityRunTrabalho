using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ObstaculoController : MonoBehaviour
{

    private Rigidbody2D ObstaculoRB;

    private GameController  _GameController;
    private CameraShaker    _CameraShaker;


    // Start is called before the first frame update
    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();
        //ObstaculoRB.velocity = new Vector2 (-5f, 0);

        _GameController = FindObjectOfType(typeof(GameController)) as GameController; 
        _CameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()//Movimentação do obstaculo
    {
        transform.Translate(Vector2.left * _GameController._obstaculoVelocidade * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)//Colisao do obstaculo
    {
        if (collision.tag == "Player")
        {
            _GameController._vidasPlayer--;//Diminui uma vida
            if (_GameController._vidasPlayer <= 0)
            {
                Debug.Log("Fim do jogo");
                _GameController._txtVidas.text = "0";
            }
            else
            {
                _GameController._txtVidas.text = _GameController._vidasPlayer.ToString();
                _GameController._fxGame.PlayOneShot(_GameController._fxColisao);//Tocando o efeito do pulo apenas uma vez
                Debug.Log("Perdeu uma vida");
                _CameraShaker.ShakeIt();//Tromor camera
            }
            
        }

    }


    private void OnBecameInvisible()//Destroi quando sai da tela
    {
        Destroy(this.gameObject);
        Debug.Log("Obstaculo destruido");
    }
}
