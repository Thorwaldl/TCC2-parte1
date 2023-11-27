using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OponenteController : MonoBehaviour
{

    public float magnetudeMedia;
    public float massaMedia;
    public float raioMedia;
    public float luminosidadeMedia;
    public float temperaturaMedia;
    public float distanciaMedia;

    private float[] magnetudes;
    private float[] massas;
    private float[] raios;
    private float[] luminosidades;
    private float[] temperaturas;
    private float[] distancias;

    public int total=10;


    public void Setup(CardData[] cardDatas, int quantia){
        total=quantia;
        magnetudes=new float[total];
        massas=new float[total];
        raios=new float[total];
        luminosidades=new float[total];
        temperaturas=new float[total];
        distancias=new float[total];

        Arrayfiller(cardDatas);
        
        //AverageFinder(total);
    }

    void Arrayfiller(CardData[] cd){
        
        for(int index=0;index<total;index++){

            magnetudes[index]=cd[index].magnetude;
            massas[index]=cd[index].massa;
            raios[index]=cd[index].raio;
            luminosidades[index]=cd[index].luminosidade;
            temperaturas[index]=cd[index].temperatura;
            distancias[index]=cd[index].distancia;
            Debug.Log(index);
        }

        ArraySorter(magnetudes);
        ArraySorter(massas);
        ArraySorter(raios);
        ArraySorter(luminosidades);
        ArraySorter(temperaturas);
        ArraySorter(distancias);
    }

    void ArraySorter(float[] array){
        float temp;
        for(int i=0;i<total;i++){
            for(int j=0;j<total;j++){
                if(array[i]<array[j]){
                    temp=array[i];
                    array[i]=array[j];
                    array[j]=temp;
                }
            }
        }
    }

    void MiddleFinder(){
        magnetudeMedia=magnetudes[total/2];
        massaMedia=massas[total/2];
        raioMedia=raios[total/2];
        luminosidadeMedia=luminosidades[total/2];
        temperaturaMedia=temperaturas[total/2];
        distanciaMedia=distancias[total/2];
    }

    void AverageFinder(int size){
        float valor=0f;
        foreach(float f in magnetudes){
            valor=+f;
        }
        magnetudeMedia=valor/size;

        valor=0f;
        foreach(float f in massas){
            valor=+f;
        }
        massaMedia=valor/size;

        valor=0f;
        foreach(float f in raios){
            valor=+f;
        }
        raioMedia=valor/size;

        valor=0f;
        foreach(float f in luminosidades){
            valor=+f;
        }
        luminosidadeMedia=valor/size;

        valor=0f;
        foreach(float f in temperaturas){
            valor=+f;
        }
        temperaturaMedia=valor/size;

        valor=0f;
        foreach(float f in distancias){
            valor=+f;
        }
        distanciaMedia=valor/size;
    }

    public int VariableChooser(float magnetude,float massa, float raio, float luminosidade,float temperatura, float distancia){
        bool anyFlag=false;
        bool magnetudeFlag=false;
        bool massaFlag=false;
        bool raioFlag=false;
        bool luminosidadeFlag=false;
        bool temperaturaFlag=false;
        bool distanciaFlag=false;
        
        if(magnetude>magnetudeMedia){
            magnetudeFlag=true;
            anyFlag=true;
        }

        if(massa>massaMedia){
            massaFlag=true;
            anyFlag=true;
        }

        if(raio>raioMedia){
            raioFlag=true;
            anyFlag=true;
        }

        if(luminosidade>luminosidadeMedia){
            luminosidadeFlag=true;
            anyFlag=true;
        }

        if(temperatura>temperaturaMedia){
            temperaturaFlag=true;
            anyFlag=true;
        }

        if(distancia>distanciaMedia){
            distanciaFlag=true;
            anyFlag=true;
        }
        
        System.Random random = new System.Random();       
        
        while(true){
            if(!anyFlag){
                return random.Next(0,5);
            }
            
            switch (random.Next(0,5)){
                    case 0:
                        if(magnetudeFlag){
                            return 0;
                        }
                        break;
                    case 1:
                        if(massaFlag){
                            return 1;
                        }
                        break;
                    case 2:
                        if(raioFlag){
                            return 2;
                        }
                        break;
                    case 3:
                        if(luminosidadeFlag){
                            return 3;
                        }
                        break;
                    case 4:
                        if(temperaturaFlag){
                            return 4;
                        }
                        break;
                    case 5:
                        if(distanciaFlag){
                            return 5;
                        }
                        break;
            }
        }
    }
}
