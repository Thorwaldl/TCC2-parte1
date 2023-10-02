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
    //private GameObject selected;

    public bool selectedVariable;

    public TextMeshProUGUI magnetudeTxt;
    public TextMeshProUGUI massaTxt;
    public TextMeshProUGUI raioTxt;
    public TextMeshProUGUI luminosidadeTxt;
    public TextMeshProUGUI temperaturaTxt;
    public TextMeshProUGUI distanciaTxt;
    public TextMeshProUGUI textTxt;

    public int id;
    public float magnetude;
    public float massa;
    public float raio;
    public float luminosidade;
    public int temperatura;
    public float distancia;

    public float valorSelcionado;

    public GameObject magnetudeGameObject;
    public GameObject massaGameObject;
    public GameObject raioGameObject;
    public GameObject luminosidadeGameObject;
    public GameObject temperaturaGameObject;
    public GameObject distanciaGameObject;

    public Material azul;
    public Material vermelho;
    public Material verde;
    public Material preto;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setCardDataTest(){
        id=cardData.identificador;
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
        textTxt.text=cd.text;

        setCardDataTest();
    }

    public void setMaterial(Material material){
        picture.GetComponent<MeshRenderer> ().material = material;
    }

    // Update is called once per frame
    /*
    void Update() {
        if(player){
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100f))
                    {
                        CurrentClickedGameObject(raycastHit.transform.gameObject);
                    }
            }
        }
    }
    */
 
    public void CardCurrentClickedGameObject(GameObject gameObject){

        if(gameObject.tag=="ButtonMagnetude")
        {
            Debug.Log("magnetude"+magnetude);
            if(seleceted==magnetudeGameObject){
                desselect();
            }else{
                select(magnetudeGameObject);
                valorSelcionado=magnetude;
            }            
        }

        if(gameObject.tag=="ButtonMassa")
        {
            Debug.Log("massa"+massa);
            if(seleceted==massaGameObject){
                desselect();
            }else{
                select(massaGameObject);
                valorSelcionado=massa;
            }
        }

        if(gameObject.tag=="ButtonRaio")
        {
            Debug.Log("raio"+raio);
            if(seleceted==raioGameObject){
                desselect();
            }else{
                select(raioGameObject);
                valorSelcionado=raio;
            }
        }

        if(gameObject.tag=="ButtonLuminosidade")
        {
            Debug.Log("luminosidade"+luminosidade);
            if(seleceted==luminosidadeGameObject){
                desselect();
            }else{
                select(luminosidadeGameObject);
                valorSelcionado=luminosidade;
            }
        }

        if(gameObject.tag=="ButtonTemperatura")
        {
            Debug.Log("temperatura"+temperatura);
            if(seleceted==temperaturaGameObject){
                desselect();
            }else{
                select(temperaturaGameObject);
                valorSelcionado=temperatura;
            }
        }

        if(gameObject.tag=="ButtonDistancia")
        {
            Debug.Log("distancia"+distancia);
            if(seleceted==distanciaGameObject){
                desselect();
            }else{
                select(distanciaGameObject);
                valorSelcionado=distancia;
            }
        }
        
    }

    public void select(GameObject gameObject){
        if(seleceted is null){
            gameObject.GetComponent<MeshRenderer>().material = vermelho;
        }else{
            gameObject.GetComponent<MeshRenderer>().material = vermelho;
            seleceted.GetComponent<MeshRenderer>().material = azul;
        }

        selectedVariable=true;
        seleceted=gameObject;

    }

    public void selectGreen(){
        seleceted.GetComponent<MeshRenderer>().material = verde;
    }

    public void desselect(){
        if(!(seleceted is null)){
            seleceted.GetComponent<MeshRenderer>().material = azul;
        }
        seleceted=null;
    }

    public void SetBackground(Material material){
        Renderer renderer = GetComponent<Renderer>(); // Get the object's renderer component
        if (renderer != null)
        {
            renderer.material = material; // Change the material
        }
    }
}   
