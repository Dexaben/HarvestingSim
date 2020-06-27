using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class toplama : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
    public GameObject control;
    float deadZone = 0.2f;
    public float Stamina , maxStamina;
    public bool isRunning;
    public Animator anim;
    public Animator tamianim;
    public GameObject caymakasi;
    public GameObject tami;
    public GameObject Player;
    public teascript hitcay;
    RaycastHit hit;
    public float distanceToSee;
    //audio
    private AudioSource audioSource;
    public AudioClip[] toplamases;
    private AudioClip toplamasesclip;
    void Start()
    {
        controller = control.GetComponent<RigidbodyFirstPersonController>();
        audioSource = caymakasi.GetComponent<AudioSource>();
        anim = caymakasi.GetComponent<Animator>();
    }
    void Update()
    {
        if (Player.activeInHierarchy && (CrossPlatformInputManager.GetAxis("Horizontal") < -deadZone || CrossPlatformInputManager.GetAxis("Horizontal") > deadZone))
        {
            Stamina -= Time.deltaTime;
        }
        if (Player.activeInHierarchy && (CrossPlatformInputManager.GetAxis("Vertical") < -deadZone || CrossPlatformInputManager.GetAxis("Vertical") > deadZone))
        {
            Stamina -= Time.deltaTime;
        }
        if (Stamina < 25f && Stamina >= 10f)
        {
            controller.movementSettings.ForwardSpeed = 5f;
            controller.movementSettings.StrafeSpeed = 3f;
            controller.movementSettings.BackwardSpeed = 3f;
        }
        else if (Stamina < 10f && Stamina > 0)
        {
            controller.movementSettings.ForwardSpeed = 3f;
            controller.movementSettings.StrafeSpeed = 2f;
            controller.movementSettings.BackwardSpeed = 2f;
        }
        else if (Stamina == 0)
        {
            controller.movementSettings.ForwardSpeed = 1f;
            controller.movementSettings.StrafeSpeed = 1f;
            controller.movementSettings.BackwardSpeed = 1f;
        }
        else if (Stamina >= 25)
        {
            controller.movementSettings.ForwardSpeed = 8f;
            controller.movementSettings.StrafeSpeed = 4f;
            controller.movementSettings.BackwardSpeed = 4f;
        }
        if (Stamina > maxStamina)
        {
            Stamina = maxStamina;
        }
        if(Stamina < 0f)
        {
            Stamina = 0f;
        }
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            tami = hit.transform.gameObject;
            hitcay = tami.GetComponent<teascript>();
            if ((hit.transform.gameObject.tag == "tea") && (CrossPlatformInputManager.GetButtonDown("Topla")))
            {
                {
                    Stamina -= 0.5f;
                    anim.Play("anim_topla");
                    int index = Random.Range(0, toplamases.Length);
                    toplamasesclip = toplamases[index];
                    audioSource.clip = toplamasesclip;
                    audioSource.Play();
                    hitcay.hitcay -= 1;
                }
            }
        }
    }
}

