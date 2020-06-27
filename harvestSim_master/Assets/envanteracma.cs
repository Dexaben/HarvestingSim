using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class envanteracma : MonoBehaviour
{
    public Save SAVE;
    public GameObject g_save;
    public int s_yaprak;
    public int s_hurc;
    public int s_bez;
    public Text yaprak;
    public Text hurc;
    public Text bez;
    public GameObject envanter;
    private bool on = false;
    void Start()
    {
        g_save = GameObject.FindGameObjectWithTag("save");
        SAVE = g_save.GetComponent<Save>();
        s_yaprak = SAVE.s_yaprakk;
        s_hurc = SAVE.s_hurcc;
        s_bez = SAVE.s_bezz;
    }

    void Update()
    {
        yaprak.text = s_yaprak.ToString();
        hurc.text = s_hurc.ToString();
        bez.text = s_bez.ToString();
        if (s_yaprak == 250)
        {
            s_hurc += 1;
            s_yaprak = 0;
        }
        if (s_hurc == 4)
        {
            s_bez += 1;
            s_hurc = 0;
        }
        if (s_hurc > 4)
        {
            s_hurc = 4;
        }
        if (s_yaprak > 250)
        {
            s_yaprak = 250;
        }
        if (CrossPlatformInputManager.GetButtonDown("Envanter"))
        {
            on = !on;
        }
        if (on)
        {
            envanter.SetActive(true);
        }
        else if (!on)
        {
            envanter.SetActive(false);
        }
    }
}
