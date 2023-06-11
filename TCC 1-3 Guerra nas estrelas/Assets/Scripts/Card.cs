/*using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;





public class Card : MonoBehaviour
{
    public CardData cardData;
    public GameObject Object;
    public GameObject picture;
    private GameObject seleceted;


    public TextMeshProUGUI magnetudeTxt;
    public TextMeshProUGUI massaTxt;
    public TextMeshProUGUI raioTxt;
    public TextMeshProUGUI luminosidadeTxt;
    public TextMeshProUGUI temperaturaTxt;
    public TextMeshProUGUI distanciaTxt;
    public TextMeshProUGUI textTxt;

    public float magnetude;
    public float massa;
    public float raio;
    public float luminosidade;
    public int temperatura;
    public float distancia;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setCardDataTest(){
        magnetude=cardData.magnetude;
        massa=cardData.massa;
        raio=cardData.raio;
        luminosidade=cardData.luminosidade;
        temperatura=cardData.temperatura;
        distancia=cardData.distancia;
    }

    public void setCardData(CardData cd){
        cardData=cd;
        this.setMaterial(cd.material);
        Debug.Log(cd.magnetude);
        magnetudeTxt.text =cd.magnetude.ToString();
        massaTxt.text =cd.massa.ToString();
        raioTxt.text =cd.raio.ToString();
        luminosidadeTxt.text =cd.luminosidade.ToString();
        temperaturaTxt.text =cd.temperatura.ToString();
        distanciaTxt.text =cd.distancia.ToString();

        setCardDataTest();
    }

    public void setMaterial(Material material){
        picture.GetComponent<MeshRenderer> ().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                   //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
        }
    }
    
 
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if(gameObject.tag=="ButtonMagnetude")
        {
            Debug.Log("magnetude"+magnetude);

        }

        if(gameObject.tag=="ButtonMassa")
        {
            Debug.Log("massa"+massa);

        }

        if(gameObject.tag=="ButtonRaio")
        {
            Debug.Log("raio"+raio);

        }

        if(gameObject.tag=="ButtonLuminosidade")
        {
            Debug.Log("luminosidade"+luminosidade);

        }

        if(gameObject.tag=="ButtonTemperatura")
        {
            Debug.Log("temperatura"+temperatura);

        }

        if(gameObject.tag=="ButtonDistancia")
        {
            Debug.Log("distancia"+distancia);

        }
        
    }

    public void select(GameObject gameObject){
        if(selected!=null){
            gameObject.GetComponent<MeshRenderer>().material = material;
        }
        seleceted=gameObject;
    }

    public void MagnetudeButton(){
            Debug.Log("magnetude"+magnetude);
    }
}   
