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
    // Start is called before the first frame update
    void Start()
    {
        current = this;
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
        Debug.Log(sexo);
    }
    public void ClickOKName(GameObject go)
    {
        string name = go.transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text;
        if(!isNumbers(name)&&name.Length>0)
        {
            nameKing = name;

        }
        else if(name.Length>0)
        {

        }
        else if(name.Length==0)
        {

        }
    }
    public void ClickOKNameKingdom()
    {

    }
    public void ClickOKNameFamily()
    {

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
