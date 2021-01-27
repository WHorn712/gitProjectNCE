using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trabalhadores : MonoBehaviour
{
    [SerializeField]
    private Text textPopulation;
    private int homensNoWork;
    [SerializeField]
    private Text textHNW;
    public List<Person> ferreiro = new List<Person>();
    public List<Person> hunter = new List<Person>();
    public List<Person> coletorDeAgua = new List<Person>();
    public List<Person> coletorDeMadeira = new List<Person>();
    public List<Person> coletorDePedra = new List<Person>();
    public List<Person> coletorDeMetal = new List<Person>();
    public List<Person> enfermeira = new List<Person>();
    public List<Person> pescador = new List<Person>();
    public List<Person> agricultor = new List<Person>();
    public List<Person> navegador = new List<Person>();
    public List<Person> espiao = new List<Person>();
    public List<Person> mensageiro = new List<Person>();
    public List<Person> transportador = new List<Person>();
    public List<Person> berserker = new List<Person>();
    private GameObject telaTextsTrabalhadores;
    private float[] prices = { 25, 50, 50, 100, 125, 150, 175, 200, 250, 300, 350, 400, 450, 500 };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(prices[0].ToString());
        telaTextsTrabalhadores = transform.GetChild(0).transform.GetChild(8).transform.GetChild(0).gameObject;
        homensNoWork = 100;
        textHNW.text = homensNoWork.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddWork(List<Person> a,int b,float c)
    {
        if (ControllerMoney.cont.Money > c)
        {
            if (b == 6)
            {
                bool ok = false;
                for (int i = 0; i < Controller.current.population.Count; i++)
                {
                    if (Controller.current.population[i].Sexo == 'F')
                    {
                        ok = true;
                    }
                }
                if (ok)
                {
                    AddWorkProcess(a, b, 2);
                }
                else
                {
                    //exibi tela de mensagem
                }
            }
            else if (b == 13)
            {
                bool ok = false;
                for (int i = 0; i < Controller.current.population.Count; i++)
                {
                    if (Controller.current.population[i].Sexo == 'M')
                    {
                        ok = true;
                    }
                }
                if (ok)
                {
                    AddWorkProcess(a, b, 2);
                }
                else
                {
                    //exibi tela de mensagem
                }
            }
            else
            {
                AddWorkProcess(a, b, 0);
            }
        }
    }
    private void AddWorkProcess(List<Person> a,int b,int t)
    {
        //c==0 qualquer c==1 macho c==2 femea
        if (t == 0)
        {
            for (int i = 0; i < Controller.current.population.Count; i++)
            {
                if (Controller.current.population[i].Idade >= 17 && Controller.current.population[i].hability.NoFuncao)
                {
                    Controller.current.population[i].DefinindoFuncao(b);
                    a.Add(Controller.current.population[i]);
                    telaTextsTrabalhadores.transform.GetChild(b).transform.GetChild(9).GetComponent<Text>().text = a.Count.ToString();
                    MakeUpdateTexts();
                    i = Controller.current.population.Count + 12;
                }
            }
        }
        else if(t==1)
        {
            for (int i = 0; i < Controller.current.population.Count; i++)
            {
                if (Controller.current.population[i].Sexo=='M'&&Controller.current.population[i].Idade >= 17 && Controller.current.population[i].hability.NoFuncao)
                {
                    Controller.current.population[i].DefinindoFuncao(b);
                    a.Add(Controller.current.population[i]);
                    telaTextsTrabalhadores.transform.GetChild(b).transform.GetChild(9).GetComponent<Text>().text = a.Count.ToString();
                    MakeUpdateTexts();
                    i = Controller.current.population.Count + 12;
                }
            }
        }
        else if(t==2)
        {
            for (int i = 0; i < Controller.current.population.Count; i++)
            {
                if (Controller.current.population[i].Sexo=='F'&&Controller.current.population[i].Idade >= 17 && Controller.current.population[i].hability.NoFuncao)
                {
                    Controller.current.population[i].DefinindoFuncao(b);
                    a.Add(Controller.current.population[i]);
                    telaTextsTrabalhadores.transform.GetChild(b).transform.GetChild(9).GetComponent<Text>().text = a.Count.ToString();
                    MakeUpdateTexts();
                    i = Controller.current.population.Count + 12;
                }
            }
        }
    }
    public void ClickAddWork(int i)
    {
        if (homensNoWork > 0)
        {
            switch (i)
            {
                case 0:
                    AddWork(ferreiro,0,prices[0]);
                    float x = prices[0] + (1 * ferreiro.Count);
                    prices[0] = x;
                    x = 0;
                    break;
                case 1:
                    AddWork(hunter,1,prices[1]);
                    x = prices[1] + (2 * hunter.Count);
                    prices[1] = x;
                    break;
                case 2:
                    AddWork(coletorDeAgua,2,prices[2]);
                    x = prices[2] + (3 * coletorDeAgua.Count);
                    prices[2] = x;
                    break;
                case 3:
                    AddWork(coletorDeMadeira,3, prices[3]);
                    x = prices[3] + (4 * ferreiro.Count);
                    prices[3] = x;
                    break;
                case 4:
                    AddWork(coletorDePedra,4, prices[4]);
                    x = prices[4] + (5 * ferreiro.Count);
                    prices[4] = x;
                    break;
                case 5:
                    AddWork(coletorDeMetal,5, prices[5]);
                    x = prices[5] + (6 * ferreiro.Count);
                    prices[5] = x;
                    break;
                case 6:
                    AddWork(enfermeira, 6, prices[6]);
                    x = prices[6] + (7 * ferreiro.Count);
                    prices[6] = x;
                    break;
                case 7:
                    AddWork(pescador,7, prices[7]);
                    x = prices[7] + (8 * ferreiro.Count);
                    prices[7] = x;
                    break;
                case 8:
                    AddWork(agricultor,8, prices[8]);
                    x = prices[8] + (9 * ferreiro.Count);
                    prices[8] = x;
                    break;
                case 9:
                    AddWork(navegador,9, prices[9]);
                    x = prices[9] + (10 * ferreiro.Count);
                    prices[9] = x;
                    break;
                case 10:
                    AddWork(espiao,10, prices[10]);
                    x = prices[10] + (11 * ferreiro.Count);
                    prices[10] = x;
                    break;
                case 11:
                    AddWork(mensageiro,11, prices[11]);
                    x = prices[11] + (12 * ferreiro.Count);
                    prices[11] = x;
                    break;
                case 12:
                    AddWork(transportador,12, prices[12]);
                    x = prices[12] + (13 * ferreiro.Count);
                    prices[12] = x;
                    break;
                case 13:
                    AddWork(berserker,13, prices[13]);
                    x = prices[13] + (14 * ferreiro.Count);
                    prices[13] = x;
                    break;
            }
        }
    }
    public void MakeUpdateTexts()
    {
        textPopulation.text = Controller.current.population.Count.ToString();
        int a=0;
        for(int i=0;i<Controller.current.population.Count;i++)
        {
            if(Controller.current.population[i].hability.NoFuncao)
            {
                a++;
            }
        }
        homensNoWork = a;
        textHNW.text = homensNoWork.ToString();
    }
}
