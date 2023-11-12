using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSpawner : MonoBehaviour
{
    private Rigidbody2D inimigoRB;

    private GameController  _GameController;
    private CameraShaker    _CameraShaker;
    private LoserMenu       _LoserMenu;

    // Start is called before the first frame update
    void Start()
    {
        inimigoRB = GetComponent<Rigidbody2D>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        _CameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
        _LoserMenu = FindObjectOfType(typeof(LoserMenu)) as LoserMenu;
    }

    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()//Movimentação do inimigo
    {
        transform.Translate(Vector2.left * _GameController._InimigoVelocidade * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)//Colisao do inimigo
    {
        if (collision.tag == "Player")
        {
            _GameController._vidasPlayer--;//Diminui uma vida

            if (_GameController._vidasPlayer <= 0)
            {
                Debug.Log("Fim do jogo");
                _GameController._txtVidas.text = "0";

                _LoserMenu.Loser();
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
