using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDados : MonoBehaviour
{
    public static ControllerDados controllerDados;
    [SerializeField]
    private Image imageInsatisfation;
    [SerializeField]
    private Image imageRelacao;
    [SerializeField]
    private Image imageRespeito;
    [SerializeField]
    private Image imageConhecimento;
    [SerializeField]
    private Text textInsatisfation;
    [SerializeField]
    private Text textRelacao;
    [SerializeField]
    private Text textRespeito;
    [SerializeField]
    private Text textConhecimento;

    private int insatisfation;
    private int relacao;
    private int respeito;
    private int conhecimento;

    public int Insatisation
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
    public int Relacao
    {
        get
        {
            return relacao;
        }
        set
        {
            relacao = value;
            ActualyDados(1);
        }
    }
    public int Respeito
    {
        get
        {
            return respeito;
        }
        set
        {
            respeito = value;
            ActualyDados(2);
        }
    }
    public int Conhecimento
    {
        get
        {
            return conhecimento;
        }
        set
        {
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

    // Update is called once per frame
    void Update()
    {
        
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
            Actualy(insatisfation, imageInsatisfation,textInsatisfation);
        }
        else if(i==1)
        {
            Actualy(relacao, imageRelacao,textRelacao);
        }
        else if (i == 2)
        {
            Actualy(respeito, imageRespeito,textRespeito);
        }
        else if (i == 3)
        {
            Actualy(conhecimento, imageConhecimento,textConhecimento);
        }
    }
    private void Actualy(int a,Image b,Text c)
    {
        float y = (428.68f * a) / 100;
        float x = -211.71f + y;
        b.rectTransform.offsetMax = new Vector2(x, b.rectTransform.offsetMax.y);
        c.text = a+" %";
    }
}
