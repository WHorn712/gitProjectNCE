using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionSocial : MonoBehaviour
{
    private int position;
    [SerializeField]
    private List<Sprite> imagesPositionSocial = new List<Sprite>();
    [SerializeField]
    private List<string> textsPositionSocial = new List<string>();

    private void Start()
    {
        position = 0;
    }
    public int getPosition()
    {
        return position;
    }
    public void setPosition(int pos)
    {
        position = pos;
    }
    public void InitiateImagesPositionSocial(int s)
    {
        if (s == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = imagesPositionSocial[i];
                if (i == 0)
                {
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = textsPositionSocial[i];
                }
                else
                {
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = textsPositionSocial[i];
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
        else if (s == 1)
        {
            int a = 0;
            for (int i = 4; i < 8; i++)
            {
                transform.GetChild(1).transform.GetChild(0).transform.GetChild(a).transform.GetChild(0).GetComponent<Image>().sprite = imagesPositionSocial[i];
                if (i == 4)
                {
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(a).transform.GetChild(1).GetComponent<Text>().text = textsPositionSocial[i];
                }
                else
                {
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(a).transform.GetChild(2).GetComponent<Text>().text = textsPositionSocial[i];
                    transform.GetChild(1).transform.GetChild(0).transform.GetChild(a).transform.GetChild(2).gameObject.SetActive(false);
                }
                a++;
            }
        }
        //DesblokPositionSocial(1);
    }
    public void DesblokPositionSocial(int i)
    {
        transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        Destroy(transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(1).gameObject);
        transform.GetChild(1).transform.GetChild(0).transform.GetChild(i - 1).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.21f);
        transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(true);
    }
}
