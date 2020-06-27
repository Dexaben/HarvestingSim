using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uyariscript : MonoBehaviour
{
    public Text text;
    public GameObject image;

    void Update()
    {
        if (text.text == "")
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
    }
}