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
    public int maxNumOfBarks;
    float timeToBarkBout;
    int barkToPlay;
    public float maxBarkRest;
    float barkRest;

    void Start()
    {
 
        if (barkClips.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }
        if (maxTimeToBarkBout < 4.0f)
        {
            maxTimeToBarkBout = 4.0f;
        }
        if (maxBarkRest < 0.5f)
        {
            maxBarkRest = 0.5f;
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
            float barkRest = UnityEngine.Random.Range(1.0f, maxBarkRest);
  //          Debug.Log("barkRest is " + barkRest);
            Invoke("ChooseBark", barkRest);           
        }

        timeToBarkBout = UnityEngine.Random.Range(4.0f, maxTimeToBarkBout);
 //       Debug.Log("timeToBarkBout is " + timeToBarkBout);
        Invoke("DoBarking", timeToBarkBout);
    }

    public void ChooseBark()
    {
        barkToPlay = UnityEngine.Random.Range(0, barkClips.Length);
        thisDogBark.PlayOneShot(barkClips[barkToPlay]);
    }
}

