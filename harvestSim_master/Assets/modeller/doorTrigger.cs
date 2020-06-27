using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class doorTrigger : MonoBehaviour
{
    public int agirlik;
    public int a_bez;
    public envanteracma env;
    public GameObject inventor;
    public Text uyar;
    public Text uyar_yukleme;
    public GameObject uyar_yukleme_o;
    /// ///////////////////////////////////////////////////////
    ///
    public Text t_agirlik;
    public Text bezsay;
    public GameObject o_bezsay;
    //bezler
    public GameObject bez1;
    public GameObject bez2;
    public GameObject bez3;
    public GameObject bez4;
    public GameObject bez5;
    public GameObject bez6;
    public GameObject bez7;
    public GameObject bez8;
    public GameObject bez9;
    public GameObject bez10;
    public GameObject bez11;
    public GameObject canvass;

    //giris cikis
    public GameObject Vehicle;
    public GameObject Player;
    public bool inVehicle = false;
    public GameObject canvas;
    public GameObject araccam;
    public Transform exit;
    public GameObject camera1;
    public GameObject camera2;
    AudioListener camera1AudioLis;
    AudioListener camera2AudioLis;
    public RearWheelDrive inVehiclee;
    public void Start()
    {
        uyar_yukleme = uyar_yukleme_o.GetComponentInChildren<Text>();
        uyar = canvass.GetComponentInChildren<Text>();
        env = inventor.GetComponent<envanteracma>();

        //bez find

        camera1AudioLis = camera1.GetComponent<AudioListener>();
        camera2AudioLis = camera2.GetComponent<AudioListener>();

        camera2.SetActive(false);
        canvas.SetActive(false);
        inVehiclee = Vehicle.GetComponent<RearWheelDrive>();
    }
    void Update()
    {
        if(inVehicle == true)
        {
            o_bezsay.SetActive(true);
            uyar_yukleme.text = "";
            bezsay.text = "Yüklenen Bez Sayısı = " + a_bez;
            t_agirlik.text = "Ağırlık = " + agirlik;
        }
        else
        {
            o_bezsay.SetActive(false);
        }
        if (inVehicle == true && CrossPlatformInputManager.GetButtonDown("E"))
        {
            araccam.SetActive(false);
            Player.SetActive(true);
            Player.transform.parent = null;
            Player.transform.position = exit.position;
            inVehicle = false;
            inVehiclee.inveh = false;
        }
        switchCamera();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            canvas.SetActive(true);
            canvass.SetActive(true);
        }
        if(other.gameObject.tag == "Player" && inVehicle == false && CrossPlatformInputManager.GetButtonDown("yukle"))
        {
            if(env.s_bez > 0)
            {
                a_bez += env.s_bez;
                env.s_bez = 0;
                agirlik = 80 * a_bez;
                uyar.text = "BEZLER ARAÇ'A YÜKLENDİ!";
            }
            if(env.s_bez == 0)
            {
                uyar_yukleme.text = "YÜKLENECEK BEZ YOK!";
            }
            if(a_bez == 1)
            {
                bez1.SetActive(true);
            }
            if (a_bez == 2)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
            }
            if (a_bez == 3)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
            }
            if (a_bez == 4)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
            }
            if (a_bez == 5)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
            }
            if (a_bez == 6)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
            }
            if (a_bez == 7)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
                bez7.SetActive(true);
            }
            if (a_bez == 8)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
                bez7.SetActive(true);
                bez8.SetActive(true);
            }
            if (a_bez == 9)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
                bez7.SetActive(true);
                bez8.SetActive(true);
                bez9.SetActive(true);
            }
            if (a_bez == 10)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
                bez7.SetActive(true);
                bez8.SetActive(true);
                bez9.SetActive(true);
                bez10.SetActive(true);
            }
            if (a_bez >= 11)
            {
                bez1.SetActive(true);
                bez2.SetActive(true);
                bez3.SetActive(true);
                bez4.SetActive(true);
                bez5.SetActive(true);
                bez6.SetActive(true);
                bez7.SetActive(true);
                bez8.SetActive(true);
                bez9.SetActive(true);
                bez10.SetActive(true);
                bez11.SetActive(true);
            }
        }
        if (other.gameObject.tag == "Player" && inVehicle == false && CrossPlatformInputManager.GetButtonDown("F"))
        {
            Player.SetActive(false);
            canvas.SetActive(false);
            canvass.SetActive(false);
            inVehicle = true;
            araccam.SetActive(true);
            inVehiclee.inveh = true;
            Player.transform.parent = Vehicle.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            canvas.SetActive(false);
            canvass.SetActive(false);
            uyar.text = "BEZLERİ ARAÇ'A YÜKLE?";
            uyar_yukleme.text = "";
        }
    }
    public void cameraPositionM()
    {
        cameraChangeCounter();
    }
    void switchCamera()
    {
        if(inVehicle == true && CrossPlatformInputManager.GetButtonDown("Camera"))
        {
            cameraChangeCounter();
        }
    }
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }
    void cameraPositionChange(int camPosition)
    {
        if(camPosition >1)
        {
            camPosition = 0;
        }
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        if(camPosition == 0)
        {
            camera1.SetActive(true);
            camera1AudioLis.enabled = true;

            camera2AudioLis.enabled = false;
            camera2.SetActive(false);
        }
        if(camPosition == 1)
        {
            camera1.SetActive(false);
            camera1AudioLis.enabled = false;

            camera2AudioLis.enabled = true;
            camera2.SetActive(true);
        }
    }
}