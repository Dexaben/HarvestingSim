using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class teascript : MonoBehaviour
{
    public bool toplanmadurum;
    int kullanma = 0;
    int kullanma1 = 0;
    int kullanma2 = 0;
    int kullanma3 = 0;
    int kullanma4 = 0;

    public envanteracma envanter;
    public GameObject env;


    //dısarıyla baglantılı*******************************
    public int hitcay;

    public Material[] material;
    Renderer rend;

    public void Start()
    {
        toplanmadurum = PlayerPrefs.GetInt(gameObject.name + "toplanmadurumu", 0) == 1;
        env = GameObject.FindGameObjectWithTag("envanter");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        envanter = env.GetComponent<envanteracma>();
        if (toplanmadurum == true)
        {
            hitcay = 0;
        }
        else if (toplanmadurum == false)
        {
            hitcay = 5;
        }
    }
    public void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("cayyenile"))
        {
            hitcay = 5;
        }
        if (CrossPlatformInputManager.GetButtonDown("Save"))
        {
            PlayerPrefs.SetInt(gameObject.name + "toplanmadurumu", toplanmadurum ? 1 : 0);
        }
        //hitcay kodu ***********************************************************
        if (hitcay == 5)
        {
            toplanmadurum = false;
            rend.sharedMaterial = material[0];
            kullanma = 0;
            kullanma1 = 0;
            kullanma2 = 0;
            kullanma3 = 0;
            kullanma4 = 0;
        }
        if (hitcay == 4)
        {
            while (kullanma1 < 1)
            {
                envanter.s_yaprak += 5;
                rend.sharedMaterial = material[1];
                kullanma1++;
            }
        }
        if (hitcay == 3)
        {
            while (kullanma2 < 1)
            {
                envanter.s_yaprak += 5;
                kullanma2++;
            }
        }
        if (hitcay == 2)
        {
            while (kullanma3 < 1)
            {
                envanter.s_yaprak += 5;
                rend.sharedMaterial = material[3];
                kullanma3++;
            }
        }
        if (hitcay == 1)
        {
            while (kullanma4 < 1)
            {
                envanter.s_yaprak += 5;
                kullanma4++;
            }
        }
        if (hitcay == 0)
        {
            while (kullanma < 1)
            {
                envanter.s_yaprak += 5;
                rend.sharedMaterial = material[4];
                toplanmadurum = true;
                kullanma++;
            }
        }
        if (hitcay < 0)
        {
            hitcay = 0;
        }
    }
}