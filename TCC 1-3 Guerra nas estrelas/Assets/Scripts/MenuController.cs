using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menuAjuda;


    public GameObject buttonJogar;
    public GameObject buttonSair;
    public GameObject buttonAjuda;
    public GameObject button2Jogadores;
    public GameObject button3Jogadores;
    public GameObject button4Jogadores;
    public GameObject button5Jogadores;
    public GameObject button6Jogadores;
    private int jogadores;
    //private Collor collor;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        menuAjuda.SetActive(false);
        //button = this.GetComponent<Button>();
        //collor=buttonAjuda.GetComponent<Image>().color;
        //ClearSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollorButton(GameObject activeButton){
        ClearSelection();
        activeButton.GetComponent<Image>().color=Color.green;
         //var colors = GetComponent<Button>().colors;
    }

    public void SelectPlayers(int valor){
    jogadores=valor;
    }

    public void Iniciar(){
    SceneManager.LoadScene(1);

    }

    public void Sair(){
        AplicationController.Exit();
    }

    public void Ajuda(){
        RevelaMenu(menuAjuda);
    }

    public void Voltar(){
        RevelaMenu(mainMenu);
    }

    void EscondeMenu(){
        mainMenu.SetActive(false);
        menuAjuda.SetActive(false);
    }

    void RevelaMenu(GameObject menu){
        EscondeMenu();
        menu.SetActive(true);
    }

    void ClearSelection(){
        button2Jogadores.GetComponent<Image>().color=Color.white;
        button3Jogadores.GetComponent<Image>().color=Color.white;
        button4Jogadores.GetComponent<Image>().color=Color.white;
        button5Jogadores.GetComponent<Image>().color=Color.white;
        button6Jogadores.GetComponent<Image>().color=Color.white;
    }
}
