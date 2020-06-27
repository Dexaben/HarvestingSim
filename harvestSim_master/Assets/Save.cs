using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {

    public envanteracma env;
    public GameObject envanter;
    public int s_yaprakk;
    public int s_hurcc;
    public int s_bezz;

    public GameObject arac;

    public float xCPos;
    public float yCPos;
    public float zCPos;

    public float xCRot;
    public float yCRot;
    public float zCRot;

    public GameObject thePlayer;
    public float xPos;
    public float yPos;
    public float zPos;
    void Start()
    {

        //getirme
        arac = GameObject.FindGameObjectWithTag("car");
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        envanter = GameObject.FindGameObjectWithTag("envanter");
        env = envanter.GetComponent<envanteracma>();

        //env
        s_yaprakk = PlayerPrefs.GetInt("yapraksay");
        s_hurcc = PlayerPrefs.GetInt("hurcsay");
        s_bezz = PlayerPrefs.GetInt("bezsay");

        //player pos
        xPos = PlayerPrefs.GetFloat("xPosition");
        yPos = PlayerPrefs.GetFloat("yPosition");
        zPos = PlayerPrefs.GetFloat("zPosition");
        thePlayer.transform.position = new Vector3(xPos  , yPos, zPos);

        //arac pos
        xCPos = PlayerPrefs.GetFloat("xCPosition");
        yCPos = PlayerPrefs.GetFloat("yCPosition");
        zCPos = PlayerPrefs.GetFloat("zCPosition");
        arac.transform.position = new Vector3(xCPos, yCPos, zCPos);

        xCRot = PlayerPrefs.GetFloat("xCRotation");
        yCRot = PlayerPrefs.GetFloat("yCRotation");
        zCRot = PlayerPrefs.GetFloat("zCRotation");
        arac.transform.eulerAngles = new Vector3(xCRot,yCRot,zCRot);
    }
	public void  Button_OnClick() 
    {

        //arac pos/rot save
        xCPos = arac.transform.position.x;
        yCPos = arac.transform.position.y;
        zCPos = arac.transform.position.z;

        xCRot = arac.transform.eulerAngles.x;
        yCRot = arac.transform.eulerAngles.y;
        zCRot = arac.transform.eulerAngles.z;

        //player pos save
        xPos = thePlayer.transform.position.x;
        yPos = thePlayer.transform.position.y;
        zPos = thePlayer.transform.position.z;
        //env save
        s_yaprakk = env.s_yaprak;
        s_hurcc = env.s_hurc;
        s_bezz = env.s_bez;

        //env
        PlayerPrefs.SetInt("yapraksay", s_yaprakk);
        PlayerPrefs.SetInt("hurcsay", s_hurcc);
        PlayerPrefs.SetInt("bezsay", s_bezz);

        //arac pos
        PlayerPrefs.SetFloat("xCPosition", xCPos);
        PlayerPrefs.SetFloat("yCPosition", yCPos);
        PlayerPrefs.SetFloat("zCPosition", zCPos);

        //arac rot
        PlayerPrefs.SetFloat("xCRotation", xCRot);
        PlayerPrefs.SetFloat("yCRotation", yCRot);
        PlayerPrefs.SetFloat("zCRotation", zCRot);

        //player pos
        PlayerPrefs.SetFloat("xPosition", xPos);
        PlayerPrefs.SetFloat("yPosition", yPos);
        PlayerPrefs.SetFloat("zPosition", zPos);
	}
}
