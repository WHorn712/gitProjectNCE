using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Situation : MonoBehaviour
{
    [SerializeField]
    private GameObject telaInf;
    private int timeCallInf;
    [SerializeField]
    private GameObject telaNP;
    private int dayNewPeople = 0;
    private int dayInfluenciador = 0;
    private GameObject tela;
    private GameObject load;
    private GameObject telaInterrogatorio;
    private bool isLoad;
    private Person p;
    [SerializeField]
    private GameObject dadosGO;
    // Start is called before the first frame update
    void Start()
    {
        timeCallInf = 0;
        isLoad = false;
        tela = telaNP.transform.GetChild(0).gameObject;
        load = telaNP.transform.GetChild(1).gameObject;
        telaInterrogatorio = telaNP.transform.GetChild(2).gameObject;
        dayNewPeople = Random.Range(10, 150);
        SorDayInflu();
    }
    float time = 0;
    float time2 = 0;
    // Update is called once per frame
    void Update()
    {
        Analize();
        if(isLoad)
        {
            Ativing(1);
            time += Time.deltaTime;
            if(time>0.5f)
            {
                load.transform.GetChild(0).GetComponent<Text>().text = MakeStringLoad(load.transform.GetChild(0).GetComponent<Text>().text);
                time = 0;
            }
            time2 += Time.deltaTime;
            if(time2>6)
            {
                time2 = 0;
                isLoad = false;
                Ativing(2);
            }
        }
    }
    private void Ativing(int a)
    {
        if(a==0)
        {
            tela.SetActive(true);
            load.SetActive(false);
            telaInterrogatorio.SetActive(false);
        }
        else if(a==1)
        {
            tela.SetActive(false);
            load.SetActive(true);
            telaInterrogatorio.SetActive(false);
        }
        else if(a==2)
        {
            tela.SetActive(false);
            load.SetActive(false);
            telaInterrogatorio.SetActive(true);
            float c = Random.Range(0, 100);
            if(c>50)
            {
                int idade = Random.Range(20, 60);
                p = new Person('M', idade, Controller.current.RegistroGeral);
                telaInterrogatorio.transform.GetChild(2).GetComponent<Text>().text = "HOMEM";
                telaInterrogatorio.transform.GetChild(4).GetComponent<Text>().text = idade.ToString();
            }
            else
            {
                int idade = Random.Range(20, 60);
                p = new Person('M', idade, Controller.current.RegistroGeral);
                telaInterrogatorio.transform.GetChild(2).GetComponent<Text>().text = "MULHER";
                telaInterrogatorio.transform.GetChild(4).GetComponent<Text>().text = idade.ToString();
            }
            DecidEspião();
        }
    }
    private void DecidEspião()
    {
        float c = Random.Range(0, 100);
        string a = "";
        int font = 0;
        if(c<30)
        {
            font = 50;
            a = "NADA";

        }
        else if(c>=30&&c<=60)
        {
            font = 50;
            a = "ESPIÃO";
            telaInterrogatorio.transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            font = 33;
            Conquist con= dadosGO.GetComponent<Conquist>();
            a = "ESPIÃO DE " + con.county[Random.Range(0, con.county.Count)].Name;
            telaInterrogatorio.transform.GetChild(7).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        telaInterrogatorio.transform.GetChild(6).GetComponent<Text>().text = a;
        telaInterrogatorio.transform.GetChild(6).GetComponent<Text>().fontSize = font; 
    }
    private string MakeStringLoad(string a)
    {
        if(a==".")
        {
            return "..";
        }
        else if(a=="..")
        {
            return "...";
        }
        else if(a=="...")
        {
            return ".";
        }
        else
        {
            return ".";
        }
    }
    private void Analize()
    {
        AnalizeDayNewPeople();
        AnalizeDayInflu();
    }
    private void AnalizeDayNewPeople()
    {
        if (ControlTime.curren.Day == dayNewPeople)
        {
            telaNP.SetActive(true);
            Ativing(0);
            Controller.current.STOPTIME = true;
            SorDayNewPeople();
        }
    }
    private void AnalizeDayInflu()
    {
        if(ControlTime.curren.Day==dayInfluenciador)
        {
            MakeTexts();
            telaInf.SetActive(true);
            Controller.current.STOPTIME = true;
            SorDayInflu();
        }
    }
    private void MakeTexts()
    {
        string t = "";
        int chance = 0;
        if(timeCallInf==0)
        {
            chance = Random.Range(1, 10);
            t = "BOATOS QUE UM INFLUENCIADOR ESTÁ COLOCANDO AS PESSOAS CONTRA VOCÊ.";
        }
        else if(timeCallInf==1)
        {
            chance = Random.Range(11, 30);
            t = "O INFLUENCIADOR ESTÁ JUNTANDO MAIS PESSOAS PARA UMA REVOLUÇÃO.";
        }
        else if (timeCallInf == 2)
        {
            chance = Random.Range(31, 40);
            t = "QUANTO MAIS ESPERAR MENOS CHANCE DE RECUPERAR TERÁ.";
        }
        else if (timeCallInf == 3)
        {
            chance = Random.Range(41, 70);
            t = "O INFLUENCIADOR JUNTOU UM BOM NÚMERO DE PESSOAS. TOME UMA DECISÃO.";
        }
        else
        {
            //GAMEOVER
        }
        telaInf.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = t;
        telaInf.transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).GetComponent<Text>().text = chance.ToString();
    }

    public void KillInf()
    {
        telaInf.SetActive(false);
        Controller.current.STOPTIME = false;
        if(timeCallInf==0)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range(1f, 5f);
            ControllerDados.controllerDados.Respeito = ControllerDados.controllerDados.Respeito + Random.Range(1f, 5f);
        }
        else if(timeCallInf<4)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range((5f*timeCallInf), (5f*(timeCallInf+1)));
            ControllerDados.controllerDados.Respeito = ControllerDados.controllerDados.Respeito + Random.Range((5f * timeCallInf), (5f * (timeCallInf + 1)));
        }
        timeCallInf++;
    }
    public void Expuls()
    {
        telaInf.SetActive(false);
        Controller.current.STOPTIME = false;
        if (timeCallInf == 0)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range(1f, 3f);
        }
        else if (timeCallInf == 1)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range(3f, 6f);
        }
        else if (timeCallInf == 2)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range(6f, 9f);
        }
        else if (timeCallInf == 3)
        {
            ControllerDados.controllerDados.Insatisation = ControllerDados.controllerDados.Insatisation + Random.Range(9f, 12f);
        }
        timeCallInf++;
    }
    public void MakeNothing()
    {
        telaInf.SetActive(false);
        Controller.current.STOPTIME = false;
        if (timeCallInf == 0)
        {
            ControllerDados.controllerDados.Respeito = ControllerDados.controllerDados.Respeito - Random.Range(1f, 3f);
        }
        else if (timeCallInf < 4)
        {
            ControllerDados.controllerDados.Respeito = ControllerDados.controllerDados.Respeito - Random.Range((3f * timeCallInf), (3f * (timeCallInf + 1)));
        }
        timeCallInf++;
    }

    public void AcceptPerson()
    {
        if(ControllerDados.controllerDados.Relacao<70)
        {
            float a = Random.Range(0, 100);
            float b = 50 + ControllerDados.controllerDados.Relacao;
            if (a <= b)
            {
                //não ser espi
                Debug.Log("PESSOA");
                Controller.current.AddPerson();
            }
            else
            {
                //ser espi
                Debug.Log("ESPIÃO");
                ControllerDados.controllerDados.Relacao = ControllerDados.controllerDados.Relacao + Random.Range(0.1f,1);
            }
        }
        telaNP.SetActive(false);
        Controller.current.STOPTIME = false;
    }
    public void RecusePerson()
    {
        telaNP.SetActive(false);
        Controller.current.STOPTIME = false;
    }
    public void InterrogationBT()
    {
        isLoad = true;
    }

    public void Accept()
    {
        if(telaInterrogatorio.transform.GetChild(7).GetComponent<Image>().color.a==1)
        {
            Controller.current.population.Add(p);
        }
        telaNP.SetActive(false);
        Controller.current.STOPTIME = false;
    }
    public void Kill()
    {
        float a = Random.Range(0.1f,1);
        float b = Random.Range(0.1f, 1);
        Debug.Log("Respeito: " + a + "     /      Insatisfação: " + b);
        ControllerDados.controllerDados.Respeito += a;
        ControllerDados.controllerDados.Insatisation += b;
        telaNP.SetActive(false);
        Controller.current.STOPTIME = false;
    }


    private void SorDayNewPeople()
    {
        bool ok = false;
        while (!ok)
        {
            int x = ControlTime.curren.Day + (Random.Range(75, 180));
            if(x>365)
            {
                dayNewPeople = x - 365;
            }
            else
            {
                dayNewPeople = x;
            }
            ok = GetVar();
        }
    }
    private void SorDayInflu()
    {
        bool ok = false;
        while (!ok)
        {
            int x = ControlTime.curren.Day + (Random.Range(10, 180));
            if (x > 365)
            {
                dayInfluenciador = x - 365;
            }
            else
            {
                dayInfluenciador = x;
            }
            ok = GetVar();
        }
    }
    private bool GetVar()
    {
        bool ok = true;
        if(dayInfluenciador==dayNewPeople)
        {
            ok = false;
        }
        return ok;
    }
}
