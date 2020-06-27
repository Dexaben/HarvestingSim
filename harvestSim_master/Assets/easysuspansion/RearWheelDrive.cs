using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class RearWheelDrive : MonoBehaviour
{
    public doorTrigger doorscript;
    public GameObject trigger;
    public Animator a_truck;
    public bool engineonoff = false;
    public Rigidbody m_Rigidbody;
    public bool inveh;
    public float torque;
    public float angle;
    public AudioSource motorsesi;
    public AudioSource idlemotor;
    public AudioSource startmotor;
    public AudioSource stopmotor;
    public GameObject g_stopmotor;
    private WheelCollider[] wheels;
    public float maxAngle = 30;
    public float maxTorque = 300;
    public GameObject wheelShape;
    public void Start()
    {
        doorscript = trigger.GetComponent<doorTrigger>();
        m_Rigidbody = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelCollider>();
        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];
            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }
    public void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Calistirma"))
        {

            engineonoff = !engineonoff;
        }
        if (engineonoff)
        {
            engineonoff = true;
            stopmotor.enabled = false;
            startmotor.enabled = true;
            idlemotor.enabled = true;
            g_stopmotor.SetActive(true);
            a_truck.SetTrigger("idle");
        }
        if(!engineonoff)
        {
            engineonoff =false;
            stopmotor.enabled = true;
            startmotor.enabled = false;
            idlemotor.enabled = false;
            a_truck.SetTrigger("static");

        }
        if (inveh == false)
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            motorsesi.enabled = false;
            idlemotor.enabled = false;
            startmotor.enabled = false;
            stopmotor.enabled = false;
            g_stopmotor.SetActive(false);
        }
        else
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
        float angle = maxAngle * CrossPlatformInputManager.GetAxis("Horizontal");
        torque = maxTorque * CrossPlatformInputManager.GetAxis("Vertical");

        if (inveh == true && engineonoff == true)
        {
            if(doorscript.agirlik > 0 && doorscript.agirlik <= 7)
            {
                m_Rigidbody.mass = doorscript.agirlik * 6;
            }
            else if(doorscript.agirlik > 7)
            {
                m_Rigidbody.mass = 3360;
            }
            else if(doorscript.agirlik == 0)
            {
                m_Rigidbody.mass = 500;
            }
            else if(doorscript.agirlik < 0)
            {
                doorscript.agirlik = 0;
            }
            motorsesi.enabled = true;
            motorsesi.pitch = torque / maxTorque;

            foreach (WheelCollider wheel in wheels)
            {

                if (wheel.transform.localPosition.z > 0)
                    wheel.steerAngle = angle;

                if (wheel.transform.localPosition.z < 0)
                    wheel.motorTorque = torque;
                if (wheelShape)
                {
                    Quaternion q;
                    Vector3 p;
                    wheel.GetWorldPose(out p, out q);
                    Transform shapeTransform = wheel.transform.GetChild(0);
                    shapeTransform.position = p;
                    shapeTransform.rotation = q;
                }
            }
        }
    }
}