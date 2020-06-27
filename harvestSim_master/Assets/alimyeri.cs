using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alimyeri : MonoBehaviour {
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
	void Start () {
		
	}
	void OnTriggerEnter (Collider other) {
		if(other.tag == "car")
        {

        }
	}
}
