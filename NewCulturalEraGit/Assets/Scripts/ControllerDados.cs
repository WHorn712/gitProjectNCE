using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ControllerDados : MonoBehaviour
{
    public static ControllerDados controllerDados;
    [SerializeField]
    private GameObject mensagem;

    [SerializeField]
    private UnityEngine.UI.Image imageInsatisfation;
    [SerializeField]
    private UnityEngine.UI.Image imageRelacao;
    [SerializeField]
    private UnityEngine.UI.Image imageRespeito;
    [SerializeField]
    private UnityEngine.UI.Image imageConhecimento;
    [SerializeField]
    private Text textInsatisfation;
    [SerializeField]
    private Text textRelacao;
    [SerializeField]
    private Text textRespeito;
    [SerializeField]
    private Text textConhecimento;

    int c0=0;
    int c1=0;
    int c2=0;
    int c3=0;

    private float insatisfation;
    private float relacao;
    private float respeito;
    private float conhecimento;

    public float Insatisation
    {
        get
        {
            return insatisfation;
        }
        set
        {
            insatisfation = value;
            ActualyDados(0);
        }
    }
    public float Relacao
    {
        get
        {
            return relacao;
        }
        set
        {
            //if (c1 == 10)
            //{
            //    if (value < relacao)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "-RELAÇÃO";
            //    }
            //    else if (value > relacao)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "+RELAÇÃO";
            //    }
            //    c1 = 0;
            //}
            //c1++;
            //mensagem.SetActive(true);
            relacao = value;
            ActualyDados(1);
        }
    }
    public float Respeito
    {
        get
        {
            return respeito;
        }
        set
        {
            //if (c2 == 10)
            //{
            //    if (value < respeito)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "-RESPEITO";
            //    }
            //    else if (value > respeito)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "+RESPEITO";
            //    }
            //    c2 = 0;
            //}
            //c2++;
            //mensagem.SetActive(true);
            respeito = value;
            ActualyDados(2);
        }
    }
    public float Conhecimento
    {
        get
        {
            return conhecimento;
        }
        set
        {
            //if (c3 == 10)
            //{
            //    if (value < conhecimento)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "-CONHECIMENTO";
            //    }
            //    else if (value > conhecimento)
            //    {
            //        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "+CONHECIMENTO";
            //    }
            //    c3 = 0;
            //}
            //c3++;
            //mensagem.SetActive(true);
            conhecimento = value;
            ActualyDados(3);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        controllerDados = this;
        insatisfation = 3;
        relacao = 4;
        respeito = 2;
        conhecimento = 1;
        ActualyDados();
    }
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        if(mensagem.activeSelf)
        {
            time += Time.deltaTime;
            if(time>1)
            {
                time = 0;
                mensagem.SetActive(false);
            }
        }
    }
    private void ActualyDados()
    {
        Actualy(insatisfation, imageInsatisfation,textInsatisfation);
        Actualy(relacao, imageRelacao,textRelacao);
        Actualy(respeito, imageRespeito,textRespeito);
        Actualy(conhecimento, imageConhecimento,textConhecimento);
    }
    private void ActualyDados(int i)
    {
        if(i==0)
        {
            if(insatisfation<0)
            {
                insatisfation = 0;
            }
            Actualy(insatisfation, imageInsatisfation,textInsatisfation);
        }
        else if(i==1)
        {
            if (relacao < 0)
            {
                relacao = 0;
            }
            Actualy(relacao, imageRelacao,textRelacao);
        }
        else if (i == 2)
        {
            if (respeito < 0)
            {
                respeito = 0;
            }
            Actualy(respeito, imageRespeito,textRespeito);
        }
        else if (i == 3)
        {
            if (conhecimento < 0)
            {
                conhecimento = 0;
            }
            Actualy(conhecimento, imageConhecimento,textConhecimento);
        }
    }
    private void Actualy(float a, UnityEngine.UI.Image b,Text c)
    {
        float y = (428.68f * a) / 100;
        float x = -211.71f + y;
        b.rectTransform.offsetMax = new Vector2(x, b.rectTransform.offsetMax.y);
        float a2 = (float)(Decimal.Round((decimal)a, 0));
        c.text = a2+" %";
    }
    public void MakeMensagem(int type,int quan)
    {
        string a = "";
        string b = "";
        if(type==0)
        {
            a = "INSATISFAÇÃO";
        }
        else if(type==1)
        {
            a = "NEGÓCIOS";
        }
        else if (type == 2)
        {
            a = "RESPEITO";
        }
        else if (type == 3)
        {
            a = "CONHECIMENTO";
        }
        if(quan==0)
        {
            b = "+";
        }
        else
        {
            b = "-";
        }
        mensagem.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = b + " " + a;
        mensagem.SetActive(true);
    }
}
