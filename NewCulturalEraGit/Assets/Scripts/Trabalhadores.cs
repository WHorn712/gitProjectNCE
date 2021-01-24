using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trabalhadores : MonoBehaviour
{
    private int homensNoWork;
    [SerializeField]
    private Text textHNW;
    public List<Person> ferreiro = new List<Person>();
    public List<Person> hunter = new List<Person>();
    public List<Person> coletorDeAgua = new List<Person>();
    public List<Person> coletorDeMadeira = new List<Person>();
    public List<Person> coletorDePedra = new List<Person>();
    public List<Person> coletorDeMetal = new List<Person>();
    public List<Person> pescador = new List<Person>();
    public List<Person> agricultor = new List<Person>();
    public List<Person> navegador = new List<Person>();
    public List<Person> espiao = new List<Person>();
    public List<Person> mensageiro = new List<Person>();
    public List<Person> transportador = new List<Person>();
    public List<Person> berserker = new List<Person>();

    // Start is called before the first frame update
    void Start()
    {
        homensNoWork = 50;
        textHNW.text = homensNoWork.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddWork(List<Person> a)
    {
        for(int i=0;i<Controller.current.population.Count;i++)
        {
            if(Controller.current.population[i].Sexo=='M'&&Controller.current.population[i].Idade>=17&&Controller.current.population[i].hability.NoFuncao)
            {
                a.Add(Controller.current.population[i]);
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
                    AddWork(ferreiro);
                    break;
                case 1:
                    AddWork(hunter);
                    break;
                case 2:
                    AddWork(coletorDeAgua);
                    break;
                case 3:
                    AddWork(coletorDeMadeira);
                    break;
                case 4:
                    AddWork(coletorDePedra);
                    break;
                case 5:
                    AddWork(coletorDeMetal);
                    break;
                case 6:
                    AddWork(pescador);
                    break;
                case 7:
                    AddWork(agricultor);
                    break;
                case 8:
                    AddWork(navegador);
                    break;
                case 9:
                    AddWork(espiao);
                    break;
                case 10:
                    AddWork(mensageiro);
                    break;
                case 11:
                    AddWork(transportador);
                    break;
                case 12:
                    AddWork(berserker);
                    break;
            }
            homensNoWork--;
        }
    }

}
