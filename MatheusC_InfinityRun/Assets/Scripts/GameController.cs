using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float        _coinTempo;
    public GameObject   _coinPrefab;

    //Propriedade da interface
    [Header("Configuracao de UI(interface de usuario)")]
    public int          _pontosPlayer;
    public Text         _txtPontos;
    public int          _vidasPlayer;
    public Text         _txtVidas;
    public Text         _txtMetros;

    //Propriedade de distancia
    [Header("Controle de distancia")]
    public int           _metrosPercorridos = 0;

    //Propriedade de Son
    [Header("Controle de Sons e Efeitos")]
    public AudioSource  _fxGame;
    public AudioClip    _fxMoedaColetada;
    public AudioClip    _fxJump;
    public AudioClip    _fxColisao;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");//Chamada
        StartCoroutine("SpawnCoin");//Chamada
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);//Chamada invocada varias vezes 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstaculo()//Carrega obstaculo E moedas
    {
        yield return new WaitForSeconds(_ObstaculoTempo);

        GameObject ObjetoObstaculoTemp = Instantiate(_obstaculoPrefab);
        StartCoroutine("SpawnObstaculo");

        yield return new WaitForSeconds(1.5f);
        StartCoroutine("SpawnCoin");
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

    public void Pontos(int _qtdPontos) //Pega os pontos e coloca na tela
    {
        _pontosPlayer += _qtdPontos;
        _txtPontos.text = _pontosPlayer.ToString();
    }

    void DistanciaPercorrida()//Reponsavel pela soma da distancia
    {
        _metrosPercorridos++;//Soma mais um
        _txtMetros.text = _metrosPercorridos.ToString() + " M";

        //Compara o resto da divis�o for igual a zero 
        //Para deixar o jogo mais rapido pela distancia percorrida
        if ( (_metrosPercorridos % 100) == 0)
        {
            _chaoVelocidade += 0.5f; //Soma com ela mesma + o numero
            _ObstaculoTempo += 0.15f;
            _obstaculoVelocidade += 0.15f;
        }
    }

}
