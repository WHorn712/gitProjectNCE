using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject dados;
    public static Controller current;
    public List<Person> population = new List<Person>();
    private int registroGeral;
    private bool stopTime;
    [SerializeField]
    private Text textPopulation;
    private float food;
    private float water;
    private Conquist conquist;
    private void ItiateVar()
    {
        food = 0;
        water = 0;
    }
    public Conquist Counquist
    {
        get
        {
            return conquist;
        }
    }
    private void Awake()
    {
        stopTime = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        conquist = dados.GetComponent<Conquist>();
        ItiateVar();
        current = this;
        StartPopulation();
    }

    // Update is called once per frame
    void Update()
    {
        textPopulation.text = population.Count.ToString();
        int con=0;
        for(int i=0;i<population.Count;i++)
        {
            if(population[i].Idade>=17)
            {
                con += population[i].QuantSon;
            }
        }
    }

    public void InitiatePositionSocial(int s)
    {
        PositionSocial ps = GameObject.Find("Canvas").transform.GetChild(10).transform.GetChild(5).GetComponent<PositionSocial>();
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
                population.Add(new Person('M', Random.Range(20, 30), i));
            }
            else
            {
                population.Add(new Person('F', Random.Range(20, 30), i));
            }
            registroGeral = i;
        }
    }
    public void PopulationEating()
    {
        float a = population.Count * 0.5f;
        float b = population.Count * 0.1f;
        food -= a;
        water -= b;
        if(food<0)
        {
            food = 0;
            Debug.Log("FOME");
        }
        if(water<0)
        {
            water = 0;
            Debug.Log("SEDE");
        }
    }
}
