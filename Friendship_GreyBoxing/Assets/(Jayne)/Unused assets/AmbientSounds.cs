using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AmbientSounds : MonoBehaviour
{

    AudioSource forestAmbient;

    void Start()
    {
        forestAmbient = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            forestAmbient.enabled = true;
            forestAmbient.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            forestAmbient.Stop();
        }
    }

}

