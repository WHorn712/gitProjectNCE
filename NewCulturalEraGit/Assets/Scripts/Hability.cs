using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability
{
    private int codFuncao;
    private int codFerramentaAct;
    private float prod;
    private float priceBuy;
    private bool noFuncao;
    private bool noFer;
    
    public Hability() 
    {
        codFuncao = 0;
        codFerramentaAct = 0;
        prod = 0;
        priceBuy = 0;
        noFuncao = true;
        noFer = true;
    }
    public bool NoFer
    {
        get
        {
            return noFer;
        }
    }
    public bool NoFuncao
    {
        get
        {
            return noFuncao;
        }
    }
    public int CodFuncao
    {
        get
        {
            return codFuncao;
        }
        set
        {
            codFuncao = value;
        }
    }
    public int CodFerramentaAct
    {
        get
        {
            return codFerramentaAct;
        }
        set
        {
            codFerramentaAct = value;
        }
    }
    public float Prod
    {
        get
        {
            return prod;
        }
        set
        {
            prod = value;
        }
    }
    public float PriceBuy
    {
        get
        {
            return priceBuy;
        }
        set
        {
            priceBuy = value;
        }
    }

    //Ferreiro --> tempo e liberação para construir ferramentas
    //Caçador,
    //ColetorAgua,
    //ColetorMadeira,
    //ColetorPedra,
    //coletorMetal,
    //Enfermeira
    //Pescador,
    //Agricultor,
    //Navegador --> tempo e sucesso de uma viajem
    //Espiao --> tempo e sucesso de uma espionagem
    //Mensageiro --> tempo e sucesso de uma mensagem
    //Transportador --> tempo e sucesso de uma carga
    //Berserker --> mais probabilidade de ganhar uma batalha

    //Noone,
    //    Navalha,
    //    MachadoDePedra,
    //    MachadoDeMetal,
    //    MachadoDeFerro,
    //    ArcoEFlecha,
    //    Lança,
    //    Balde,
    //    Estrutura,
    //    VaraDePesca1,
    //    VaraDePesca2,
    //    VaraDePesca3,
    //    Enchada,
    //    Arado


    public void DefinindoFuncao(int a, int idade)
    {
        noFuncao = false;
        switch(a)
        {
            case 0:
                codFuncao = 0;
                priceBuy = 25;
                DefinindoProd(0, idade);
                break;
            case 1:
                codFuncao = 1;
                priceBuy = 50;
                DefinindoProd(1, idade);
                break;
            case 2:
                codFuncao = 2;
                priceBuy = 50;
                DefinindoProd(2, idade);
                break;
            case 3:
                codFuncao = 3;
                priceBuy = 100;
                DefinindoProd(3, idade);
                break;
            case 4:
                codFuncao = 4;
                priceBuy = 125;
                DefinindoProd(4, idade);
                break;
            case 5:
                codFuncao = 5;
                priceBuy = 135;
                DefinindoProd(5, idade);
                break;
            case 6:
                codFuncao = 6;
                priceBuy = 350;
                DefinindoProd(6, idade);
                break;
            case 7:
                codFuncao = 7;
                priceBuy = 375;
                DefinindoProd(7, idade);
                break;
            case 8:
                codFuncao = 8;
                priceBuy = 400;
                DefinindoProd(8, idade);
                break;
            case 9:
                codFuncao = 9;
                priceBuy = 450;
                DefinindoProd(9, idade);
                break;
            case 10:
                codFuncao = 10;
                priceBuy = 500;
                DefinindoProd(10, idade);
                break;
            case 11:
                codFuncao = 11;
                priceBuy = 550;
                DefinindoProd(11, idade);
                break;
            case 12:
                codFuncao = 12;
                priceBuy = 600;
                DefinindoProd(12, idade);
                break;
            case 13:
                codFuncao = 13;
                priceBuy = 1000;
                DefinindoProd(13, idade);
                break;
        }
    }
//    comida agua           madeira pedra                  metal
//17-20 - 1           17-20 - 1        17-20 - 0.5f       17-20 - 0.5f         17-20 - 0.25f
//20-40 - 2           20-40 - 2        20-40 - 1          20-40 - 1            20-40 - 0.5f
//40-60 - 1           40-60 - 1        40-60 - 0.5f       40-60 - 0.5f         40-60 - 0.25f
//+60   - 0.5f        +60   - 0.5f     +60   - 0.25f      +60   - 0.25f        +60   - 0.1f

//ferreiro enfermeira      pescador agricultor         navegador
//17-20 - 80dias    17-20 - 80dias    17-20 - 2      17-20 - 4         17-20 - 50    
//20-40 - 50dias    20-40 - 50dias    20-40 - 4      20-40 - 8         20-40 - 60
//40-60 - 80dias    40-60 - 30dias    40-60 - 2      40-60 - 4         40-60 - 50
//+60   - 100dias   +60   - 20dias    +60   - 1      +60   - 2         +60   - 40

//espiao
//17-20 - 
//20-40 -
//40-60 -
//+60   -
    private void DefinindoProd(int a,int idade)
    {
        if(a==0)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 80;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 50;
            }
            else if(idade>40&&idade<=60)
            {
                prod = 80;
            }
            else if(idade>60)
            {
                prod = 100;
            }
        }
        else if(a==1||a==2)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 1;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 2;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 1;
            }
            else if (idade > 60)
            {
                prod = 0.5f;
            }
        }
        else if (a == 3||a==4)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 0.5f;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 1;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 0.5f;
            }
            else if (idade > 60)
            {
                prod = 0.25f;
            }
        }
        else if (a == 5)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 0.25f;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 0.5f;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 0.25f;
            }
            else if (idade > 60)
            {
                prod = 0.1f;
            }
        }
        else if (a == 6)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 80;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 50;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 30;
            }
            else if (idade > 60)
            {
                prod = 20;
            }
        }
        else if (a == 7)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 2;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 4;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 2;
            }
            else if (idade > 60)
            {
                prod = 1;
            }
        }
        else if (a == 8)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 4;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 8;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 4;
            }
            else if (idade > 60)
            {
                prod = 2;
            }
        }
        else if (a == 9)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 50;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 60;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 50;
            }
            else if (idade > 60)
            {
                prod = 40;
            }
        }
        else if (a == 10)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 50;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 60;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 50;
            }
            else if (idade > 60)
            {
                prod = 40;
            }
        }
        else if (a == 11)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 50;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 60;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 50;
            }
            else if (idade > 60)
            {
                prod = 40;
            }
        }
        else if (a == 12)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 50;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 60;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 50;
            }
            else if (idade > 60)
            {
                prod = 40;
            }
        }
        else if (a == 13)
        {
            if (idade >= 17 && idade <= 20)
            {
                prod = 10;
            }
            else if (idade > 20 && idade <= 40)
            {
                prod = 15;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 10;
            }
            else if (idade > 60)
            {
                prod = 5;
            }
        }
    }
}
