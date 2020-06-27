using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carManager : MonoBehaviour {

    Material mat;

    public Camera carCam;

    private bool inVeh;
    private GameObject player;

	void Start ()
    {
        carCam.enabled = false;
        inVeh = false;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inVeh == true)
            {
                vehicleControl(null);
            }
        }
	}

    public void vehicleControl(GameObject playerObj)
    {
        if(inVeh == false)
        {
            player = playerObj;
            carCam.enabled = true;
            player.SetActive(false);
            player.transform.parent = this.transform;

            StartCoroutine(Time(true));
        }
        else
        {
            player.SetActive(true);
            carCam.enabled = false;
            player.transform.parent = null;
            player = null;

            StartCoroutine(Time(false));
        }
    }

    private IEnumerator Time(bool inVehicle)
    {
        yield return new WaitForSeconds(1);
        inVeh = inVehicle;
    }
}
