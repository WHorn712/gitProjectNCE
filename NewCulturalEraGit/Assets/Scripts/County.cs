using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class County
{
    private int codigo;
    private int population;
    private int mulheres;
    private int comida;
    private int agua;
    private int madeira;
    private int pedra;
    private int metal;
    private int ferro;
    private int aco;
    private int cultivo;
    private bool isMine;
    private string name;
    public County(int cod,int pop,int fe,int cul,int ma,int rio,int ped,bool im,string n)
    {
        codigo = cod;
        population = pop;
        mulheres = fe;
        float c = ((float)cul + (float)ma + ((float)rio / 2)) / 3;
        comida = (int)c;
        agua = rio;
        madeira = ma;
        pedra = ped;
        metal = ped;
        ferro = ped;
        aco = ped;
        cultivo = cul;
        isMine = im;
        name = n.ToUpper();
    }
    public int Codigo
    {
        get
        {
            return codigo;
        }
    }
    public int Cultivo
    {
        get
        {
            return cultivo;
        }
        set
        {
            cultivo = value;
        }
    }
    public int Population
    {
        get
        {
            return population;
        }
        set
        {
            population = value;
        }
    }
    public int Mulheres
    {
        get
        {
            return mulheres;
        }
        set
        {
            mulheres = value;
        }
    }
    public int Comida
    {
        get
        {
            return comida;
        }
        set
        {
            comida = value;
        }
    }
    public int Agua
    {
        get
        {
            return agua;
        }
        set
        {
            agua = value;
        }
    }
    public int Madeira
    {
        get
        {
            return madeira;
        }
        set
        {
            madeira = value;
        }
    }
    public int Pedra
    {
        get
        {
            return pedra;
        }
        set
        {
            pedra = value;
        }
    }
    public int Metal
    {
        get
        {
            return metal;
        }
        set
        {
            metal = value;
        }
    }
    public int Ferro
    {
        get
        {
            return ferro;
        }
        set
        {
            ferro = value;
        }
    }
    public int Aco
    {
        get
        {
            return aco;
        }
        set
        {
            aco = value;
        }
    }
    public bool IsMine
    {
        get
        {
            return isMine;
        }
        set
        {
            isMine = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
}
