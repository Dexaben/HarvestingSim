using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aracset : MonoBehaviour
{
    public GameObject arac;

    void Start()
    {
        arac = GameObject.FindGameObjectWithTag("car");
    }
    public void ButtonClick()
    {
        arac.transform.position = new Vector3(7, 8, -194);
    }
}