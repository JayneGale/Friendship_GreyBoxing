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
    public float maxTimeToBarkBout;
    public float minTimeToBarkBout;
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
        DoBarking();
    }

    void DoBarking()
    {
        int numberOfBarks = UnityEngine.Random.Range(2, maxNumOfBarks);
  //      Debug.Log("numberOfBarks is " + numberOfBarks);

        for (int i = 0; i < numberOfBarks; i++)
        {
            float barkRest = UnityEngine.Random.Range(minBarkRest, maxBarkRest);
  //          Debug.Log("barkRest is " + barkRest);
            Invoke("ChooseBark", barkRest);           
        }

        timeToBarkBout = UnityEngine.Random.Range(minTimeToBarkBout, maxTimeToBarkBout);
 //       Debug.Log("timeToBarkBout is " + timeToBarkBout);
        Invoke("DoBarking", timeToBarkBout);
    }

    public void ChooseBark()
    {
        barkToPlay = UnityEngine.Random.Range(0, barkClips.Length);
        thisDogBark.PlayOneShot(barkClips[barkToPlay]);
    }
}

