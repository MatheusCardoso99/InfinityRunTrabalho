using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //Propriedade do Chao
    [Header("Configuracao do Chao")]
    public float        _chaoDestruido;
    public float        _chaoTamanho;   
    public float        _chaoVelocidade;
    public GameObject   _chaoPrefab;

    //Propriedade do Obstaculo
    [Header("Configuracao do Obstaculo")]
    public float        _ObstaculoTempo;
    public GameObject   _obstaculoPrefab;
    public float        _obstaculoVelocidade;

    //Propriedade da Moeda
    [Header("Configuracao do Coin/Moeda")]
    public float      _coinTempo;
    public GameObject _coinPrefab;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");//Chamada
        StartCoroutine("SpawnCoin");//Chamada
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstaculo()//Carrega obstaculo
    {
        yield return new WaitForSeconds(_ObstaculoTempo);

        GameObject ObjetoObstaculoTemp = Instantiate(_obstaculoPrefab);
        StartCoroutine("SpawnObstaculo");

    }

    IEnumerator SpawnCoin()//Carrega moeda com qtd aleatoria
    {
        int moedasaleatorias = Random.Range(1, 5);
        for (int contagem = 1; contagem <= moedasaleatorias; contagem++)
        {
            yield return new WaitForSeconds(_coinTempo);
            GameObject _objetoSpawn = Instantiate(_coinPrefab);
            _objetoSpawn.transform.position = new Vector3(_objetoSpawn.transform.position.x, _objetoSpawn.transform.position.y, 0);

        }
    }

}
