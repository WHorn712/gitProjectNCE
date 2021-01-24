using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ControllerMoney : MonoBehaviour
{
    //public Text moneyTextCC;
    public Text moneytext;
    private float money;
    //public List<ControlerKingdom> terras = new List<ControlerKingdom>();
    //public ControlerKingdom terraatual;
    public static ControllerMoney cont;
    private void Awake()
    {
        cont = this;
        //moneyTextCC = GameObject.Find("Canvas").transform.GetChild(12).transform.GetChild(1).transform.GetChild(12).transform.GetChild(1).GetComponent<Text>();
    }
    private void Start()
    {
        money = 100;
        moneytext.text = money.ToString();
        //float a = (float)Decimal.Round((decimal)3.567f,0);
        //float b = (float)Decimal.Round((decimal)3.567f, 1);
        //float c= (float)Decimal.Round((decimal)3.567f, 2);
        //Debug.Log(a + "       " + b + "      " + c);
    }
    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            if (money < 0)
            {
                money = 0;
            }
            //moneytext.text = Encurtando(money);
            //moneyTextCC.text = Encurtando(money);
        }
    }
    public void MoneyForProd(float m)
    {
        money += (m);
        //moneytext.text = Encurtando(money);
        //moneyTextCC.text = Encurtando(money);
    }
    //private string Encurtando(float m)
    //{
    //    return ControlerKingdom.currentck.EncurtandoFloat(m);
    //}
}
