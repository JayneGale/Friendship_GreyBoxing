using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource someSound;

    void start()
    {

    }

    void update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            someSound.Play();
        }
    }
}