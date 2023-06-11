/*using Microsoft.VisualBasic.CompilerServices;
using System.Security.AccessControl;*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    // Start is called before the first frame update
    public CardData[] cardDatas;
    private int index=0;
    
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
    void Update()
    {
        if (Input.GetKeyDown("space")){
            //card.setCardData(cardDatas[index]);
            card.setCardData(cardDatas[deck1.Draw()]);
            oponentCard.setCardData(cardDatas[deck2.Draw()]);
            index++;
        }
    }

    void CreateDatas(){
        CreateCardData(7.9F,150F,195F,5000000F,40000,7500F,false,false,"EtaCarinae");
        CreateCardData(0.45F,14F,1180F,1496F,3600,642.5F,false,false,"Betelgeuse");
        CreateCardData(7.96F,17F,1420F,270000F,3490,3840F,false,false,"VYCanisMajoris");
        CreateCardData(-1.46F,2.06F,1.71F,24.74F,9845,8.61F,false,false,"Sirius");
        CreateCardData(0.46F,6.7F,11.4F,3150F,15000,140.2F,false,false,"Achernar");
        CreateCardData(3.73F,0.82F,0.735F,0.34F,5084,10.5F,false,false,"EpsilonEridani");
        CreateCardData(2.01F,1.5F,14.9F,91F,4460,65.88F,false,false,"AlphaArietis");
        CreateCardData(-0.74F,8F,71F,10700F,6998,310F,false,true,"Canopus");
        CreateCardData(1.09F,15.5F,883F,65000F,3500,619.7F,false,false,"Antares");
        CreateCardData(0.03F,2.157F,2.818F,40.12F,8152,20.05F,false,true,"Vega");
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


    CardData CreateCardData(float mag, float mass, float rai, float lum, int temp, float dist, bool trun, bool A, string mat){
        
        Material Mat = Resources.Load<Material>("Materials/"+mat);

        CardData c = new CardData(mag,mass,rai,lum,temp,dist,trun,A,Mat);

        AddCard(c,index);

        return c;
    }



    void AddCard(CardData c,int i){
        cardDatas[i]=c;
        index++;
    }

    public void Exit(){

        SceneManager.LoadScene(0);
    }
}
