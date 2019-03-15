using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DogMoving : MonoBehaviour
{

    public GameObject nextDog;
    AudioSource nextDogBark;
    AudioSource forestAmbient;
    public AudioClip[] dogBarks;
    Animator nextDogAnimator;
    AudioClip randomisedClip;
    public float maxTimeToNextBout;
    public int maxNumberOfBarks;
    float timeToNextBout;
    int barkSelected;
    int numberOfBarks;
    public float maxBarkGap;
 //   float gapBoutTimer;
    float barkGap;

    void Start()
    {
        if (nextDog == null)
        {
            Debug.Log("No dog assigned to " + gameObject.name);
        }

        if (dogBarks.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }
        if (maxTimeToNextBout < 2.0f)
        {
            maxTimeToNextBout = 2.0f;
        }
        if (maxBarkGap < 0.5f)
        {
            maxBarkGap = 0.5f;
        }

        nextDogBark = nextDog.GetComponent<AudioSource>();
        forestAmbient = gameObject.GetComponent<AudioSource>();
        nextDogAnimator = nextDog.GetComponent<Animator>();
  //      gapBoutTimer = 0.0f;
        PlayBarkBout();

        //       InvokeRepeating("PlayBarkBout", 0, timeBetweenBarkBouts);
        //            Invoke("PlayBarkBout", timeBetweenBouts);
    }

    void PlayBarkBout()
    {
        nextDogBark = nextDog.GetComponent<AudioSource>();

        int numberOfBarks = UnityEngine.Random.Range(2, maxNumberOfBarks);
        for (int i = 0; i < numberOfBarks; i++)
        {
            float barkGap = UnityEngine.Random.Range(0.5f, maxBarkGap);
            Invoke("ChooseBark", barkGap);           
        }

        timeToNextBout = UnityEngine.Random.Range(2.0f, maxTimeToNextBout);
//        gapBoutTimer += Time.deltaTime;
//      if (gapBoutTimer >= timeToNextBout)
 //       {
        Invoke("PlayBarkBout", timeToNextBout);
 //           gapBoutTimer = 0.0f;
 //       }
    }

    public void ChooseBark()
    {
        barkSelected = UnityEngine.Random.Range(0, dogBarks.Length);
        nextDogBark.PlayOneShot(dogBarks[barkSelected]);
 //       gapBarkTimer = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            forestAmbient.enabled = true;
            forestAmbient.Play();
            nextDogAnimator.enabled = true;
            nextDogBark = nextDog.GetComponent<AudioSource>();
            PlayBarkBout();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nextDogBark = nextDog.GetComponent<AudioSource>();
            nextDogBark.Stop();
            forestAmbient.Stop();
            nextDogAnimator.enabled = false;
        }
    }

}

