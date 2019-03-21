using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DogBarking : MonoBehaviour
{

    AudioSource thisDogBark;
    public AudioClip[] barkClips;
    AudioClip randomisedClip;
    AudioClip barkSet;
    public float maxTimeToBarkBout;
    public float minTimeToBarkBout;
    public int minNumOfBarks;
    public int maxNumOfBarks;
    float timeToBarkBout;
    int barkToPlay;
    public float maxBarkRest;
    public float minBarkRest;
    float barkRest;

    void Start()
    {
 
        if (barkClips.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }
        if (minTimeToBarkBout < 4.0f)
        {
            minTimeToBarkBout = 4.0f;
        }

        if (maxTimeToBarkBout < minTimeToBarkBout)
        {
            maxTimeToBarkBout = minTimeToBarkBout;
        }
        if (maxBarkRest < minBarkRest)
        {
            maxBarkRest = minBarkRest;
        }

        thisDogBark = gameObject.GetComponent<AudioSource>();
        barkSet = thisDogBark.GetComponent<AudioClip>();
        DoBarking();
    }

    void DoBarking()
    {
        int numberOfBarks = UnityEngine.Random.Range(minNumOfBarks, maxNumOfBarks);
        Debug.Log("numberOfBarks is " + numberOfBarks);

        for (int i = 0; i < numberOfBarks; i++)
        {
            float barkRest = UnityEngine.Random.Range(minBarkRest, maxBarkRest);
            Debug.Log("barkRest is " + barkRest);
//            ChooseBark();
            //          Invoke("StopBark", barkRest);
            Invoke("ChooseBark", barkRest);
            //
            thisDogBark.Play();
        }

        timeToBarkBout = UnityEngine.Random.Range(minTimeToBarkBout, maxTimeToBarkBout);
        Debug.Log("timeToBarkBout is " + timeToBarkBout);
        Invoke("DoBarking", timeToBarkBout);
    }

    public void ChooseBark()
    {
        barkToPlay = UnityEngine.Random.Range(0, barkClips.Length);
        Debug.Log("barkToPlay is " + barkToPlay);
        barkSet = barkClips[barkToPlay];
        thisDogBark.clip = barkSet;
        //       thisDogBark.PlayOneShot(barkClips[barkToPlay]);
        Debug.Log("Play dat bark");
        thisDogBark.Play();
        //       Invoke("StopBark", barkRest);
    }

    /*    public void StopBark()
        {
            Debug.Log("Stopping bark after barkRest " + barkRest);
            thisDogBark.Stop();
        }
      */
}

