using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardData
{

    public int identificador;
    public float magnetude;
    public float massa;
    public float raio;
    public float luminosidade;
    public int temperatura;
    public float distancia;

    public bool trunfo;
    public bool cartaA;

    public string text;
    public string nome;

    public Material material;

        public CardData(int id,float mag, float mass, float rai, float lum, int temp, float dist, bool trun, bool A, Material mat, string tex, string nom){
        identificador=id;
        magnetude=mag;
        massa=mass;
        raio=rai;
        luminosidade=lum;
        temperatura=temp;
        distancia=dist;
        trunfo=trun;
        cartaA=A;
        material=mat;
        text=tex;
        nome=nom;
    }

}
