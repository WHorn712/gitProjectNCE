using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafio : MonoBehaviour
{
    private string desafioText;
    private int quantAlcan;
    private int type;
    private int id;

    public Desafio(string d, int q2, int t, int i)
    {
        desafioText = d;
        quantAlcan = q2;

        //type==0 MANDAR RECURSOS
        //type==1 fazer algo quantidade de vezes
        type = t;
        id = i;
    }
    public int ID
    {
        get
        {
            return id;
        }
    }
    public string DesafioText
    {
        get
        {
            return desafioText;
        }
    }
    public int QuantAlcan
    {
        get
        {
            return quantAlcan;
        }
        set
        {
            quantAlcan = value;
        }
    }
    public int Type
    {
        get
        {
            return type;
        }
    }
}
