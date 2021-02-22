using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability
{
    private int codFuncao;
    private int codFerramentaAct;
    private float[] prodPos = { 0, 0, 0, 0 };
    private float prod;
    private float priceBuy;
    private bool noFuncao;
    private bool noFer;
    private int fer1;
    private int fer2;
    private int fer3;
    private int fer4;
    private int feratrib;
    public int FerAtrib
    {
        get
        {
            return feratrib;
        }
    }
    public Hability() 
    {
        codFuncao = 0;
        codFerramentaAct = 0;
        prod = 0;
        priceBuy = 0;
        noFuncao = true;
        noFer = true;
    }
    public int GetCodeFerramenta(int x)
    {
        if(x==0)
        {
            return fer1;
        }
        else if(x==1)
        {
            return fer2;
        }
        else if(x==2)
        {
            return fer3;
        }
        else
        {
            return fer4;
        }
    }
    public int GetPositionFer(int cod)
    {
        if(cod==fer1)
        {
            return 3;
        }
        else if (cod == fer2)
        {
            return 4;
        }
        else if (cod == fer3)
        {
            return 5;
        }
        else 
        {
            return 6;
        }
    }
    public int Fer1
    {
        get
        {
            return fer1;
        }
    }
    public int Fer2
    {
        get
        {
            return fer2;
        }
    }
    public int Fer3
    {
        get
        {
            return fer3;
        }
    }
    public int Fer4
    {
        get
        {
            return fer4;
        }
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

    private void DefinindoFerramentasAcessiveis(int a,int c1,int c2,int c3, int c4)
    {
        if(a>0)
        {
            feratrib = a;
            if(a==1)
            {
                fer1 = c1;
            }
            else if(a==2)
            {
                fer1 = c1;
                fer2 = c2;
            }
            else if (a == 3)
            {
                fer1 = c1;
                fer2 = c2;
                fer3 = c3;
            }
            else if (a == 4)
            {
                fer1 = c1;
                fer2 = c2;
                fer3 = c3;
                fer4 = c4;
            }
        }
    }
    public void DefinindoFuncao(int a, int idade)
    {
        noFuncao = false;
        switch(a)
        {
            case 0:
                codFuncao = 0;
                priceBuy = 10;
                DefinindoProd(0, idade);
                DefinindoFerramentasAcessiveis(0, 0, 0, 0, 0);
                break;
            case 1:
                codFuncao = 1;
                priceBuy = 25;
                DefinindoProd(1, idade);
                DefinindoFerramentasAcessiveis(4, 0, 1, 4, 3);
                break;
            case 2:
                codFuncao = 2;
                priceBuy = 25;
                DefinindoProd(2, idade);
                DefinindoFerramentasAcessiveis(2, 2, 8, 0, 0);
                break;
            case 3:
                codFuncao = 3;
                priceBuy = 100;
                DefinindoProd(3, idade);
                DefinindoFerramentasAcessiveis(3, 3, 6, 9, 0);
                break;
            case 4:
                codFuncao = 4;
                priceBuy = 125;
                DefinindoProd(4, idade);
                DefinindoFerramentasAcessiveis(3, 3, 6, 9, 0);
                break;
            case 5:
                codFuncao = 5;
                priceBuy = 135;
                DefinindoProd(5, idade);
                DefinindoFerramentasAcessiveis(3, 3, 6, 9, 0);
                break;
            case 6:
                codFuncao = 6;
                priceBuy = 350;
                DefinindoProd(6, idade);
                DefinindoFerramentasAcessiveis(0, 0, 0, 0, 0);
                break;
            case 7:
                codFuncao = 7;
                priceBuy = 375;
                DefinindoProd(7, idade);
                DefinindoFerramentasAcessiveis(3, 5, 7, 10, 0);
                break;
            case 8:
                codFuncao = 8;
                priceBuy = 400;
                DefinindoProd(8, idade);
                DefinindoFerramentasAcessiveis(2, 11, 12, 0, 0);
                break;
            case 9:
                codFuncao = 9;
                priceBuy = 450;
                DefinindoProd(9, idade);
                DefinindoFerramentasAcessiveis(0, 0, 0, 0, 0);
                break;
            case 10:
                codFuncao = 10;
                priceBuy = 500;
                DefinindoProd(10, idade);
                DefinindoFerramentasAcessiveis(4, 0, 3, 6, 9);
                break;
            case 11:
                codFuncao = 11;
                priceBuy = 550;
                DefinindoProd(11, idade);
                DefinindoFerramentasAcessiveis(4, 0, 6, 9, 1);
                break;
            case 12:
                codFuncao = 12;
                priceBuy = 600;
                DefinindoProd(12, idade);
                DefinindoFerramentasAcessiveis(4, 0, 6, 9, 4);
                break;
            case 13:
                codFuncao = 13;
                priceBuy = 1000;
                DefinindoProd(13, idade);
                DefinindoFerramentasAcessiveis(4, 6, 9, 13, 14);
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

    //0-faca
    //1-arco e flecha
    //2-balde
    //3-machado de pedra
    //4-lança
    //5-vara de pesca 1
    //6-machado de metal
    //7-vara de pesca 2
    //8-estrutura
    //9-machado de ferro
    //10vara de pesca 3
    //11enchada
    //12-arado
    //13-espada
    //14espada do rei

    //0-ferreiro
    //1-caçador
    //2-coletordeagua
    //3-coletordemadeira
    //4-coletordepedra
    //5-coletordemetal
    //6-enfermeiro
    //7-pescador
    //8-agricultor
    //9-navegador
    //10-espião
    //11-mensageiro
    //12-transportador
    //13-berserker

    private void DefinindoProdAsse(int a)
    {
        switch(a)
        {
            case 1:
                prodPos[0] = 0.5f;
                prodPos[1] = 1;
                prodPos[2] = 1.5f;
                prodPos[3] = 2;
                break;
            case 2:
                prodPos[0] = 1;
                prodPos[1] = 4;
                prodPos[2] = 0;
                prodPos[3] = 0;
                break;
            case 3:
                prodPos[0] = 0.25f;
                prodPos[1] = 0.5f;
                prodPos[2] = 1;
                prodPos[3] = 0;
                break;
            case 4:
                prodPos[0] = 0.2f;
                prodPos[1] = 0.4f;
                prodPos[2] = 0.6f;
                prodPos[3] = 0;
                break;
            case 5:
                prodPos[0] = 0.15f;
                prodPos[1] = 0.3f;
                prodPos[2] = 0.5f;
                prodPos[3] = 0;
                break;
            case 7:
                prodPos[0] = 1;
                prodPos[1] = 2.5f;
                prodPos[2] = 4;
                prodPos[3] = 0;
                break;
            case 8:
                prodPos[0] = 3;
                prodPos[1] = 6;
                prodPos[2] = 0;
                prodPos[3] = 0;
                break;
            case 9:
                prodPos[0] = 0.5f;
                prodPos[1] = 1;
                prodPos[2] = 1.5f;
                prodPos[3] = 2;
                break;
            case 10:
                prodPos[0] = 1;
                prodPos[1] = 2;
                prodPos[2] = 3;
                prodPos[3] = 4;
                break;
            case 11:
                prodPos[0] = 1;
                prodPos[1] = 2;
                prodPos[2] = 2.5f;
                prodPos[3] = 3;
                break;
            case 12:
                prodPos[0] = 2;
                prodPos[1] = 4;
                prodPos[2] = 5;
                prodPos[3] = 6;
                break;
            case 13:
                prodPos[0] = 2;
                prodPos[1] = 4;
                prodPos[2] = 6;
                prodPos[3] = 8;
                break;
        }
    }
    private void DefinindoProd(int a,int idade)
    {
        DefinindoProdAsse(a);
        if(a==0)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 2;
            }
            else if (idade >= 20 && idade <= 40)
            {
                prod = 4;
            }
            else if(idade>40&&idade<=60)
            {
                prod = 2;
            }
            else if(idade>60)
            {
                prod = 1;
            }
        }
        else if(a==1||a==2)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 1;
            }
            else if (idade >= 20 && idade <= 40)
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
            if (idade >= 17 && idade < 20)
            {
                prod = 0.5f;
            }
            else if (idade >= 20 && idade <= 40)
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
            if (idade >= 17 && idade < 20)
            {
                prod = 0.25f;
            }
            else if (idade >= 20 && idade <= 40)
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
            if (idade >= 17 && idade < 20)
            {
                prod = 1;
            }
            else if (idade >= 20 && idade <= 40)
            {
                prod = 2;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 3;
            }
            else if (idade > 60)
            {
                prod = 4;
            }
        }
        else if (a == 7)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 2;
            }
            else if (idade >= 20 && idade <= 40)
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
            if (idade >= 17 && idade < 20)
            {
                prod = 4;
            }
            else if (idade >= 20 && idade <= 40)
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
            if (idade >= 17 && idade < 20)
            {
                prod = 0.5f;
            }
            else if (idade >= 20 && idade <= 40)
            {
                prod = 1;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 2f;
            }
            else if (idade > 60)
            {
                prod = 3;
            }
        }
        else if (a == 10)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 1;
            }
            else if (idade >= 20 && idade <= 40)
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
        else if (a == 11)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 1;
            }
            else if (idade >= 20 && idade <= 40)
            {
                prod = 2;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 1;
            }
            else if (idade > 60)
            {
                prod = 1;
            }
        }
        else if (a == 12)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 2;
            }
            else if (idade >= 20 && idade <= 40)
            {
                prod = 1;
            }
            else if (idade > 40 && idade <= 60)
            {
                prod = 2;
            }
            else if (idade > 60)
            {
                prod = 0.5f;
            }
        }
        else if (a == 13)
        {
            if (idade >= 17 && idade < 20)
            {
                prod = 2;
            }
            else if (idade >= 20 && idade <= 40)
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
    }

    public void AtribuindoFerramenta(int cod)
    {
        noFer = false;
        if(cod==0)
        {
            codFerramentaAct = fer1;
            prod += prodPos[0];
        }
        else if(cod==1)
        {
            codFerramentaAct = fer2;
            prod += prodPos[1];
        }
        else if (cod == 2)
        {
            codFerramentaAct = fer3;
            prod += prodPos[2];
        }
        else if (cod == 3)
        {
            codFerramentaAct = fer4;
            prod += prodPos[3];
        }
    }
    public void RemovingFerramenta(int idade)
    {
        noFer = true;
        codFerramentaAct = 0;
        DefinindoProd(codFuncao, idade);
    }
}
