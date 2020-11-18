using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsButtons : MonoBehaviour
{
    public void ClickOnButtonStart(int a)
    {
        AudioSource aud = this.GetComponent<AudioSource>();
        aud.Play();
        if (a==0)
        {
            Debug.Log("Start");
        }
        else if(a==1)
        {
            Debug.Log("Option");
        }
        else if(a==2)
        {
            Debug.Log("progresso");
        }
    }

}
