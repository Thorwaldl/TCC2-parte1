/*using Microsoft.VisualBasic.CompilerServices;
using System.Security.AccessControl;*/
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    public static int totalCartas;

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
    public GameObject JogarGameObject;
    public TextMeshProUGUI popupText;


    void Start()
    {
        cardDatas = new CardData[60];

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
        oc.Setup(cardDatas,totalCartas);


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
        int[] identifiadores = new int[totalCartas];
        //int[] base = new int[totalCartas];
        int rand;
        System.Random random = new System.Random();       

        for (int i=0;i<totalCartas;i++){
            //base[i]=i;
            identifiadores[i]=100;
        }

        for (int i=0;i<totalCartas;i++){

            do{
                rand=random.Next(0,totalCartas);
            }while(!(identifiadores[rand]==100));
            identifiadores[rand]=i;
        }

        foreach (var i in identifiadores) {
            Debug.Log(identifiadores[i]);
        }
        
        for (int i=0;i<totalCartas/2;i++){
            deckPlayer.Insert(identifiadores[i]);
        }
        for (int i=totalCartas/2;i<totalCartas;i++){
            deckOponent.Insert(identifiadores[i]);
        }

    }

    void Tests(){

    }
    // Update is called once per frame


    void CreateDatas(){
        CreateCardData(0,7.9F,150F,195F,5000000F,40000,7500F,false,false,"EtaCarinae","É uma estrela da constelação Quilha ou \"Carina\", distante 7500 anos-luz da Terra. É visível no Hemisfério Sul, mas não no Hemisfério Norte. De tamanho muito grande seu aspecto mais marcante é a variação de seu brilho em várias ordens de magnitude. Foi pela primeira vez catalogada em 1677 por Edmond Halley..");
        CreateCardData(1,0.45F,14F,1180F,1496F,3600,642.5F,false,false,"Betelgeuse","É uma estrela da constelação de Órion. Uma supergigante vermelha é uma das maiores estrelas conhecidas, sendo de grande interesse para a Astronomia. O seu diâmetro angular foi medido pela primeira vez em 1920 -1921 por Michelson e Pease.");
        CreateCardData(2,7.96F,17F,1420F,270000F,3490,3840F,false,false,"VY Canis Majoris","É uma estrela da constelação do Cão Maior uma hipergigante vermelha, uma das maiores estrelas conhecidas. Cercada por uma nebulosa decorrente da massa de gás expelida pela estrela que encobre grande parte do seu brilho, que não pode ser vista no céu noturno a olho nu.");
        CreateCardData(3,-1.46F,2.06F,1.71F,24.74F,9845,8.61F,false,false,"Sirius","É a estrela mais brilhante no céu noturno, localizada na constelação do Cão Maior. Pode ser vista a partir de qualquer ponto na Terra, sendo que, no Hemisfério Norte faz parte do Hexágono do Inverno. Ptolomeu mapeou-a no seu livro Almagesto.");
        CreateCardData(4,0.46F,6.7F,11.4F,3150F,15000,140.2F,false,false,"Achernar","É a estrela de primeira magnitude é a oitava mais brilhante do céu noturno, configurando o extremo sul da longa constelação Erídanus. É também a estrela mais brilhante da constelação Austral de Erídanus (o rio).");
        CreateCardData(5,3.73F,0.82F,0.735F,0.34F,5084,10.5F,false,false,"Epsilon Eridani","Epsilon Eridani, também designada como Ran, é a estrela mais próxima da constelação Eridanus, bem como, um dos sistemas estelares mais próximos visível a olho nu. Sua idade é estimada em menos de um bilhão de anos.");
        CreateCardData(6,2.01F,1.5F,14.9F,91F,4460,65.88F,false,false,"Alpha Arietis","É a estrela mais brilhante da constelação de Áries. É também conhecida como Hamal. deriva do nome árabe utilizado para designar a constelação, Al Hamal (o cordeiro ou o carneiro). É uma estrela gigante do tipo K2 IIICa, significando que é uma estrela de grandes dimensões e alaranjada.");
        CreateCardData(7,-0.74F,8F,71F,10700F,6998,310F,false,true,"Canopus","É a estrela mais brilhante da constelação de Quilha ou \"Carina\" e a segunda estrela mais brilhante no céu. É uma estrela supergigante branco-amarelada, e no céu de muitos planetas de outros sistemas solares, provavelmente é a mais brilhante.");
        CreateCardData(8,1.09F,15.5F,883F,65000F,3500,619.7F,false,false,"Antares","É uma estrela supergigante vermelha da constelação de escorpião. O nome Antares é derivado de Anti-Ares (Anti-Marte), pois Antares se assemelha em sua cor avermelhada e brilho a Marte, rivalizando com o planeta. É conhecida como uma das quatro estrelas guardiãs do céu dos Persas em 3000 a.C");
        CreateCardData(9,0.03F,2.157F,2.818F,40.12F,8152,20.05F,false,true,"Vega","É a estrela mais brilhante da constelação de Lira e a quinta estrela mais brilhante do céu noturno. Descoberta nos anos 80, Vega tem um anel de poeira e gases à sua volta. Vega forma com as estrelas Altair e Deneb o chamado Triângulo de Verão.");
        
        CreateCardData(10,-0.4F,1.08F,25.4F,170F,4286,36.7F,false,true,"Arcturo","É a estrela mais brilhante da constelação do Boieiro. A quarta estrela mais brilhante no céu noturno. Pertence à classe especral do sistema de classificação estelar proposto por Annie Jump Cannon.");
        CreateCardData(11,0.12F,18F,73F,85000F,115000,772.8F,false,false,"Rigel","É a estrela mais brilhante da constelação de Orion, e a sétima mais brilhante do céu. O nome de Rígel vem da sua posição no \"pé esquerdo\" de Orion. Rígel também está associado com a Nebulosa de Orion, que está duas vezes mais distante da Terra.");
        CreateCardData(12,0.75F,2F,1.63F,10.6F,7700,16.73F,false,false,"Altair","É a estrela mais brilhante da constelação da Águia. Altair forma com Vega e Deneb o chamado Triângulo de Verão. Na mitologia grega, a constelação da Águia também conhecida por ” Áquila”, da qual Altair é membro, é identificada como a Águia que carregava os raios de Zeus.");
        CreateCardData(13,1.14F,1.91F,8.8F,43F,4666,33.78F,false,false,"Polux","É a estrela mais brilhante da constelação de Gêmeos. Junto com a estrela Castor, é um dos gêmeos representados no contorno da constelação.  Em 2006, foi confirmada a existência de planeta extrassolar orbitando-a. ");
        CreateCardData(14,1.63F,1.3F,84F,1500F,3626,88.71F,false,false,"Gacrux","É a terceira estrela mais brilhante da constelação de Crux (Cruzeiro do Sul). Gacrux tem um tipo espectral de M3.5 III, o que significa que já passou pela sequência principal e se tornou uma gigante vermelha. Sendo a gigante vermelha mais próxima da Terra.");
        CreateCardData(15,0.8F,13F,7.1F,20000F,27000,322.9F,false,false,"Acrux","É uma destacada  estrela  branca do hemisfério sul que é a mais brilhante da constelação de Crux, ou      Cruzeiro do Sul, por isso também denominada Alpha Crucis ou Estrela de Magalhães em homenagem ao navegante português Fernão de Magalhães.");
        CreateCardData(16,1.5F,12.6F,13.9F,20000F,22900,430.5F,false,false,"Epsilon Canis Majoris","É a segunda estrela mais brilhante da constelação do Cão Maior. Na bandeira do Brasil representa o estado do Tocantins. Embora seja a mais brilhante dentre todas as estrelas de segunda grandeza, na bandeira está desenhada como se fosse de terceira.");
        CreateCardData(17,1.16F,1.92F,1.84F,16.63F,8590,25.13F,false,false,"Fomalhaut","Alpha Piscis Austrini mais conhecida como Fomalhaut é a estrela mais brilhante da constelação de Peixe Austral, e é uma das  quatro estrelas  reais  dos persas – junto com Antares (α Scorpii), Aldebaran (α Tauri) e Regulus (α Leonis).");
        CreateCardData(18,1.35F,3.5F,4.15F,150F,15400,77F,false,false,"Regulus","É a estrela mais brilhante da constelação de Leão. Régulo significa pequeno rei em latim, e, antigamente, era conhecida por Cor Leonis (em latim, o coração do leão), pela posição que ocupa no corpo da figura celestial.");
        CreateCardData(19,2.71F,5.66F,95F,2538F,4210,460F,false,false,"Gamma Aquilae","É uma estrela dupla na direção da constelação da Águia. É uma estrela relativamente nova com uma idade de cerca de 100 milhões de anos. No entanto, atingiu um estágio de sua evolução onde consumiu o hidrogênio no seu núcleo e expandiu-se para o que é chamado de estrela gigante brilhante.");
        CreateCardData(20,3.59F,1.42F,32.9F,330F,4148,230F,false,false,"Epsilon Crucis","Também conhecida como Intrometida, é a quinta estrela mais brilhante da constelação de Crux. Epsilon Crucis aparece na bandeira de vários países como uma das estrelas do Cruzeiro do Sul. Na bandeira do Brasil representa o estado do Espírito Santo.");
        CreateCardData(21,2.45F,19.19F,56.3F,105.4F,15000,1957F,false,false,"Aludra","Também conhecida como  Eta Canis Majoris uma estrela na constelação do o Cão Maior, também conhecida por Canis Major. Desde 1943, o espectro desta estrela serviu como um dos pontos âncora estáveis pelo qual outras estrelas são classificadas.");
        CreateCardData(22,2.09F,15.5F,22.2F,56.88F,26500,650F,false,false,"Saiph","É a sexta estrela mais brilhante da constelação de Orion. Das quatro estrelas que compõem o quadrilátero principal de Orion. Saiph é a estrela localizada no canto inferior esquerdo dessa constelação. O nome Saiph vem do árabe saif al jabbar,  espada do gigante.");
        CreateCardData(23,1.7F,40F,26F,375000F,25000,1340F,false,false,"Epsilon Orionis","É também chamado de Alnilam, é a quarta estrela mais brilhante da constelação de Orion.  Juntamente com Delta Orionis (inta) e Zeta Orionis (Anit), Delta Orionis forma o cinturão de Orion, popularmente conhecidas como \"As Três Marias\". É uma supergigante azul-branca.");
        CreateCardData(24,1.64F,8.4F,6F,6400F,22000,244.6F,false,false,"Bellatrix","Também conhecida como Gamma Orionis é a terceira estrela mais brilhante da constelação de Orion. O nome Bellatrix vem do latim e significa guerreira. Nas tábuas afonsinas, é também chamada de Estrela Amazona, uma tradução do nome árabe Al Najīd. A estrela forma o ombro direito do caçador Órion.");
        CreateCardData(25,1.70F,28F,20F,1300F,24000,800F,false,false,"Zeta Orionis","Conhecida como Anit   é uma estrela tripla na constelação de Orion. Juntamente com Delta Orionis (inta) e Epsilon Orionis (Alnilam), Zeta Orionis forma o cinturão de Orion, conhecido  como \"As Três Marias\". É a estrela mais  à esquerda do cinturão. É  uma  supergigante azul.");
        CreateCardData(26,1.83F,17F,200F,50000F,6200,1607F,false,false,"Delta Canis Majoris","É uma estrela da constelação do Cão Maior. Também é conhecida por Wesen. É uma supergigante do tipo F branco-amarela. Na bandeira do Brasil, como uma estrela de segunda grandeza, representa o estado de Roraima.");
        CreateCardData(27,2.39F,11.7F,185F,5000F,4337,690F,false,false,"Epsilon Pegasi","É  a estrela mais brilhante da constelação de Pégaso. É conhecida também pelo nome tradicional Enif, que é derivado da palavra árabe para nariz, devido à sua posição na constelação. Como uma supergigante, Epsilon Pegasi está no fim de sua vida.");
        CreateCardData(28,2.11F,1.75F,1.72F,15F,8500,35.9F,false,false,"Denebola","Denebola é a terceira estrela mais brilhante da constelação de Leão. É uma estrela relativamente jovem com uma idade estimada em menos de 400 milhões de anos. O nome Denebola é a versão encurtada de Deneb Alased, \"cauda do leão\", uma vez que representa a cauda do leão na constelação.");
        CreateCardData(29,3.44F,3F,6F,85F,6792,274F,false,false,"Zeta Leonis","É  uma estrela localizada na constelação de Leão. Também é conhecida como Adhafera, é uma estrela gigante com uma classificação estelar de F0 III. Desde 1943, seu espectro tem servido com base pela qual outras estrelas são classificadas.");
        CreateCardData(30,2.98F,4.01F,21F,288F,5248,247F,false,false,"Epsilon Leonis","É a quinta estrela mais brilhante da constelação de Leão. Também conhecida como Asad Australis e Algenubi, que  significa \"estrela do sul da cabeça do leão\". a uma idade de 162 milhões de anos, evoluiu para uma gigante luminosa.");
        CreateCardData(31,4.04F,100F,1260F,155000F,3350,5000F,false,false,"Mu Cephei","É uma estrela supergigante vermelha localizada na constelação de Cepheus. É uma das maiores e mais luminosas estrelas conhecidas na Via Láctea.  Desde 1943, o espectro desta estrela tem servido como base pela qual outras estrelas são classificadas.");
        CreateCardData(32,-26.74F,1F,1F,1F,5778,0F,true,false,"Sol","O Sol (do latim sol, solis) é a estrela central do Sistema Solar. Todos os outros corpos do Sistema Solar, como planetas, planetas anões, asteroides, cometas e poeira, bem como todos os satélites associados a estes corpos, giram ao seu redor.");
        CreateCardData(33,11.05F,0.12F,0.15F,0.0017F,2670,4.22F,false,false,"Próxima Centauri","Próxima do Centauro, ou simplesmente  Próxima, é uma anã vermelha. É a estrela mais próxima do Sol de que se tem conhecimento e a princípio somente pode ser vista a partir do Hemisfério sul. A estrela possui um exoplaneta chamado Próxima Centauri b, que foi anunciado em 24 de agosto de 2016.");
        CreateCardData(34,5.11F,100F,1900F,160000F,3650,8359F,false,false,"VV CepheiA","É um sistema binário localizado na constelação de Cefeu (Cepheus). O sistema é composto pelas estrelas VV CepheiA (gigante vermelha) e uma companheira de cor azul denominada VV CepheiB. VV Cephei A, a supergigante, é uma das maiores estrelas conhecidas."); 
        CreateCardData(35,7.7F,0.99F,562F,11.05F,2500,374.9F,false,false,"W Hydrae","É uma estrela do tipo Variável Mira na constelação de Hydra. É uma estrela variável pulsante vermelha. Essa estrela não pode ser vista a olho nu, sendo necessário o uso de um telescópio para vê-la.");
        CreateCardData(36,2F,1.2F,500F,15000F,2200,420F,false,false,"Mira","É uma estrela gigante vermelha, dupla e variável da constelação da Baleia (Cetus) visível no hemisfério sul. Uma das mais brilhantes do céu, Mira era conhecida pelos antigos como a Estrela Maravilhosa. Em 1642 Johannes Hevelius, a denominou de Maravilha da Baleia, a primeira variável a ser descoberta.");
        CreateCardData(37,4.8F,1.2F,370F,6500F,2740,178F,false,false,"R Doradus","Também conhecida como HD 29712 é o nome de uma gigante vermelha do tipo Variável. Mira, no extremo sul da constelação de Dorado (Dor), visualmente mais parece pertencer a constelação da Rede (Reticulum).");
        CreateCardData(38,3.5F,2.1F,316F,7250F,3000,350F,false,false,"Chi Cygni","É uma estrela variável, do tipo Mira, na constelação de Cisne. Chi Cygni é considerada uma estrela idêntica ao Sol, e como ela está bem próxima de sua morte, pode estar oferecendo um vislumbre do que poderá ocorrer com nosso sistema solar em 4,6 bilhões de anos.");
        CreateCardData(39,3.1F,17F,460F,90F,2800,550F,false,false,"Ras Algethi","É uma estrela na constelação de Hércules. Possui tradicionalmente o nome Ras Algethi ou Rasalgethi, e a designação de Flamsteed 64 Herculis. Seu nome vem do árabe Rasalgethi de Rāsal-Jathi \"cabeça do ajoelhado\".");
        CreateCardData(40,35F,200F,190F,38000000F,36000,49000F,false,false,"LBV 1806-20","É uma estrela hipergigante ou possivelmente uma estrela binária. Apesar de sua luminosidade ser invisível na Terra, o que vemos é menos da bilionésima parte de sua luz, o resto é absorvido pelo gás e a poeira interestelar");
        CreateCardData(41,1.97F,7.54F,30F,2200F,7200,430F,false,false,"Polaris","Também conhecida por Estrela do Norte ou Estrela Polar é a estrela mais brilhanteda constelação da Ursa Menor. Com o decorrer dos séculos vem sendo usada para nortear os navegantes. Polaris mudará a sua posição aparente no céu ao longo dos próximos milênios, deixando de ser a estrela do \"pólo norte\".");
        CreateCardData(42,12.77F,265F,35.4F,8700000F,53000,165000F,false,false,"RMC 136a1","É uma estrela Wolf-Rayet (estrela evoluída muito massiva) descoberta em 2010, pertencente ao superaglomerado estelar RCM 136 é a estrela mais massiva conhecida. Localizada na Grande Nuvem de Magalhães Capella Também denominada Alpha Aurigae ou 13 Aurigae, é a estrela mais brilhante da constelação de Auriga e a sexta mais brilhante do céu. Seu nome advém do latim capella quesignifica \"cabra\". Capella é uma gigante amarela com dimensões maiores que o Sol.");
        CreateCardData(43,0.08F,2.57F,11.98F,787F,4970,42.91F,false,false,"Capella","Também denominada Alpha Aurigae ou 13 Aurigae, é a estrela mais brilhante da constelação de Auriga e a sexta mais brilhante do céu. Seu nome advém do latim capella que significa \"cabra\". Capella é uma gigante amarela com dimensões maiores que o Sol.");
        CreateCardData(44,11.8F,115F,306F,1600000F,11800,26090F,false,false,"Estrela da Pistola","É uma hipergigante azul e uma das estrelas mais massivas conhecidas. Tem esse nome por estar na Nebulosa da Pistola, a qual é iluminada por ela. A estrela produz em seis segundos tanta energia quanto o Sol produz em um ano. Queimando nesta taxa dramática, a Estrela da Pistola está destinada a ter vida curta e morte abrupta.");
        CreateCardData(45,2.23F,20F,15.8F,90000F,33000,900F,false,false,"Delta Orionis","Também conhecido como Mintaka, é um sistema estelar múltiplo na constelação de Orion. Juntamente com Epsilon Orionis (Alnilam) e Zeta Orionis (Alnitak). Delta Orionis forma o cinturão de Orion, conhecido como \"As Três Marias\".");
        CreateCardData(46,1.25F,16F,8.4F,34000F,27000,280F,false,false,"Becrux","Também conhecida como Becrux ou Mimosa. É a segunda estrela mais brilhante da constelação de Crux popularmente conhecida como Cruzeiro do Sul. Mimosa é representada nas bandeiras da Austrália, Nova Zelândia e Papua-Nova Guiné. Na bandeira do Brasil, ela representa o estado do Rio de Janeiro.");
        CreateCardData(47,3.67F,10F,9F,10800F,21800,1050,false,false,"Pi4 Orionis","Também conhecida por π4 Ori, é uma estrela na direção da constelação de Orion. Sendo visível a olho nu. Pertence à classe espectral B2III SB. Possui cerca de tem 15,4 milhões de anos.");
        CreateCardData(48,2.77F,15F,11F,12600F,31500,1300F,false,false,"Hatysa","É uma estrela da constelação de Orion, a oitava mais brilhante da constelação e a mais brilhante das que formam a espada de Orion. A estrela também é conhecida pelo nome árabe Na'ir al Saif, que significa precisamente, em tradução livre: \"A brilhante da espada\".");
        CreateCardData(49,8.35F,1.1F,1F,1.1F,5793,170F,false,false,"HD 9446","É uma estrela de classe G da sequência principal a cerca de 170 anos-luz da Terra na constelação de Triangulum. É parecida com o Sol, tanto em tamanho quanto em luminosidade. Em 5 de janeiro de 2010 foi anunciada a descoberta de dois planetas orbitando HD 9446");
        CreateCardData(50,6.73F,1.21F,1.91F,4.6F,6297,173.8F,false,false,"HD 5388","É uma estrela de tipo F da sequência principal localizada na constelação de Fênix (Phoenix). Essa estrela é maior, mais quente, mais brilhante, e mais massiva que o Sol. Em 2009, um planeta gasoso foi achado em volta dela. Este corpo celeste demonstrou posteriormente ser uma anã marrom em vez de um planeta.");
        CreateCardData(51,8.58F,1.13F,1.77F,1.2F,5689,320F,false,false,"HD 23127","É uma estrela na constelação da Rede (Reticulum). Em 2007, foi achado pelo método da velocidade radial um planeta extrassolar orbitando HD 23127. Este planeta é um gigante gasoso com uma massa mínima de 1,5 vezes a massa de Júpiter.");
        CreateCardData(52,7.11F,1.03F,1.07F,1.37F,6039,108.2F,false,false,"HD 23079","É uma estrela na constelação da Rede (Reticulum). Não é visível a olho nu, mas é facilmente visível com um telescópio pequeno. HD 23079 tem um baixo nível de atividade cromosférica e sua idade é estimada em 4,1 bilhões de anos, similar à idade do Sol.");
        CreateCardData(53,7.79F,1.09F,1.18F,1.89F,6160,179F,false,false,"HD 25171","É uma estrela na constelação da Rede (Reticulum). É muito fraca para ser vista a olho nu, mas pode ser vista facilmente com um telescópio pequeno. Tem um planeta em órbita, descoberto em 2010. Estima-se que tenha uma idade parecida à do Sol; cerca de quatro bilhões de anos.");
        CreateCardData(54,9.36F,0.83F,0.79F,0.33F,4923,143F,false,false,"HD 27894","É uma estrela anã laranja na constelação da Rede (Reticulum). É uma estrela menos brilhante e mais fria que o Sol. Em 2005 foi anunciada a descoberta de um planeta extrassolar orbitando HD 27894. Esse planeta é um gigante gasoso com uma massa mínima de 0,62 vezes a massa de Júpiter.");
        CreateCardData(55,12.01F,0.35F,0.38F,0.016F,3424,40.4F,false,false,"Gliese 179","É uma estrela na constelação de Orion. Desde 2009, sabe-se que há um planeta extrassolar orbitando-a. Gliese 179 é uma anã vermelha de baixa luminosidade, sendo fraca demais para ser visível a olho nu.");
        CreateCardData(56,8.96F,0.86F,0.95F,0.734F,5525,180,false,false,"HD 290327","É uma estrela subgigante de 9º magnitude tipo G, localizado na constelação de Orion. Em 2009, um planeta gigante gasoso foi encontrado em órbita ao redor dessa estrela.");
        CreateCardData(57,5.67F,1.12F,1.13F,1.5F,6018,59.7F,false,false,"Pi Mensae","É uma estrela na constelação de Mensa (Men). Sendo visível a olho nu em locais com pouca poluição luminosa. Muito semelhante ao Sol porém um pouco maior e mais brilhante. Em 2002 foi publicada a descoberta de um massivo planeta extrassolar orbitando Pi Mensae.");
        CreateCardData(58,3.86F,1.75F,1.8F,8.7F,8052,63.4F,false,false,"Beta Pictoris","É a segunda estrela mais brilhante da constelação de Pintor (Pictor). Beta Pictoris é o membro principal de uma associação estelar de estrelas jovens que compartilham movimento pelo espaço e têm origem comum, chamado de grupo Beta Pictoris.");
        CreateCardData(59,1.25F,19F,203F,196000F,8525,2613F,false,false,"Deneb","É a estrela mais brilhante da constelação do Cisne. Deneb forma com Veja e Altair o chamado Triângulo de Verão. O nome da estrela provém do termo arábico medieval Al Dhanab al Dajajah, que significa a \"cauda da galinha\". Convém lembrar que os árabes davam o nome galinha à constelação de Cisne.");

    }


    CardData CreateCardData(int id, float mag, float mass, float rai, float lum, int temp, float dist, bool trun, bool A, string mat, string text){
        
        Material Mat = Resources.Load<Material>("Materials/"+mat);

        CardData c = new CardData(id,mag,mass,rai,lum,temp,dist,trun,A,Mat,text,mat);

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
   
        if (Input.GetMouseButtonDown(0))
        {
            RemovePopup();
            Debug.Log("click");

            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    if(gameState==1){
                    card.CardCurrentClickedGameObject(raycastHit.transform.gameObject);
                    oponentCard.CardCurrentClickedGameObject(raycastHit.transform.gameObject);
                    }
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
        if(gameObject.tag=="ButtonJogar"){
            SceneManager.LoadScene(1);

        }
        
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

                    card.selectedVariable=false;

                    deckOponent.UpdateTotal();
                    deckPlayer.UpdateTotal();

                break;
                case 2://prossegue
                    gameState=0;
                    GameStateButton.text ="Comprar";
                    Prosseguir();
                break;
                case 3:
                    GameStateButton.text ="OPONENTE";
                    gameState=4;
                    Prosseguir();
                    //ComprarCarta();
                break;

                case 4:

                    ComprarCarta();

                    turnoOponente();

                    GameStateButton.text ="Prosseguir";
                   
                    if(card.selectedVariable){
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

                    }

                    card.selectedVariable=false;

                    deckOponent.UpdateTotal();
                    deckPlayer.UpdateTotal();

                break;

                case 5:
                    Exit();
                break;
            }
        }
        
    }

    void turnoOponente(){
        CardData cd;
        cd=oponentCard.cardData;
        int valorEscolhido=oc.VariableChooser(cd.magnetude ,cd.massa ,cd.raio ,cd.luminosidade ,cd.temperatura ,cd.distancia);
        //Debug.Log("valor escolhido"+valorEscolhido);
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
    //Debug.Log("valor selecionado"+oponentCard.valorSelcionado);

    }

    public bool Comparador(){
        cardOponentObject.transform.position = posicaoAtivaOponente;
        Debug.Log(card.valorSelcionado);
        Debug.Log(oponentCard.valorSelcionado);

        Debug.Log("id do player"+card.id);
        Debug.Log("id do oponente"+oponentCard.id);
        if(Comparador_Valores(card.valorSelcionado,oponentCard.valorSelcionado)){

            oponentCard.selectRed();
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

                card.selectRed();
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
            PullPopup("OPONENTE VENCE A PARTIDA\n voltar ao menu?");
            Debug.Log("OPONENTE VENCE A PARTIDA !!!!!!!!!!!!!!!!!!!!!!!");
            GameStateButton.text ="MENU";
            JogarGameObject.SetActive(true);
            gameState=5;
        }
        if(deckOponent.Total()==0){
            PullPopup("JOGADOR VENCE A PARTIDA\n voltar ao menu?");
            Debug.Log("JOGADOR VENCE A PARTIDA !!!!!!!!!!!!!!!!!!!!!!!");
            GameStateButton.text ="MENU";
            JogarGameObject.SetActive(true);
            gameState=5;
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
