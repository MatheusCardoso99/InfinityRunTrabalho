using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirChao : MonoBehaviour
{    
    private GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left);
    }
}
