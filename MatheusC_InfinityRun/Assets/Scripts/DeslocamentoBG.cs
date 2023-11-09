using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeslocamentoBG : MonoBehaviour
{
    // Start is called before the first frame update

    private Renderer objetoRender;
    private Material objetoMaterial;
    public float offset; //Desllocamento
    public float offsetIncremento;
    public float offsetVelocidade;

    public string sortingLayer;
    public int orderinlayer;
    void Start()
    {
        objetoRender = GetComponent<MeshRenderer>();

        objetoRender.sortingLayerName = sortingLayer;
        objetoRender.sortingOrder = orderinlayer;

        objetoMaterial = objetoRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += offsetIncremento;
        objetoMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetVelocidade, 0));
    }
}
