using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conquist : MonoBehaviour
{
    [SerializeField]
    private GameObject historyTela;
    [SerializeField]
    private GameObject terras;
    [SerializeField]
    private GameObject history;
    public List<County> myCounty = new List<County>();
    public List<County> county = new List<County>();
    public List<County> noCounty = new List<County>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCountys(string n)
    {
        //SUÉCIA - cultivo, mato , rio, pedra
        myCounty.Add(new County(0 , 100, 50, 2, 2, 3, 4, true, n));
        county.Add(new County(1 , 130, 65, 1, 3, 4, 4, false, "Malmo"));
        county.Add(new County(2 , 120, 55, 2, 2, 3, 5, false, "Uppsala"));
        county.Add(new County(3 , 125, 60, 1, 3, 3, 4, false, "Orebro"));
        county.Add(new County(4 , 140, 70, 2, 2, 4, 3, false, "Visby"));
        county.Add(new County(5 , 170, 80, 1, 1, 4, 3, false, "Lund"));
        county.Add(new County(6 , 80, 40, 1, 2, 3, 5, false, "Umea"));
        county.Add(new County(7 , 168, 80, 2, 1, 3, 4, false, "Karlskroma"));

        //DINAMARCA mato, pedra, cultivo, rio
        noCounty.Add(new County(8 , 200, 110, 1, 2, 4, 4, false, "Alborg"));
        noCounty.Add(new County(9 , 210, 110, 2, 1, 4, 4, false, "Roskilde"));

        //NORUEGA pedra, mato, rio, cultivo
        noCounty.Add(new County(10 , 180, 90, 3, 2, 5, 3, false, "Drammen"));
        noCounty.Add(new County(11 , 150, 70, 2, 3, 4, 3, false, "Kategunt"));
        noCounty.Add(new County(12 , 130, 55, 2, 3, 3, 5, false, "Kirkenes"));

        //INGLATERRA cultivo, mato, rio. pedra
        noCounty.Add(new County(13 , 300, 150, 5, 4, 3, 1, false, "York"));
        noCounty.Add(new County(14 , 230, 120, 4, 4, 3, 2, false, "Liberland"));
        noCounty.Add(new County(15 , 320, 155, 5, 5, 1, 1, false, "Oxônia"));
        noCounty.Add(new County(16 , 280, 140, 4, 3, 3, 2, false, "Bristol"));
        noCounty.Add(new County(17 , 200, 120, 5, 4, 2, 1, false, "Dover"));
        noCounty.Add(new County(18 , 160, 80, 5,5, 1, 1, false, "Coveryntsil"));
    }
    public void AddNewConquist(int cod)
    {
        for(int i=0;i<county.Count;i++)
        {
            if(county[i].Codigo==cod)
            {
                myCounty.Add(county[i]);
                MakeLote(county[i]);
                county.Remove(county[i]);
            }
        }
    }
    private void MakeLote(County c)
    {
        int a = myCounty.Count - 1;
        terras.transform.GetChild(1).transform.GetChild(0).transform.GetChild(a).transform.GetChild(1).GetComponent<Text>().text = c.Name;
    }
    public void StartTerras(string name)
    {
        terras.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = name;
    }
    public void ClickCounty(GameObject go)
    {
        int a = go.transform.GetSiblingIndex();
        if(myCounty.Count>a)
        {
            terras.transform.GetChild(2).transform.GetChild(2).transform.GetComponent<Text>().text = myCounty[a].Name;
            terras.transform.GetChild(2).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Population.ToString();
            terras.transform.GetChild(2).transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Comida.ToString();
            terras.transform.GetChild(2).transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Agua.ToString();
            terras.transform.GetChild(2).transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Madeira.ToString();
            terras.transform.GetChild(2).transform.GetChild(7).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Pedra.ToString();
            terras.transform.GetChild(2).transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Metal.ToString();
            terras.transform.GetChild(2).transform.GetChild(9).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Ferro.ToString();
            terras.transform.GetChild(2).transform.GetChild(10).transform.GetChild(0).GetComponent<Text>().text = myCounty[a].Aco.ToString();
        }
        terras.transform.GetChild(2).gameObject.SetActive(true);
    }

    //5 tipos de historia -> CONQUISTA DE CIDADE ; DESCOBERTA DE CIDADE ; NASCE O FILHO DO REI ; MORRE O REI ; TROCA DO TRONO
    // 1/1 - O DIA EM QUE MALMO FOI CONQUISTADA POR RAGNAR LOTDBROOK
    // 1/1 - FLOKI DESCOBRE UMA NOVA TERRA CHAMADA KARLSKROMA
    // 1/1 - NASCE BJORN O FILHO DE RAGNAR LODBROOK
    // 1/1 - MORRE O GRANDIOSO RAGNAR LODBROOK
    // 1/1 - O TRONO É PASSADO PARA BJORN LODBROOK. FILHO DE RAGNAR

    public void AddNewHistory(int i, int year, int day,string a, string b)
    {
        string sit = "";
        if(i==0)
        {
            sit = day + "/" + year + " - " + "O DIA EM QUE " + a + " FOI CONQUISTADA POR " + Kingdom.current.NameKing + " " + Kingdom.current.NameFamily;
        }
        else if(i==1)
        {
            sit = day + "/" + year + " - " + Kingdom.current.NameKing + " DESCOBRE UMA NOVA TERRA CHAMADA " + a;
        }
        else if (i == 2)
        {
            sit = day + "/" + year + " - " + "NASCE " + a + " O FILHO DE " + Kingdom.current.NameKing + " " + Kingdom.current.NameFamily;
        }
        else if (i == 3)
        {
            sit = day + "/" + year + " - " + "MORRE O GRANDIOSO " + Kingdom.current.NameKing + " " + Kingdom.current.NameFamily;
        }
        else if (i == 4)
        {
            sit = day + "/" + year + " - " + "O TRONO É PASSADO PARA " + Kingdom.current.NameKing + " " + Kingdom.current.NameFamily;
        }

    }
}
