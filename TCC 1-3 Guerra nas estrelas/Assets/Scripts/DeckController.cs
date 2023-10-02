using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DeckController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI totalTxt;


    Queue<int> queue;
    
    void Start()
    {
         queue = new Queue<int>();
        
    }

    public void Insert(int card){
        queue.Enqueue(card);
        //UpdateTotal();
    }

    public int Draw(){
        int c=queue.Dequeue();// as int;
        //UpdateTotal();
        return c; 
    }

    public int Total(){
        return queue.Count;
    }

    public void UpdateTotal(){
        totalTxt.text =Total().ToString();
    }

}
