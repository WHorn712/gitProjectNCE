using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    private char sexo;
    private int idade;
    private int registro;
    private int idadeDie;
    private Hability habiliti;
    private int quantSon;
    public Person(char s,int id,int r)
    {
        sexo = s;
        idade = id;
        registro = r;
        DecididIdadeDie();
        habiliti = new Hability();
        if(s=='F')
        {
            quantSon = Random.Range(0, 8);
        }
    }
    private void DecididIdadeDie()
    {
        float a = Random.Range(0, 101);
        if (a <= 94)
        {
            float b = Random.Range(0, 101);
            if (b > 30)
            {
                idadeDie = Random.Range(60, 80);
            }
            else if (b <= 30)
            {
                idadeDie = Random.Range(60, 40);
            }
        }
        else if (a > 92 && a < 101)
        {
            idadeDie = Random.Range(81, 100);
        }
    }
    public int QuantSon
    {
        get
        {
            return quantSon;
        }
        set
        {
            quantSon = value;
        }
    }
    public char Sexo
    {
        get
        {
            return sexo;
        }
        set
        {
            sexo = value;
        }
    }
    public int Idade
    {
        get
        {
            return idade;
        }
        set
        {
            idade = value;
        }
    }
    public int Registro
    {
        get
        {
            return registro;
        }
        set
        {
            registro = value;
        }
    }
    public int IdadeDie
    {
        get
        {
            return idadeDie;
        }
        set
        {
            idadeDie = value;
        }
    }
    public Hability hability
    {
        get
        {
            return habiliti;
        }
        set
        {
            habiliti = value;
        }
    }
}
