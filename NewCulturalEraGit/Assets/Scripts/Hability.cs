using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hability
{
    private int codFuncao;
    private int codFerramentaEsp;
    private int codFerramentaAct;
    private float prod;
    private float priceBuy;
    private float priceUp;
    public Hability()
    {
        codFuncao = 0;
        codFerramentaEsp = 0;
        codFerramentaAct = 0;
        prod = 0;
        priceBuy = 0;
        priceUp = 0;
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
    public int CodFerramentaEsp
    {
        get
        {
            return codFerramentaEsp;
        }
        set
        {
            codFerramentaEsp = value;
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
    public float PriceUp
    {
        get
        {
            return priceUp;
        }
        set
        {
            priceUp = value;
        }
    }

    //Ferreiro
    //Caçador,
    //ColetorAgua,
    //ColetorMadeira,
    //ColetorPedra,
    //coletorMetal,
    //Artesã
    //Enfermeira
    //Pescador,
    //Agricultor,
    //Navegador,
    //Espiao,
    //Mensageiro,
    //Transportador,
    //Berserker

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


    public void DefinindoFuncao(int a)
    {

    }
}
