using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggercheck : MonoBehaviour {
    public bool check;
	void OnTriggerEnter(Collider other)
    {
        if(other.name == "a0l")
        {
            check = true;
        }
    }
}
