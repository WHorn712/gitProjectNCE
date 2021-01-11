using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlTime : MonoBehaviour
{
    public static ControlTime curren;
    private int anoCurrent;
    private int dayCurrent;
    public Text ano;
    public Text dia;
    public float TimeSpeed;
    private float timecontrol;
    private List<int> dateBorn = new List<int>();
    private int nextBorn;
    private void Awake()
    {
        curren = this;
        TimeSpeed = 0.1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        timecontrol = 0;
        anoCurrent = 1;
        dayCurrent = 1;
        dia.text = "DIA: " + dayCurrent.ToString();
        ano.text = "ANO: " + anoCurrent.ToString();
        time = 0;
        ct = 4;
        timen = 0;
        ctn = 2;
    }
    float time;
    float ct;
    float timen;
    float ctn;

    // Update is called once per frame
    void Update()
    {
        if(!Controller.current.STOPTIME)
        {
            timecontrol += Time.deltaTime;
            if(timecontrol>=1/TimeSpeed)
            {
                timecontrol = 0;
                dayCurrent++;
                dia.text = "DIA: " + dayCurrent.ToString();
                AnaliseBorn(dayCurrent);
                Controller.current.PopulationEating();
            }
            if(dayCurrent==366)
            {
                anoCurrent++;
                ano.text = "ANO: " + anoCurrent.ToString();
                dayCurrent = 1;
                dia.text = "DIA: " + dayCurrent.ToString();
                dateBorn.Clear();
                SortBorn();
            }
        }
    }
    public int Day
    {
        get
        {
            return dayCurrent;
        }
        set
        {
            dayCurrent = value;
            dia.text = "DIA: " + dayCurrent.ToString();
        }
    }
    public int Year
    {
        get
        {
            return anoCurrent;
        }
        set
        {
            anoCurrent = value;
            ano.text = "ANO: " + anoCurrent.ToString();
        }
    }
    public void Click1x()
    {
        if (!Controller.current.STOPTIME)
        {
            TimeSpeed = 0.1f;
        }
    }
    public void Click2x()
    {
        if (!Controller.current.STOPTIME)
        {
            TimeSpeed = 0.6f;
        }
    }
    public void Click3x()
    {
        if (!Controller.current.STOPTIME)
        {
            TimeSpeed = 60;
        }
    }
    private void SortBorn()
    {
        int cont=0;
        for(int i=0; i<Controller.current.population.Count;i++)
        {
            if(Controller.current.population[i].Sexo=='F'&&Controller.current.population[i].Idade>=17&&Controller.current.population[i].QuantSon>0)
            {
                cont++;
            }
        }
        int min = cont/10;
        int max = cont/2;
        cont = Random.Range(min, max);
        for(int i=0;i<cont;i++)
        {
            dateBorn.Add(Random.Range(3, 364));
        }
    }
    private void Born()
    {
        bool ok = false;
        while(!ok)
        {
            for (int p = 0; p < Controller.current.population.Count; p++)
            {
                if (Controller.current.population[p].Sexo == 'F' && Controller.current.population[p].Idade >= 17 && Controller.current.population[p].QuantSon > 0)
                {
                    ok = true;
                    Controller.current.population[p].QuantSon -= 1;
                    p = Controller.current.population.Count + 234;
                }
            }
        }
        if (ok)
        {
            int s = Random.Range(0, 100);
            if (s >= 40)
            {
                Controller.current.population.Add(new Person('M', 0, Controller.current.RegistroGeral));
            }
            else
            {
                Controller.current.population.Add(new Person('F', 0, Controller.current.RegistroGeral));
            }
            Controller.current.RegistroGeral += 1;
        }
    }
    private void AnaliseBorn(int day)
    {
        for(int i=0;i<dateBorn.Count;i++)
        {
            if(dateBorn[i]==day)
            {
                Born();
            }
        }
    }
}
