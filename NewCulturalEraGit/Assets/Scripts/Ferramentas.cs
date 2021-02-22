using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ferramentas : MonoBehaviour
{
    public List<Sprite> imageFerramentas = new List<Sprite>();
    public string[] nameFerramentas = { "FACA", "ARCO E FLECHA", "BALDE", "MACHADO DE PEDRA", "LANÇA", "VARA DE PESCA 1", "MACHADO DE METAL", "VARA DE PESCA 2", "ESTRUTURA", "MACHADO DE FERRO", "VARA DE PESCA 3", "ENCHADA", "ARADO", "ESPADA", "ESPADA DO REI" };
    public List<int> quantidadeFerramenta = new List<int>();
    public List<int> ferramentasAtribuidas = new List<int>();
    public List<int> priceFerramenta = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        StartQuantPrices();
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartQuantPrices()
    {
        for(int i=0;i<15;i++)
        {
            quantidadeFerramenta.Add(0);
            ferramentasAtribuidas.Add(0);
        }
        priceFerramenta.Add(10);
        priceFerramenta.Add(10);
        priceFerramenta.Add(25);
        priceFerramenta.Add(50);
        priceFerramenta.Add(75);
        priceFerramenta.Add(100);
        priceFerramenta.Add(125);
        priceFerramenta.Add(150);
        priceFerramenta.Add(175);
        priceFerramenta.Add(200);
        priceFerramenta.Add(250);
        priceFerramenta.Add(300);
        priceFerramenta.Add(350);
        priceFerramenta.Add(400);
        priceFerramenta.Add(500);
        UpdateTexts();
    }
    private void UpdateTexts()
    {
        for (int i = 0; i < nameFerramentas.Length; i++)
        {
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).transform.GetChild(i).transform.GetChild(5).GetComponent<Text>().text = priceFerramenta[i].ToString();
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).transform.GetChild(i).transform.GetChild(7).GetComponent<Text>().text = quantidadeFerramenta[i].ToString();
        }
    }
    public void ClickBuy(GameObject go)
    {
        int a = go.transform.GetSiblingIndex();
        float b = Controller.current.Cort(priceFerramenta[a]);
        if (ControllerMoney.cont.GetMoney() >= b)
        {
            quantidadeFerramenta[a] += 1;
            ControllerMoney.cont.Money = ControllerMoney.cont.Money - priceFerramenta[a];
            int x = priceFerramenta[a] + ((a + 1) * quantidadeFerramenta[a]);
            priceFerramenta[a] = x;
            UpdateTexts();
        }
    }
}
