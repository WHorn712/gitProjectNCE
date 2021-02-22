using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trabalhadores : MonoBehaviour
{
    public List<Sprite> imageFerramentas = new List<Sprite>();
    [SerializeField]
    private GameObject telaTrabalhador;
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
    private float[] prices = { 10, 25, 25, 100, 125, 150, 175, 200, 250, 300, 350, 400, 450, 500 };
    private GameObject lastClick;
    [SerializeField]
    private GameObject telaImageFerramenta;
    public GameObject ferramentaGameObject;
    private Ferramentas fer;

    public float GetProdWork(int c)
    {
        List<Person> b = GetWorkerNumber(c);
        float a = 0;
        for(int i=0;i<b.Count;i++)
        {
            a += b[i].hability.Prod;
        }
        if (b.Count > 0)
        {
            WorkReturnMoney(c, a);
        }
        return a;
    }
    private void WorkReturnMoney(int t,float prod)
    {
        float m = 0;
        if(t==1)
        {
            m = prod * 0.05f;
        }
        else if(t==2)
        {
            m = prod * 0.05f;
        }
        else if(t==3)
        {
            m = prod * 0.1f;
        }
        else if (t == 4)
        {
            m = prod * 0.12f;
        }
        else if (t == 5)
        {
            m = prod * 0.15f;
        }
        else if (t == 7)
        {
            m = prod * 0.2f;
        }
        else if (t == 8)
        {
            m = prod * 0.3f;
        }
        if(m<0.25f)
        {
            m = 0.25f;
        }
        float mo = ControllerMoney.cont.Money;
        ControllerMoney.cont.Money = mo + m;
    }

    // Start is called before the first frame update
    void Start()
    {
        fer = ferramentaGameObject.GetComponent<Ferramentas>();
        fer.StartQuantPrices();
        telaTextsTrabalhadores = transform.GetChild(0).transform.GetChild(8).transform.GetChild(0).gameObject;
        homensNoWork = 100;
        textHNW.text = homensNoWork.ToString();
        for(int i=0;i<14;i++)
        {
            telaTextsTrabalhadores.transform.GetChild(i).transform.GetChild(5).GetComponent<Text>().text = prices[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickFerramen()
    {
        for(int i=0;i<fer.quantidadeFerramenta.Count;i++)
        {
            ferramentaGameObject.transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).transform.GetChild(i).transform.GetChild(7).GetComponent<Text>().text = fer.quantidadeFerramenta[i].ToString();
        }
        ferramentaGameObject.SetActive(true);
    }
    private void AddWork(List<Person> a,int b,float c)
    {
        float conv = Controller.current.Cort(c);
        c = conv;
        if (ControllerMoney.cont.GetMoney() >= c)
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
                    ControllerMoney.cont.Money = ControllerMoney.cont.Money - c;
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
                    ControllerMoney.cont.Money = ControllerMoney.cont.Money - c;
                }
                else
                {
                    //exibi tela de mensagem
                }
            }
            else
            {
                AddWorkProcess(a, b, 0);
                ControllerMoney.cont.Money = ControllerMoney.cont.Money - c;
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
                    UpdateTextsPrices(a, b);
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
                    UpdateTextsPrices(a, b);
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
                    UpdateTextsPrices(a, b);
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
                    UpdatePower(ferreiro, 1, 0);
                    break;
                case 1:
                    AddWork(hunter,1,prices[1]);
                    UpdatePower(hunter, 0, 1);
                    break;
                case 2:
                    AddWork(coletorDeAgua,2,prices[2]);
                    UpdatePower(coletorDeAgua, 0, 2);
                    break;
                case 3:
                    AddWork(coletorDeMadeira,3, prices[3]);
                    UpdatePower(coletorDeMadeira, 0, 3);
                    break;
                case 4:
                    AddWork(coletorDePedra,4, prices[4]);
                    UpdatePower(coletorDePedra, 0, 4);
                    break;
                case 5:
                    AddWork(coletorDeMetal,5, prices[5]);
                    UpdatePower(coletorDeMetal, 0, 5);
                    break;
                case 6:
                    AddWork(enfermeira, 6, prices[6]);
                    UpdatePower(enfermeira, 1, 6);
                    break;
                case 7:
                    AddWork(pescador,7, prices[7]);
                    UpdatePower(pescador, 0, 7);
                    break;
                case 8:
                    AddWork(agricultor,8, prices[8]);
                    UpdatePower(agricultor, 0, 8);
                    break;
                case 9:
                    AddWork(navegador,9, prices[9]);
                    UpdatePower(navegador, 0, 9);
                    break;
                case 10:
                    AddWork(espiao,10, prices[10]);
                    UpdatePower(espiao, 0, 10);
                    break;
                case 11:
                    AddWork(mensageiro,11, prices[11]);
                    UpdatePower(mensageiro, 0, 11);
                    break;
                case 12:
                    AddWork(transportador,12, prices[12]);
                    UpdatePower(transportador, 0, 12);
                    break;
                case 13:
                    AddWork(berserker,13, prices[13]);
                    UpdatePower(berserker, 0, 13);
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
    private void UpdateTextsPrices(List<Person> a, int b)
    {
        float x = prices[b] + ((b + 1) * a.Count);
        prices[b] = x;
        telaTextsTrabalhadores.transform.GetChild(b).transform.GetChild(5).GetComponent<Text>().text = prices[b].ToString();
    }
    private void UpdatePower(List<Person> pop, int type,int x)
    {
        float soma = 0;
        if (type == 0)
        {
            for (int i = 0; i < pop.Count; i++)
            {
                soma += pop[i].hability.Prod;
            }
            transform.GetChild(0).transform.GetChild(8).transform.GetChild(0).transform.GetChild(x).transform.GetChild(7).GetComponent<Text>().text = soma.ToString();
        }
        else
        {
            int day = 0;
            if(x==0)
            {
                day = 84;
            }
            else if(x==6)
            {
                day = 120;
            }
            for(int i=0;i<pop.Count;i++)
            {
                day -= (int)(pop[i].hability.Prod);
            }
            if(day<2)
            {
                day = 2;
            }
            transform.GetChild(0).transform.GetChild(8).transform.GetChild(0).transform.GetChild(x).transform.GetChild(7).GetComponent<Text>().text = day.ToString();
        }
    }

    private string SituationPowerWorker(int a)
    {
        string b = "";
        switch (a)
        {
            case 0:
                b = "DIAS PARA TERMINAR UMA FERRAMENTA";
                break;
            case 1:
                b = "QUANTIDADE DE COMIDA ADQUIRIDA POR DIA";
                break;
            case 2:
                b = "QUANTIDADE DE ÁGUA ADQUIRIDA POR DIA";
                break;
            case 3:
                b = "QUANTIDADE DE MADEIRA ADQUIRIDA POR DIA";
                break;
            case 4:
                b = "QUANTIDADE DE PEDRA ADQUIRIDA POR DIA";
                break;
            case 5:
                b = "QUANTIDADE DE METAL ADQUIRIDA POR DIA";
                break;
            case 6:
                b = "DIAS PARA RECUPERAR TODOS OS FERIDOS";
                break;
            case 7:
                b = "QUANTIDADE DE COMIDA ADQUIRIDA POR DIA";
                break;
            case 8:
                b = "QUANTIDADE DE COMIDA ADQUIRIDA POR DIA";
                break;
            case 9:
                b = "PORCENTAGEM DE UMA VIAJEM SER REALIZADA COM SUCESSO";
                break;
            case 10:
                b = "PORCENTAGEM DE UMA ESPIONAGEM SER REALIZADA COM SUCESSO";
                break;
            case 11:
                b = "PORCENTAGEM DE UMA MENSAGEM SER ENTREGUE COM SUCESSO";
                break;
            case 12:
                b = "PORCENTAGEM DE UMA CARGA SER ENTREGUE COM SUCESSO";
                break;
            case 13:
                b = "PORCENTAGEM ADICIONADA PARA A PRÓXIMA BATALHA";
                break;
        }
        return b;
    }
    public void ClickWorker(GameObject go)
    {
        int a = go.transform.GetSiblingIndex();
        telaTrabalhador.SetActive(true);
        telaTrabalhador.transform.GetChild(3).GetComponent<Text>().text = go.transform.GetChild(2).GetComponent<Text>().text;
        telaTrabalhador.transform.GetChild(6).GetComponent<Text>().text = SituationPowerWorker(a);
        telaTrabalhador.transform.GetChild(2).GetComponent<Image>().sprite = go.transform.GetChild(1).GetComponent<Image>().sprite;
        telaTrabalhador.transform.GetChild(7).GetComponent<Text>().text = "X "+go.transform.GetChild(9).GetComponent<Text>().text;
        int b = (GetWorkerNumber(a)).Count;
        if(a!=0&&b>0)
        {
            telaTrabalhador.transform.GetChild(8).gameObject.SetActive(true);
            telaTrabalhador.transform.GetChild(9).gameObject.SetActive(true);
        }
        else
        {
            telaTrabalhador.transform.GetChild(8).gameObject.SetActive(false);
            telaTrabalhador.transform.GetChild(9).gameObject.SetActive(false);
        }
        lastClick = go;
    }
    public void CloseWorker(GameObject go)
    {
        go.SetActive(false);
    }

    public void ClickTelaFerramenta()
    {
        telaImageFerramenta.transform.GetChild(1).GetComponent<Text>().text = lastClick.transform.GetChild(2).GetComponent<Text>().text;
        UpdateTextQuantTelaImage(lastClick.transform.GetSiblingIndex());
        StartBottons(lastClick.transform.GetSiblingIndex());
        telaImageFerramenta.SetActive(true);
    }

    private void UpdateTextQuantTelaImage(int a)
    {
        List<Person> wor = GetWorkerNumber(a);
        int b = 0; 
        for (int i = 0; i < wor.Count; i++)
        {
            if (wor[i].hability.NoFer)
            {
                b++;
            }
        }
        telaImageFerramenta.transform.GetChild(2).GetComponent<Text>().text = b.ToString();
    }
    private void UpdateQuantidadeFerDisponiveis(int a,int b)
    {
        int c = fer.quantidadeFerramenta[a] - fer.ferramentasAtribuidas[a];
        telaImageFerramenta.transform.GetChild(b).transform.GetChild(2).GetComponent<Text>().text = "X " + c.ToString();
    }

    private void AutomaticlyBUttonFer(List<Person> wor,int type)
    {
        if (type == 0)
        {
            telaImageFerramenta.transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            telaImageFerramenta.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = fer.nameFerramentas[wor[0].hability.Fer1];
            telaImageFerramenta.transform.GetChild(3).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = imageFerramentas[wor[0].hability.Fer1];
            UpdateQuantidadeFerDisponiveis(wor[0].hability.Fer1,3);
            MakeSizeImage(3,wor[0].hability.Fer1);
        }
        else if(type==1)
        {
            telaImageFerramenta.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            telaImageFerramenta.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = fer.nameFerramentas[wor[0].hability.Fer2];
            telaImageFerramenta.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = imageFerramentas[wor[0].hability.Fer2];
            UpdateQuantidadeFerDisponiveis(wor[0].hability.Fer2,4);
            MakeSizeImage(4, wor[0].hability.Fer2);
        }
        else if(type==2)
        {
            telaImageFerramenta.transform.GetChild(5).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            telaImageFerramenta.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = fer.nameFerramentas[wor[0].hability.Fer3];
            telaImageFerramenta.transform.GetChild(5).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = imageFerramentas[wor[0].hability.Fer3];
            UpdateQuantidadeFerDisponiveis(wor[0].hability.Fer3,5);
            MakeSizeImage(5, wor[0].hability.Fer3);
        }
        else if(type==3)
        {
            telaImageFerramenta.transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            telaImageFerramenta.transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = fer.nameFerramentas[wor[0].hability.Fer4];
            telaImageFerramenta.transform.GetChild(6).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = imageFerramentas[wor[0].hability.Fer4];
            UpdateQuantidadeFerDisponiveis(wor[0].hability.Fer4,6);
            MakeSizeImage(6, wor[0].hability.Fer4);
        }
    }
    private void MakeEmptyLote(int size)
    {
        int a = 4 - size;
        if(a>0)
        {
            for(int i=6;i>(6-a);i--)
            {
                telaImageFerramenta.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = "";
                telaImageFerramenta.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = "";
                telaImageFerramenta.transform.GetChild(i).transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    private void MakeSizeImage(int a,int b)
    {
        if (b == 4)
        {
            telaImageFerramenta.transform.GetChild(a).transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(18, telaImageFerramenta.transform.GetChild(a).transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y);
        }
        else
        {
            telaImageFerramenta.transform.GetChild(a).transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(-54.57f, telaImageFerramenta.transform.GetChild(a).transform.GetChild(1).transform.GetChild(0).GetComponent<RectTransform>().offsetMin.y);
        }
    }
    private void StartBottons(int a)
    {
        List<Person> wor = GetWorkerNumber(a);
        if(wor[0].hability.FerAtrib==1)
        {
            AutomaticlyBUttonFer(wor, 0);
        }
        else if(wor[0].hability.FerAtrib == 2)
        {
            AutomaticlyBUttonFer(wor, 0);
            AutomaticlyBUttonFer(wor, 1);
        }
        else if (wor[0].hability.FerAtrib == 3)
        {
            AutomaticlyBUttonFer(wor, 0);
            AutomaticlyBUttonFer(wor, 1);
            AutomaticlyBUttonFer(wor, 2);
        }
        else if (wor[0].hability.FerAtrib == 4)
        {
            AutomaticlyBUttonFer(wor, 0);
            AutomaticlyBUttonFer(wor, 1);
            AutomaticlyBUttonFer(wor, 2);
            AutomaticlyBUttonFer(wor, 3);
        }
        MakeEmptyLote(wor[0].hability.FerAtrib);
    }

    private List<Person> GetWorkerNumber(int a)
    {
        switch(a)
        {
            case 0:
                return ferreiro;
            case 1:
                return hunter;
            case 2:
                return coletorDeAgua;
            case 3:
                return coletorDeMadeira;
            case 4:
                return coletorDePedra;
            case 5:
                return coletorDeMetal;
            case 6:
                return enfermeira;
            case 7:
                return pescador;
            case 8:
                return agricultor;
            case 9:
                return navegador;
            case 10:
                return espiao;
            case 11:
                return mensageiro;
            case 12:
                return transportador;
            default:
                return berserker;
        }
    }

    public void ClickAddFerramenta(GameObject go)
    {
        int a = go.transform.GetSiblingIndex();
        if (go.transform.GetChild(0).GetComponent<Text>().text != "")
        {
            if (a == 3)
            {
                ProcessAddFer(0);
            }
            else if (a == 4)
            {
                ProcessAddFer(1);
            }
            else if (a == 5)
            {
                ProcessAddFer(2);
            }
            else if (a == 6)
            {
                ProcessAddFer(3);
            }
        }
        UpdateTextQuantTelaImage(lastClick.transform.GetSiblingIndex());
    }
    private void LassoForAtrib(List<Person> a,int b)
    {
        int c = b + 3;
        for(int i=0;i<a.Count;i++)
        {
            if(a[i].hability.NoFer)
            {
                if (fer.quantidadeFerramenta[a[i].hability.GetCodeFerramenta(b)] - fer.ferramentasAtribuidas[a[i].hability.GetCodeFerramenta(b)] > 0)
                {
                    a[i].hability.AtribuindoFerramenta(b);
                    fer.ferramentasAtribuidas[a[i].hability.CodFerramentaAct] += 1;
                    UpdateQuantidadeFerDisponiveis(a[i].hability.CodFerramentaAct, c);
                    int x = lastClick.transform.GetSiblingIndex();
                    if (x == 0 || x == 6)
                    {
                        UpdatePower(a, 1, x);
                    }
                    else
                    {
                        UpdatePower(a, 0, x);
                    }
                    i = a.Count + 7;
                }
            }
        }
    }
    private void ProcessAddFer(int i)
    {
        List<Person> wor = GetWorkerNumber(lastClick.transform.GetSiblingIndex());
        LassoForAtrib(wor, i);
    }

    public void ClickRemoveFer()
    {
        List<Person> wor = GetWorkerNumber(lastClick.transform.GetSiblingIndex());
        for(int i=0;i<wor.Count;i++)
        {
            if(wor[i].hability.NoFer==false)
            {
                int a = wor[i].hability.GetPositionFer(wor[i].hability.CodFerramentaAct);
                int c = wor[i].hability.CodFerramentaAct;
                wor[i].RemovingFerramenta();
                fer.ferramentasAtribuidas[c] -= 1;
                UpdateQuantidadeFerDisponiveis(c, a);
                UpdateTextQuantTelaImage(lastClick.transform.GetSiblingIndex());
                i = wor.Count + 41;
            }
        }
    }
}
