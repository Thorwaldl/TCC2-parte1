using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Button button ;
    public GameObject newButton;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();

    }

    void Onclick(){
        var colors = GetComponent<Button> ().colors;
        colors.normalColor = Color.red;
         GetComponent<Button> ().colors = colors;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCollor(){
        newButton.GetComponent<Image>().color=Color.green;
    }
}
