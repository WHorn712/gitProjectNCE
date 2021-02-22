using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    private List<int> typeProp = new List<int>();
    [SerializeField]
    private GameObject propaganda;
    [SerializeField]
    private Text comidaText;
    [SerializeField]
    private Text aguaText;
    public GameObject trabalhadoresTela;
    public GameObject dados;
    public static Controller current;
    public List<Person> population = new List<Person>();
    private int registroGeral;
    private bool stopTime;
    public float food;
    public float water;
    public float madeira;
    public float pedra;
    public float metal;
    public float ferro;
    public float aco;
    private Conquist conquist;
    private Trabalhadores trabalhadores;
    public int POPULACAO;
    private bool isActiveProp;
    private int nivel;
    private Situation sit;

    public bool IsActiveProp
    {
        get
        {
            return isActiveProp;
        }
        set
        {
            isActiveProp = value;
        }
    }
    private void ItiateVar()
    {
        food = 0;
        water = 0;
        madeira = 0;
        pedra = 0;
        metal = 0;
        ferro = 0;
        aco = 0;
    }
    public Conquist Counquist
    {
        get
        {
            return conquist;
        }
    }
    public Trabalhadores Trabalhadores
    {
        get
        {
            return trabalhadores;
        }
    }
    public GameObject Propaganda
    {
        get
        {
            return propaganda;
        }
    }
    private void Awake()
    {
        nivel = 0;
        registroGeral = 0;
        stopTime = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        sit = gameObject.GetComponent<Situation>();
        trabalhadores = trabalhadoresTela.GetComponent<Trabalhadores>();
        conquist = dados.GetComponent<Conquist>();
        ItiateVar();
        current = this;
        StartPopulation();
    }
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        POPULACAO = population.Count;
        if(propaganda.transform.GetChild(1).gameObject.activeSelf)
        {
            time += Time.deltaTime;
            if(time>=1)
            {
                stopTime = false;
                propaganda.transform.GetChild(1).gameObject.SetActive(false);
                time = 0;
            }
        }
    }
    public int Nivel
    {
        get
        {
            return nivel;
        }
    }
    public void DesblokNextNivel()
    {
        nivel++;
        PositionSocial ps = GameObject.Find("Canvas").transform.GetChild(13).transform.GetChild(5).GetComponent<PositionSocial>();
        ps.DesblokPositionSocial(nivel);
    }
    public void InitiatePositionSocial(int s)
    {
        PositionSocial ps = GameObject.Find("Canvas").transform.GetChild(13).transform.GetChild(5).GetComponent<PositionSocial>();
        ps.InitiateImagesPositionSocial(s);
    }
    public bool STOPTIME
    {
        get
        {
            return stopTime;
        }
        set
        {
            stopTime = value;
        }
    }
    public int RegistroGeral
    {
        get
        {
            return registroGeral;
        }
        set
        {
            registroGeral = value;
        }
    }
    private void StartPopulation()
    {
        for(int i=0;i<100;i++)
        {
            if(i%2==0)
            {
                population.Add(new Person('M', UnityEngine.Random.Range(20, 30), i));
            }
            else
            {
                population.Add(new Person('F', UnityEngine.Random.Range(20, 30), i));
            }
            registroGeral = i;
        }
    }



    public void WorkResources()
    {
        food += trabalhadores.GetProdWork(1);
        food += trabalhadores.GetProdWork(7);
        food += trabalhadores.GetProdWork(8);
        water += trabalhadores.GetProdWork(2);
        madeira += trabalhadores.GetProdWork(3);
        pedra += trabalhadores.GetProdWork(4);
        metal += trabalhadores.GetProdWork(5);
    }
    public void PopulationEating()
    {
        float a = population.Count * 0.2f;
        float b = population.Count * 0.1f;
        food -= a;
        water -= b;
        int x = 0;
        if(food<0)
        {
            food = 0;
            Debug.Log("FOME");
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + UnityEngine.Random.Range(0.1f, 0.5f);
            x++;
        }
        if(water<0)
        {
            water = 0;
            Debug.Log("SEDE");
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + UnityEngine.Random.Range(0.1f, 0.5f);
            x++;
        }
        if(x==0)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation - UnityEngine.Random.Range(0.01f, 0.2f);
        }
        food = (float)(Decimal.Round((decimal)food, 0));
        water = (float)(Decimal.Round((decimal)water, 0));
        TextsFoodWaterUpdate();
    }

    private void TextsFoodWaterUpdate()
    {
        float c = (float)(Decimal.Round((decimal)food, 0));
        comidaText.text = c.ToString();
        c = (float)(Decimal.Round((decimal)water, 0));
        aguaText.text = c.ToString();
    }

    public void AddPerson()
    {
        int sor = UnityEngine.Random.Range(0, 100);
        if (sor > 50)
        {
            population.Add(new Person('M', UnityEngine.Random.Range(17, 50), registroGeral));
        }
        else
        {
            population.Add(new Person('F', UnityEngine.Random.Range(17, 50), registroGeral));
        }
        registroGeral++;
    }
    public float Cort(float a)
    {
        return (float)(Decimal.Round((decimal)a, 0));
    }
    public void ClickPropaganda()
    {
        if (stopTime == false)
        {
            if (ControlTime.curren.Year == 1 && ControlTime.curren.Day <= 20 && typeProp.Count == 0)
            {
                typeProp.Add(0);
                string s = "DINHEIRO";
                float q = 450;
                string sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                float quan = q + ControllerMoney.cont.Money;
                ControllerMoney.cont.Money = quan;
                propaganda.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = s;
                propaganda.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = sq;
                propaganda.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                int a = 0;
                int y = UnityEngine.Random.Range(0, 6);
                bool ok = false;
                List<int> n = new List<int>();
                for (int x = 0; x < 6; x++)
                {
                    n.Add(x);
                }
                if (typeProp.Count == 6)
                {
                    typeProp.Clear();
                }
                while (ok == false)
                {
                    ok = true;
                    for (int i = 0; i < typeProp.Count; i++)
                    {
                        if (n[y] == typeProp[i])
                        {
                            ok = false;
                            n.RemoveAt(y);
                            i = typeProp.Count + 45;
                        }
                    }
                    if (ok == false)
                    {
                        y = UnityEngine.Random.Range(0, n.Count);
                    }
                    else
                    {
                        a = n[y];
                        typeProp.Add(n[y]);
                    }
                }
                string s = "";
                string sq = "";
                if (a == 0)
                {
                    s = "DINHEIRO";
                    float q = UnityEngine.Random.Range(100 * ControlTime.curren.Year - 50, 100 * ControlTime.curren.Year + 50);
                    sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                    float quan = q + ControllerMoney.cont.Money;
                    ControllerMoney.cont.Money = quan;
                }
                else if (a == 1)
                {
                    s = "PESSOA";
                    int b = UnityEngine.Random.Range(1, 3);
                    sq = "+ " + b;
                    for (int i = 0; i < b; i++)
                    {
                        AddPerson();
                    }
                }
                else if (a == 2)
                {
                    s = "COMIDA";
                    float q = UnityEngine.Random.Range(20 * ControlTime.curren.Year - 5, 20 * ControlTime.curren.Year + 5);
                    food += q;
                    sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                    TextsFoodWaterUpdate();
                }
                else if (a == 3)
                {
                    s = "AGUA";
                    float q = UnityEngine.Random.Range(20 * ControlTime.curren.Year - 5, 20 * ControlTime.curren.Year + 5);
                    water += q;
                    sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                    TextsFoodWaterUpdate();
                }
                else if (a == 4)
                {
                    s = "MADEIRA";
                    float q = UnityEngine.Random.Range(10 * ControlTime.curren.Year - 5, 10 * ControlTime.curren.Year + 5);
                    madeira += q;
                    sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                }
                else if (a == 5)
                {
                    s = "PEDRA";
                    float q = UnityEngine.Random.Range(10 * ControlTime.curren.Year - 5, 10 * ControlTime.curren.Year + 5);
                    pedra += q;
                    sq = "+ " + (float)(Decimal.Round((decimal)q, 0));
                }
                propaganda.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = s;
                propaganda.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = sq;
                propaganda.transform.GetChild(1).gameObject.SetActive(true);
            }
            stopTime = true;
            propaganda.transform.GetChild(0).gameObject.SetActive(false);
            int d = UnityEngine.Random.Range(20, 100);
            if (ControlTime.curren.Day + d > 365)
            {
                ControlTime.curren.DayProp = (ControlTime.curren.Day + d) - 365;
            }
            else
            {
                ControlTime.curren.DayProp = ControlTime.curren.Day + d;
            }
        }
    }
    
}
