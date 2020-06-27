using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea : MonoBehaviour
{
    public int hitcay;
    public Material[] material;
    Renderer rend;
    public bool toplanmadurumu;

    public void Start()
    {
        hitcay = 5;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        toplanmadurumu = false;
    }
    public void Update()
    {
        if (hitcay == 0)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[2];
        }
        if (hitcay < 0)
        {
            hitcay = 0;
        }
    }
}
