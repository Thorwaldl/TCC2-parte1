/*using Microsoft.VisualBasic.CompilerServices;
using System.Security.AccessControl;*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{

    public PlayerController player1;
    public GameObject cardObject;
    public GameObject cardOponentObject;
    public Card card;
    public Card oponentCard;

    public GameObject deckObject1;
    public GameObject deckObject2;

    public DeckController deck1;
    public DeckController deck2;

    public TextMeshProUGUI GameStateButton;

    public CardData[] cardDatas;
    private int index=0;
    private int gameState=0;
    
    void Start()
    {
        cardDatas = new CardData[60];

        card = cardObject.GetComponent<Card>();
        oponentCard=cardOponentObject.GetComponent<Card>();

        deck1= deckObject1.GetComponent<DeckController>();
        deck2= deckObject2.GetComponent<DeckController>();

        CreateDatas();
        distributeCards();
        index=0;

        card.setCardData(cardDatas[deck1.Draw()]);
        oponentCard.setCardData(cardDatas[deck2.Draw()]);
        index++;

        //Tests();

        //Card c1 = gameObject.AddComponent(typeof(Card)) as Card;


        //c1.magnetude=c.magnetude;
    
    }

    void distributeCards(){
        deck1.Insert(0);
        deck1.Insert(1);
        deck1.Insert(2);
        deck1.Insert(3);
        deck1.Insert(4);
        deck2.Insert(5);
        deck2.Insert(6);
        deck2.Insert(7);
        deck2.Insert(8);
        deck2.Insert(9);
        //deck2.Insert();
    }

    void Tests(){

    }
    // Update is called once per frame


    void CreateDatas(){
        CreateCardData(0,7.9F,150F,195F,5000000F,40000,7500F,false,false,"EtaCarinae");
        CreateCardData(1,0.45F,14F,1180F,1496F,3600,642.5F,false,false,"Betelgeuse");
        CreateCardData(2,7.96F,17F,1420F,270000F,3490,3840F,false,false,"VYCanisMajoris");
        CreateCardData(3,-1.46F,2.06F,1.71F,24.74F,9845,8.61F,false,false,"Sirius");
        CreateCardData(4,0.46F,6.7F,11.4F,3150F,15000,140.2F,false,false,"Achernar");
        CreateCardData(5,3.73F,0.82F,0.735F,0.34F,5084,10.5F,false,false,"EpsilonEridani");
        CreateCardData(6,2.01F,1.5F,14.9F,91F,4460,65.88F,false,false,"AlphaArietis");
        CreateCardData(7,-0.74F,8F,71F,10700F,6998,310F,false,true,"Canopus");
        CreateCardData(8,1.09F,15.5F,883F,65000F,3500,619.7F,false,false,"Antares");
        CreateCardData(9,0.03F,2.157F,2.818F,40.12F,8152,20.05F,false,true,"Vega");
        /*
        CreateCardData(-0.4F,1.08F,25.4F,170F,4286,36.7F,false,true,"Arcturo","É a estrela mais brilhante da constelação do Boieiro. A quarta estrela mais brilhante no céu noturno. Pertence à classe espectral K do sistema de classificação estelar proposto por Annie Jump Cannon.");
        CreateCardData(0.12F,18F,73F,85000F,115000,772.8F,false,false,"Rigel","É a estrela mais brilhante da constelação de Orion, e a sétima mais brilhante do céu. O nome de Rígel vem da sua posição no "pé esquerdo" de Orion. Rígel também está associado com a Nebulosa de Orion, que está duas vezes mais distante da Terra.");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
        CreateCardData(F,F,F,F,,F,false,false,"");
*/
    }


    CardData CreateCardData(int id, float mag, float mass, float rai, float lum, int temp, float dist, bool trun, bool A, string mat){
        
        Material Mat = Resources.Load<Material>("Materials/"+mat);

        CardData c = new CardData(id,mag,mass,rai,lum,temp,dist,trun,A,Mat);

        AddCard(c,index);

        return c;
    }



    void AddCard(CardData c,int i){
        cardDatas[i]=c;
        index++;
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space")){
            //card.setCardData(cardDatas[index]);
            ComprarCarta();
        }
   
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    card.CardCurrentClickedGameObject(raycastHit.transform.gameObject);
                    oponentCard.CardCurrentClickedGameObject(raycastHit.transform.gameObject);
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
        }
    }
    
    public void ComprarCarta(){
            card.setCardData(cardDatas[deck1.Draw()]);
            oponentCard.setCardData(cardDatas[deck2.Draw()]);
            index++;
    }

    public void CurrentClickedGameObject(GameObject gameObject){

        if(gameObject.tag=="ButtonComparar")
        {
            switch (gameState){
                case 0://comprar carta
                    ComprarCarta();
                    gameState++;
                    GameStateButton.text ="Comparar";
                    break;
                case 1://compara
                    if(Comparador()){
                        GameStateButton.text ="Prosseguir";
                        gameState++;

                    }
                    break;
                case 2://prossegue
                    Prosseguir(10f);
                    gameState=0;
                    GameStateButton.text ="Comprar";

                    break;
                case 3:
                    break;
            }
        }
    }

    public bool Comparador(){
        if(card.selectedVariable){
            if(Comparador_Valores(card.valorSelcionado,oponentCard.valorSelcionado)){
                Debug.Log("player vence");
                deck1.Insert(card.id);
                deck1.Insert(oponentCard.id);
                //ComprarCarta();
            }else{
                if(Comparador_Valores(oponentCard.valorSelcionado,card.valorSelcionado)){
                    Debug.Log("oponente vence");
                    deck2.Insert(card.id);
                    deck2.Insert(oponentCard.id);
                }else{
                    Debug.Log("EMPATE... ainda n tem método para lidar com empate");
                }
                }
            card.desselect();
            card.selectedVariable=false;
            return true;
        }else{
            Debug.Log("Não tem dado selecionado... precisava por um popup");
            return false;
        }

                //ComprarCarta();
    }


    public bool Comparador_Valores(float player, float oponent){
        if(player>oponent){
            return true;
        }
        return false;
    }

    
    public void Prosseguir(float distancia){
        Vector3 currentPosition = cardOponentObject.transform.position;

        // Change the position based on the current position
        Vector3 newPosition = currentPosition + new Vector3(1f, 0f, 0f);

        // Set the new position for the object
        cardOponentObject.transform.position = newPosition;
    }
    


    public void Exit(){

        SceneManager.LoadScene(0);
    }
}
