using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject buttonJogar;
    public GameObject buttonSair;
    public GameObject buttonAjuda;
    public GameObject button2Jogadores;
    public GameObject button3Jogadores;
    public GameObject button4Jogadores;
    public GameObject button5Jogadores;
    public GameObject button6Jogadores;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCollor(GameObject newButton){
        newButton.GetComponent<Image>().color=Color.green;
    }
}
