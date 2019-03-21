using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBarking : MonoBehaviour
{
    public AudioClip[] newBarkClips;
    public int minTimeToBarking;
    public int maxTimeToBarking;
    public float minBarkGap;
    public float maxBarkGap;
    public int minNumBarks;
    public int maxNumBarks;

    AudioClip barkNow;
    float barkGap;
    bool notBarking = true;
    bool notBarking2 = true;
    int barkToBark;
    int timeToBarking;
    int numBarks = 3;

    // Use this for initialization
    AudioSource dogBarkAudio;

    void Start()
    {
        dogBarkAudio = gameObject.GetComponent<AudioSource>();
        barkNow = dogBarkAudio.GetComponent<AudioClip>();
        barkToBark = UnityEngine.Random.Range(0, newBarkClips.Length);
        barkNow = newBarkClips[barkToBark];
    }

    void Update()
    {
        if (notBarking)
        {
            StartCoroutine(Bark());
        }
    }

    IEnumerator Bark()
    {
        print("Bark");
        notBarking = false;
        numBarks = UnityEngine.Random.Range(minNumBarks, maxNumBarks);
        Debug.Log("Number of barks " + numBarks);

        for (int i = 0; i < numBarks; i++)
        {
            if (notBarking2)
            {
                yield return StartCoroutine(ChooseNextBark());
            }
        }
        //Get random delay until next Barking
        timeToBarking = UnityEngine.Random.Range(minTimeToBarking, maxTimeToBarking);
        Debug.Log("Time to next barking " + timeToBarking);
        //Wait for random delay
        yield return new WaitForSeconds(timeToBarking);
        notBarking = true;
    }

    IEnumerator ChooseNextBark()
    {
       print("ChooseBark");
        notBarking2 = false;

        //Choose an audio clip
        barkToBark = UnityEngine.Random.Range(0, newBarkClips.Length);
        barkNow = newBarkClips[barkToBark];
        dogBarkAudio.clip = barkNow;
        Debug.Log("Bark to play " + barkNow);

        //Play sound
        dogBarkAudio.PlayOneShot(barkNow);
        
        //Get random delay to next Play
        barkGap = UnityEngine.Random.Range(minBarkGap, maxBarkGap);
        Debug.Log("Time to next bark " + barkGap);
        
        //Wait for random delay
        yield return new WaitForSeconds(barkGap);
        notBarking2 = true;
    }
}
