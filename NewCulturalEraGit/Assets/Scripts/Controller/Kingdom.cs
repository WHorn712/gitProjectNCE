using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kingdom : MonoBehaviour
{
    public static Kingdom current;
    private string nameKing;
    private string nameKingdom;
    private string nameFamily;
    private char sexo;
    [SerializeField]
    private Image backGround;
    [SerializeField]
    private GameObject choice;
    [SerializeField]
    private GameObject coinGameObject;
    [SerializeField]
    private GameObject timeButtons;
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private GameObject time;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        backGround.gameObject.SetActive(true);
        Attiving(false);
    }
    private void Attiving(bool isactiv)
    {
        time.gameObject.SetActive(isactiv);
        coinGameObject.SetActive(isactiv);
        timeButtons.SetActive(isactiv);
        buttons.SetActive(isactiv);
        choice.SetActive(!isactiv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChoiceSexo(GameObject go)
    {
        if(go.layer==8)
        {
            sexo = 'M';
        }
        else if(go.layer==9)
        {
            sexo = 'F';
        }
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
    }
    public void ClickOKName(GameObject go)
    {
        nameKing = DigitNames(go);
        if(nameKing.Length>0)
        {
            go.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    public void ClickOKNameKingdom(GameObject go)
    {
        nameKingdom = DigitNames(go);
        if (nameKingdom.Length>0)
        {
            go.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
        }
    }
    public void ClickOKNameFamily(GameObject go)
    {
        nameFamily = DigitNames(go);
        if (nameFamily.Length>0)
        {
            Debug.Log(nameKing);
            Debug.Log(nameKingdom);
            Debug.Log(nameFamily);
        }
        go.SetActive(false);
        backGround.gameObject.SetActive(false);
        Attiving(true);
    }
    public void ClickMainButton(GameObject go)
    {
        if(go.transform.GetChild(0).gameObject.activeSelf)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(false);
            go.transform.GetChild(2).gameObject.SetActive(false);
            go.transform.GetChild(5).gameObject.SetActive(false);
        }
        else
        {
            go.transform.GetChild(0).gameObject.SetActive(true);
            go.transform.GetChild(1).gameObject.SetActive(true);
            go.transform.GetChild(2).gameObject.SetActive(true);
            go.transform.GetChild(5).gameObject.SetActive(true);
        }
    }
    public void ClickCollection(GameObject go)
    {
        go.SetActive(true);
        if(go.transform.GetChild(1).GetComponent<Image>().color.Equals(go.transform.GetChild(2).GetComponent<Image>().color))
        {
            ClickCollectionButtons(go, 0);
        }
    }
    public void ClickDesafioButton(GameObject go)
    {
        ClickCollectionButtons(go, 0);
    }
    public void ClickPositionSocial(GameObject go)
    {
        ClickCollectionButtons(go, 1);
    }
    public void ClickCloseCollection(GameObject go)
    {
        go.SetActive(false);
    }


    private void ClickCollectionButtons(GameObject go, int i)
    {
        if (i == 0)
        {
            go.transform.GetChild(1).GetComponent<Image>().color = new Color(0.52f, 0.49f, 0.47f, 1f);
            go.transform.GetChild(2).GetComponent<Image>().color = new Color(0.18f, 0.16f, 0.15f, 1f);
            go.transform.GetChild(3).gameObject.SetActive(true);
            go.transform.GetChild(4).gameObject.SetActive(false);
        }
        else
        {
            go.transform.GetChild(2).GetComponent<Image>().color = new Color(0.52f, 0.49f, 0.47f, 1f);
            go.transform.GetChild(1).GetComponent<Image>().color = new Color(0.18f, 0.16f, 0.15f, 1f);
            go.transform.GetChild(3).gameObject.SetActive(false);
            go.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    private string DigitNames(GameObject go)
    {
        string name = go.transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text;
        if (!isNumbers(name) && name.Length > 0)
        {
            return name;
        }
        else
        {
            string b = "";
            if (name.Length > 0)
            {
                b = "DEVE CONTER APENAS LETRAS";
            }
            else if (name.Length == 0)
            {
                b = "INVÁLIDO";
            }
            go.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().text = b;
            go.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            return "";
        }
    }
    private bool isNumbers(string t)
    {
        bool ok = false;
        for(int i=0;i<t.Length;i++)
        {
            for(int c=0;c<10;c++)
            {
                if(t[i].ToString()==c.ToString())
                {
                    ok = true;
                    c = 11;
                    i = t.Length + 5;
                }
            }
        }
        return ok;
    }
}
