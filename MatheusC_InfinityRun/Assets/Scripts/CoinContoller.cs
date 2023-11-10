using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinContoller : MonoBehaviour
{

    private Rigidbody2D _moedasRB2D;


    // Start is called before the first frame update
    void Start()
    {

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
