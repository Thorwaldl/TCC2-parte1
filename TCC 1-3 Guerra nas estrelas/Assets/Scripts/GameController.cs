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

    public GameObject deckObjectPlayer;
    public GameObject deckObjectOponent;

    public DeckController deckPlayer;
    public DeckController deckOponent;

    public TextMeshProUGUI GameStateButton;

    public CardData[] cardDatas;
    public OponenteController oc;
    private int index=0;
    private int gameState=0;

    Vector3 posicaoAtivaPlayer;
    Vector3 posicaoAtivaOponente;
    Vector3 posicaoPopup;

    public GameObject popupGameObject;
    public TextMeshProUGUI popupText;


    void Start()
    {
        cardDatas = new CardData[10];

        card = cardObject.GetComponent<Card>();
        oponentCard=cardOponentObject.GetComponent<Card>();

        //POR MOTIVOS QUE ME FOGEM A COMPREENÇÃO ISSO É TROCADO EM ALGUM OUTRO PONTO, LOGO EU DEIXO ERRADO AQUI PARA QUE DEPOIS DESTROQUE MISTERIOSAMENTE
        deckOponent= deckObjectPlayer.GetComponent<DeckController>();
        deckPlayer= deckObjectOponent.GetComponent<DeckController>();

        CreateDatas();
        distributeCards();
        deckOponent.UpdateTotal();
        deckPlayer.UpdateTotal();
        index=0;

        //oc=new OponenteController();
        oc.Setup(cardDatas);


        //index++;

        posicaoAtivaOponente=cardOponentObject.transform.position;
        posicaoAtivaPlayer=cardObject.transform.position;
        posicaoPopup=popupGameObject.transform.position;
        RemovePopup();

        Mover_Carta(100f);

        //Tests();

        //Card c1 = gameObject.AddComponent(typeof(Card)) as Card;


        //c1.magnetude=c.magnetude;
    
    }

    void distributeCards(){
    deckPlayer.Insert(0);
    deckPlayer.Insert(1);
    deckPlayer.Insert(2);
    deckPlayer.Insert(3);
    deckPlayer.Insert(4);
    deckOponent.Insert(5);
    deckOponent.Insert(6);
    deckOponent.Insert(7);
    deckOponent.Insert(8);
    deckOponent.Insert(9);
    }

    void Tests(){

    }
    // Update is called once per frame


    void CreateDatas(){
        CreateCardData(0,7.9F,150F,195F,5000000F,40000,7500F,false,false,"EtaCarinae","É uma estrela da constelação Quilha ou \"Carina\", distante 7500 anos-luz da Terra. É visível no Hemisfério Sul, mas não no Hemisfério Norte. De tamanho muito grande seu aspecto mais marcante é a variação de seu brilho em várias ordens de magnitude. Foi pela primeira vez catalogada em 1677 por Edmond Halley..");
        CreateCardData(1,0.45F,14F,1180F,1496F,3600,642.5F,false,false,"Betelgeuse","É uma estrela da constelação de Órion. Uma supergigante vermelha é uma das maiores estrelas conhecidas, sendo de grande interesse para a Astronomia. O seu diâmetro angular foi medido pela primeira vez em 1920 -1921 por Michelson e Pease.");
        CreateCardData(2,7.96F,17F,1420F,270000F,3490,3840F,false,false,"VYCanisMajoris","É uma estrela da constelação do Cão Maior uma hipergigante vermelha, uma das maiores estrelas conhecidas. Cercada por uma nebulosa decorrente da massa de gás expelida pela estrela que encobre grande parte do seu brilho, que não pode ser vista no céu noturno a olho nu.");
        CreateCardData(3,-1.46F,2.06F,1.71F,24.74F,9845,8.61F,false,false,"Sirius","É a estrela mais brilhante no céu noturno, localizada na constelação do Cão Maior. Pode ser vista a partir de qualquer ponto na Terra, sendo que, no Hemisfério Norte faz parte do Hexágono do Inverno. Ptolomeu mapeou-a no seu livro Almagesto.");
        CreateCardData(4,0.46F,6.7F,11.4F,3150F,15000,140.2F,false,false,"Achernar","É a estrela de primeira magnitude é a oitava mais brilhante do céu noturno, configurando o extremo sul da longa constelação Erídanus. É também a estrela mais brilhante da constelação Austral de Erídanus (o rio).");
        CreateCardData(5,3.73F,0.82F,0.735F,0.34F,5084,10.5F,false,false,"EpsilonEridani","Epsilon Eridani, também designada como Ran, é a estrela mais próxima da constelação Eridanus, bem como, um dos sistemas estelares mais próximos visível a olho nu. Sua idade é estimada em menos de um bilhão de anos.");
        CreateCardData(6,2.01F,1.5F,14.9F,91F,4460,65.88F,false,false,"AlphaArietis","É a estrela mais brilhante da constelação de Áries. É também conhecida como Hamal. deriva do nome árabe utilizado para designar a constelação, Al Hamal (o cordeiro ou o carneiro). É uma estrela gigante do tipo K2 IIICa, significando que é uma estrela de grandes dimensões e alaranjada.");
        CreateCardData(7,-0.74F,8F,71F,10700F,6998,310F,false,true,"Canopus","É a estrela mais brilhante da constelação de Quilha ou \"Carina\" e a segunda estrela mais brilhante no céu. É uma estrela supergigante branco-amarelada, e no céu de muitos planetas de outros sistemas solares, provavelmente é a mais brilhante.");
        CreateCardData(8,1.09F,15.5F,883F,65000F,3500,619.7F,false,false,"Antares","É uma estrela supergigante vermelha da constelação de escorpião. O nome Antares é derivado de Anti-Ares (Anti-Marte), pois Antares se assemelha em sua cor avermelhada e brilho a Marte, rivalizando com o planeta. É conhecida como uma das quatro estrelas guardiãs do céu dos Persas em 3000 a.C");
        CreateCardData(9,0.03F,2.157F,2.818F,40.12F,8152,20.05F,false,true,"Vega","É a estrela mais brilhante da constelação de Lira e a quinta estrela mais brilhante do céu noturno. Descoberta nos anos 80, Vega tem um anel de poeira e gases à sua volta. Vega forma com as estrelas Altair e Deneb o chamado Triângulo de Verão.");
        
        /*
        CreateCardData(-0.4F,1.08F,25.4F,170F,4286,36.7F,false,true,"Arcturo","É a estrela mais brilhante da constelação do Boieiro. A quarta estrela mais brilhante no céu noturno. Pertence à classe especral do sistema de classificação estelar proposto por Annie Jump Cannon.");
        CreateCardData(0.12F,18F,73F,85000F,115000,772.8F,false,false,"Rigel","É a estrela mais brilhante da constelação de Orion, e a sétima mais brilhante do céu. O nome de Rígel vem da sua posição no \"pé esquerdo\" de Orion. Rígel também está associado com a Nebulosa de Orion, que está duas vezes mais distante da Terra.");
        CreateCardData(0.75F,2F,1.63F,10.6F,7700,16.73F,false,false,"Altair","É a estrela mais brilhante da constelação da Águia. Altair forma com Vega e Deneb o chamado Triângulo de Verão. Na mitologia grega, a constelação da Águia também conhecida por ” Áquila”, da qual Altair é membro, é identificada como a Águia que carregava os raios de Zeus.");
        CreateCardData(1.14F,1.91F,8.8F,43F,4666,33,78 ,false,false,"Pólux","É a estrela mais brilhante da constelação de Gêmeos. Junto com a estrela Castor, é um dos gêmeos representados no contorno da constelação.  Em 2006, foi confirmada a existência de planeta extrassolar orbitando-a. ");
        CreateCardData(1.63F,1.3F,84F,1 500 F,3626,88,71 ,false,false,"Gacrux","É a terceira estrela mais brilhante da constelação de Crux (Cruzeiro do Sul). Gacrux tem um tipo espectral de M3.5 III, o que significa que já passou pela sequência principal e se tornou uma gigante vermelha. Sendo a gigante vermelha mais próxima da Terra.");
        CreateCardData(0.8F,13F,7.1F,20 000 F,27000,322,9 ,false,false,"Acrux","É uma destacada  estrela  branca do hemisfério sul que é a mais brilhante da constelação de Crux, ou      Cruzeiro do Sul, por isso também denominada Alpha Crucis ou Estrela de Magalhães em homenagem ao navegante português Fernão de Magalhães.");
        CreateCardData(1.5F,12.6F,13,9F,20000F,22900,430,5F,false,false,"Epsilon Canis Majoris","É a segunda estrela mais brilhante da constelação do Cão Maior. Na bandeira do Brasil representa o estado do Tocantins. Embora seja a mais brilhante dentre todas as estrelas de segunda grandeza, na bandeira está desenhada como se fosse de terceira.");
        CreateCardData(1.16F,1.92F,1.84F,16.63F,8590,25,13 ,false,false,"Fomalhaut","Alpha Piscis Austrini mais conhecida como Fomalhaut é a estrela mais brilhante da constelação de Peixe Austral, e é uma das  quatro estrelas  reais  dos persas – junto com Antares (α Scorpii), Aldebaran (α Tauri) e Regulus (α Leonis).");
        CreateCardData(1.35F,3.5F,4.15F,150F,15400,77 ,false,false,"Regulus","É a estrela mais brilhante da constelação de Leão. Régulo significa pequeno rei em latim, e, antigamente, era conhecida por Cor Leonis (em latim, o coração do leão), pela posição que ocupa no corpo da figura celestial.");
        CreateCardData(2.71F,5.66F,95F,2538F,4210,460 ,false,false,"Gamma Aquilae","É uma estrela dupla na direção da constelação da Águia. É uma estrela relativamente nova com uma idade de cerca de 100 milhões de anos. No entanto, atingiu um estágio de sua evolução onde consumiu o hidrogênio no seu núcleo e expandiu-se para o que é chamado de estrela gigante brilhante.");
        CreateCardData(3.59F,1.42F,32.9F,330F,4148,230 ,false,false,"Epsilon Crucis","Também conhecida como Intrometida, é a quinta estrela mais brilhante da constelação de Crux. Epsilon Crucis aparece na bandeira de vários países como uma das estrelas do Cruzeiro do Sul. Na bandeira do Brasil representa o estado do Espírito Santo.");
        CreateCardData(2.45F,19.19F,56.3F,105,4 F,15000,1 957 ,false,false,"Aludra","Também conhecida como  Eta Canis Majoris uma estrela na constelação do o Cão Maior, também conhecida por Canis Major. Desde 1943, o espectro desta estrela serviu como um dos pontos âncora estáveis pelo qual outras estrelas são classificadas.");
        CreateCardData(2.09F,15.5F,22.2F,56,88 F,26500,650 ,false,false,"Saiph","É a sexta estrela mais brilhante da constelação de Orion. Das quatro estrelas que compõem o quadrilátero principal de Orion. Saiph é a estrela localizada no canto inferior esquerdo dessa constelação. O nome Saiph vem do árabe saif al jabbar,  espada do gigante.");
        CreateCardData(1.7F,40F,26F,375000F,25000,1 340 ,false,false,"Epsilon Orionis","É também chamado de Alnilam, é a quarta estrela mais brilhante da constelação de Orion.  Juntamente com Delta Orionis (inta) e Zeta Orionis (Anit), Delta Orionis forma o cinturão de Orion, popularmente conhecidas como \"As Três Marias\". É uma supergigante azul-branca.");
        CreateCardData(1.64F,8.4F,6F,6400F,22000,244,6 ,false,false,"Bellatrix","Também conhecida como Gamma Orionis é a terceira estrela mais brilhante da constelação de Orion. O nome Bellatrix vem do latim e significa guerreira. Nas tábuas afonsinas, é também chamada de Estrela Amazona, uma tradução do nome árabe Al Najīd. A estrela forma o ombro direito do caçador Órion.");
        CreateCardData(1.70F,28F,20F,1300F,24000,800 ,false,false,"Zeta Orionis","Conhecida como Anit   é uma estrela tripla na constelação de Orion. Juntamente com Delta Orionis (inta) e Epsilon Orionis (Alnilam), Zeta Orionis forma o cinturão de Orion, conhecido  como \"As Três Marias\". É a estrela mais  à esquerda do cinturão. É  uma  supergigante azul.");
        CreateCardData(1.83F,17F,50000F,6200F,1607,F,false,false,"Delta Canis Majoris","É uma estrela da constelação do Cão Maior. Também é conhecida por Wesen. É uma supergigante do tipo F branco-amarela. Na bandeira do Brasil, como uma estrela de segunda grandeza, representa o estado de Roraima.");
        CreateCardData(2.39F,11.7F,185F,5 000 F,4337, 690 ,false,false,"Epsilon Pegasi","É  a estrela mais brilhante da constelação de Pégaso. É conhecida também pelo nome tradicional Enif, que é derivado da palavra árabe para nariz, devido à sua posição na constelação. Como uma supergigante, Epsilon Pegasi está no fim de sua vida.");
        CreateCardData(2.11F,1.75F,1.72F,15F,8500,35,9 ,false,false,"Denebola","Denebola é a terceira estrela mais brilhante da constelação de Leão. É uma estrela relativamente jovem com uma idade estimada em menos de 400 milhões de anos. O nome Denebola é a versão encurtada de Deneb Alased, \"cauda do leão\", uma vez que representa a cauda do leão na constelação.");
        CreateCardData(3.44F,3F,6F,85F,6792,274,false,false,"Zeta Leonis","É  uma estrela localizada na constelação de Leão. Também é conhecida como Adhafera, é uma estrela gigante com uma classificação estelar de F0 III. Desde 1943, seu espectro tem servido com base pela qual outras estrelas são classificadas.");
        CreateCardData(2.98F,4.01F,21F,288F,5248,247 ,false,false,"Epsilon Leonis","É a quinta estrela mais brilhante da constelação de Leão. Também conhecida como Asad Australis e Algenubi, que  significa \"estrela do sul da cabeça do leão\". a uma idade de 162 milhões de anos, evoluiu para uma gigante luminosa.");
        CreateCardData(4.04F,100F,1260F,155000F,3350,5000 ,false,false,"Mu Cephei","É uma estrela supergigante vermelha localizada na constelação de Cepheus. É uma das maiores e mais luminosas estrelas conhecidas na Via Láctea.  Desde 1943, o espectro desta estrela tem servido como base pela qual outras estrelas são classificadas.");
        CreateCardData(-26.74F,1F,1F,1F,5778,8,0F,true,false,"Trunfo Sol","O Sol (do latim sol, solis) é a estrela central do Sistema Solar. Todos os outros corpos do Sistema Solar, como planetas, planetas anões, asteroides, cometas e poeira, bem como todos os satélites associados a estes corpos, giram ao seu redor.");
        CreateCardData(11.05F,0.12F,0.15F,0,0017 F,2670,4,22 ,false,false,"Próxima Centauri ","Próxima do Centauro, ou simplesmente  Próxima, é uma anã vermelha. É a estrela mais próxima do Sol de que se tem conhecimento e a princípio somente pode ser vista a partir do Hemisfério sul. A estrela possui um exoplaneta chamado Próxima Centauri b, que foi anunciado em 24 de agosto de 2016.");
        CreateCardData(5.11F,100F,1900F,160 000 F,3650, 8 359 ,false,false,"VV CepheiA","É um sistema binário localizado na constelação de Cefeu (Cepheus). O sistema é composto pelas estrelas VV CepheiA (gigante vermelha) e uma companheira de cor azul denominada VV CepheiB. VV Cephei A, a supergigante, é uma das maiores estrelas conhecidas."); 
        CreateCardData(7.7F,0.99F,562F,11,05 F,2500,374,9 ,false,false,"W Hydrae","É uma estrela do tipo Variável Mira na constelação de Hydra. É uma estrela variável pulsante vermelha. Essa estrela não pode ser vista a olho nu, sendo necessário o uso de um telescópio para vê-la.");
        CreateCardData(2F.1.2F,500F,15 000F,2200,420 ,false,false,"Mira","É uma estrela gigante vermelha, dupla e variável da constelação da Baleia (Cetus) visível no hemisfério sul. Uma das mais brilhantes do céu, Mira era conhecida pelos antigos como a Estrela Maravilhosa. Em 1642 Johannes Hevelius, a denominou de Maravilha da Baleia, a primeira variável a ser descoberta.");
        CreateCardData(4.8F,1.2F,370F,6 500 F,2740,178 ,false,false,"R Doradus","Também conhecida como HD 29712 é o nome de uma gigante vermelha do tipo Variável. Mira, no extremo sul da constelação de Dorado (Dor), visualmente mais parece pertencer a constelação da Rede (Reticulum).");
        CreateCardData(3.5F,2.1F,316F,7 250 F,3000,350 ,false,false,"Chi Cygni","É uma estrela variável, do tipo Mira, na constelação de Cisne. Chi Cygni é considerada uma estrela idêntica ao Sol, e como ela está bem próxima de sua morte, pode estar oferecendo um vislumbre do que poderá ocorrer com nosso sistema solar em 4,6 bilhões de anos.");
        CreateCardData(3.1F,17F,460F,90F,2800,550 ,false,false,"Ras Algethi","É uma estrela na constelação de Hércules. Possui tradicionalmente o nome Ras Algethi ou Rasalgethi, e a designação de Flamsteed 64 Herculis. Seu nome vem do árabe Rasalgethi de Rāsal-Jathi \"cabeça do ajoelhado\".");
        CreateCardData(35F,200F,190F,38 000 000F,36000,49 000 ,false,false,"LBV 1806-20","É uma estrela hipergigante ou possivelmente uma estrela binária. Apesar de sua luminosidade ser invisível na Terra, o que vemos é menos da bilionésima parte de sua luz, o resto é absorvido pelo gás e a poeira interestelar");
        CreateCardData(1.97F,7.54F,30F,2 200 F,7200,430 ,false,false,"Polaris","Também conhecida por Estrela do Norte ou Estrela Polar é a estrela mais brilhanteda constelação da Ursa Menor. Com o decorrer dos séculos vem sendo usada para nortear os navegantes. Polaris mudará a sua posição aparente no céu ao longo dos próximos milênios, deixando de ser a estrela do \"pólo norte\".");
        CreateCardData(12.77F,265F,35.4F,8 700 000 F,165 000 anos-luz,F,false,false,"RMC 136a1","É uma estrela Wolf-Rayet (estrela evoluída muito massiva) descoberta em 2010, pertencente ao superaglomerado estelar RCM 136 é a estrela mais massiva conhecida. Localizada na Grande Nuvem de Magalhães Capella Também denominada Alpha Aurigae ou 13 Aurigae, é a estrela mais brilhante da constelação de Auriga e a sexta mais brilhante do céu. Seu nome advém do latim capella quesignifica \"cabra\". Capella é uma gigante amarela com dimensões maiores que o Sol.");
        
        
        
        
        
        
        */
    }


    CardData CreateCardData(int id, float mag, float mass, float rai, float lum, int temp, float dist, bool trun, bool A, string mat, string text){
        
        Material Mat = Resources.Load<Material>("Materials/"+mat);

        CardData c = new CardData(id,mag,mass,rai,lum,temp,dist,trun,A,Mat,text);

        AddCard(c,index);

        return c;
    }



    void AddCard(CardData c,int i){
        cardDatas[i]=c;
        index++;
    }
    
    void Update()
    {
        /*if (Inpu.GeeyDown("space")){
            //card.setCardData(cardDatas[index]);
            ComprarCarta();
        }*/
   
        if (Input.GetMouseButtonDown(0))
        {
            RemovePopup();

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
            card.setCardData(cardDatas[deckPlayer.Draw()]);
            oponentCard.setCardData(cardDatas[deckOponent.Draw()]);

            oponentCard.desselect();
            card.desselect();
            cardObject.transform.position = posicaoAtivaPlayer;


            //index++;
    }

    public void CurrentClickedGameObject(GameObject gameObject){

        if(gameObject.tag=="ButtonComparar")
        {
            switch (gameState){
                case 0://comprar carta
                    ComprarCarta();
                    gameState=1;
                    GameStateButton.text ="Comparar";
                break;
                case 1://compara

                    if(card.selectedVariable){
                        card.selectedVariable=false;
                        if(Comparador()){
                        gameState=2;
                        GameStateButton.text ="Prosseguir";

                        }else{
                            gameState=3;
                            //turnoOponente();
                            GameStateButton.text ="Prosseguir";

                        }
                    }else{
                        Debug.Log("Não tem dado selecionado... precisava por um popup");
                        PullPopup("Por favor selecione um valor para a comparação");
                    }

                    deckOponent.UpdateTotal();
                    deckPlayer.UpdateTotal();

                break;
                case 2://prossegue
                    Prosseguir();
                    gameState=0;
                    GameStateButton.text ="Comprar";

                break;
                case 3:
                    Prosseguir();
                    ComprarCarta();
                    GameStateButton.text ="OPONENTE";
                    gameState=4;
                break;

                case 4:
                    turnoOponente();
                    GameStateButton.text ="Prosseguir";
                   
                    if(card.selectedVariable){
                        card.selectedVariable=false;
                        if(Comparador()){
                        gameState=2;
                        GameStateButton.text ="Prosseguir";

                        }else{
                            gameState=3;
                            //turnoOponente();
                            GameStateButton.text ="Prosseguir";

                        }
                    }else{
                        Debug.Log("Não tem dado selecionado... precisava por um popup");
                        PullPopup("Por favor selecione um valor para a comparação");

                    }

                    deckOponent.UpdateTotal();
                    deckPlayer.UpdateTotal();

                break;

                case 5:

                break;
            }
        }
    }

    void turnoOponente(){
        CardData cd;
        cd=oponentCard.cardData;
        int valorEscolhido=oc.VariableChooser(cd.magnetude ,cd.massa ,cd.raio ,cd.luminosidade ,cd.temperatura ,cd.distancia);
        VariableSetter(valorEscolhido);


    }

    void VariableSetter(int valorEscolhido){
        switch (valorEscolhido)
            {
            case 0:
                card.select(card.magnetudeGameObject);
                oponentCard.select(oponentCard.magnetudeGameObject);

                card.valorSelcionado=card.magnetude;
                oponentCard.valorSelcionado=oponentCard.magnetude;
        break;
            
            case 1:
                card.select(card.massaGameObject);
                oponentCard.select(oponentCard.massaGameObject);

                card.valorSelcionado=card.massa;
                oponentCard.valorSelcionado=oponentCard.massa;
        break;
            
            case 2:
                card.select(card.raioGameObject);
                oponentCard.select(oponentCard.raioGameObject);

                card.valorSelcionado=card.raio;
                oponentCard.valorSelcionado=oponentCard.raio;
        break;
            
            case 3:
                card.select(card.luminosidadeGameObject);
                oponentCard.select(oponentCard.luminosidadeGameObject);

                card.valorSelcionado=card.luminosidade;
                oponentCard.valorSelcionado=oponentCard.luminosidade;
        break;
        
            case 4:
                card.select(card.temperaturaGameObject);
                oponentCard.select(oponentCard.temperaturaGameObject);

                card.valorSelcionado=card.temperatura;
                oponentCard.valorSelcionado=oponentCard.temperatura;
        break;
        
            case 5:
                card.select(card.distanciaGameObject);
                oponentCard.select(oponentCard.distanciaGameObject);

                card.valorSelcionado=card.distancia;
                oponentCard.valorSelcionado=oponentCard.distancia;
        break;
            }
    }

    public bool Comparador(){
        cardOponentObject.transform.position = posicaoAtivaOponente;
        Debug.Log(card.valorSelcionado);
        Debug.Log(oponentCard.valorSelcionado);

        Debug.Log("id do player"+card.id);
        Debug.Log("id do oponente"+oponentCard.id);
        if(Comparador_Valores(card.valorSelcionado,oponentCard.valorSelcionado)){

            card.selectGreen();
            oponentCard.SetBackground(card.vermelho);
            card.SetBackground(card.verde);
            Debug.Log("player vence");

            deckPlayer.Insert(card.id);
            deckPlayer.Insert(oponentCard.id);

            return true;
            //este return deve ser removido para contrir metodo de gerir empates
        }else{
            if(Comparador_Valores(oponentCard.valorSelcionado,card.valorSelcionado)){

                oponentCard.selectGreen();
                oponentCard.SetBackground(card.verde);
                card.SetBackground(card.vermelho);
                Debug.Log("oponente vence");

                deckOponent.Insert(card.id);
                deckOponent.Insert(oponentCard.id);

                return false;
                //este return deve ser removido para contrir metodo de gerir empates
            }else{
                Debug.Log("EMPATE... ainda n tem método para lidar com empate");
            }
        }
        //card.desselect();
        return true;


                //ComprarCarta();
}


    public bool Comparador_Valores(float player, float oponent){
        if(player>oponent){
            return true;
        }
        return false;
    }

    
    public void Prosseguir(){
        Mover_Carta(-100f);

        card.SetBackground(card.preto);
        oponentCard.SetBackground(card.preto);
        oponentCard.desselect();
        card.desselect();

        WinCondition();

    }

    public void WinCondition(){
        if(deckPlayer.Total()==0){
            PullPopup("OPONENTE VENCE A PARTIDA");
            Debug.Log("OPONENTE VENCE A PARTIDA !!!!!!!!!!!!!!!!!!!!!!!");
            GameStateButton.text ="DERROTA";
            gameState=4;
        }
        if(deckOponent.Total()==0){
            PullPopup("JOGADOR VENCE A PARTIDA");
            Debug.Log("JOGADOR VENCE A PARTIDA !!!!!!!!!!!!!!!!!!!!!!!");
            GameStateButton.text ="VITORIA";
            gameState=4;
        }
        
    }

    public void Mover_Carta(float distancia){
        Vector3 currentPosition = cardOponentObject.transform.position;

        // Change the position based on the current position
        Vector3 newPosition = currentPosition + new Vector3(distancia, 0f, 0f);

        // Set the new position for the object
        cardOponentObject.transform.position = newPosition;
        cardObject.transform.position = newPosition;
    }
    
    public void RemovePopup(){
    popupGameObject.transform.position = posicaoPopup+ new Vector3(100f, 0f, 0f);
    }

    public void PullPopup(String texto){
    popupGameObject.transform.position=posicaoPopup;
    popupText.text =texto;
    }

    public void Exit(){

        SceneManager.LoadScene(0);
    }
}
