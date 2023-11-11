using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeslocamentoBG : MonoBehaviour
{
    // Start is called before the first frame update

    private Renderer objetoRender;
    private Material objetoMaterial;
    public float offset; 
    public float offsetIncremento;
    public float offsetVelocidade;

    public string sortingLayer;
    public int orderinlayer;
    //Desllocamento
    void Start()
    {
        objetoRender = GetComponent<MeshRenderer>();

        objetoRender.sortingLayerName = sortingLayer;
        objetoRender.sortingOrder = orderinlayer;

        objetoMaterial = objetoRender.material;
    }

    // Update is called once per frame
    void  FixedUpdate()//Deslocamento de imagens de montanha do fundo
    {
        offset += offsetIncremento;
        objetoMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocidade, 0));
    }
}
