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
        if (newBarkClips.Length < 1)
        {
            Debug.Log("No audio clips assigned to " + gameObject.name);
            Application.Quit();
        }
        if (minTimeToBarking > maxTimeToBarking)
        {
            Debug.Log("Minimum time greater than maximum time " + gameObject.name);
            minTimeToBarking = maxTimeToBarking;
        }
        if (minTimeToBarking < 1)
        {
            Debug.Log("Minimum time is zero " + gameObject.name);
            minTimeToBarking = 1;
        }
        if (maxTimeToBarking< 1)
        {
            Debug.Log("Maximum time is zero " + gameObject.name);
            maxTimeToBarking = 1;
        }

        if (maxBarkGap < minBarkGap)
        {
            Debug.Log("Minimum time gap greater than maximum time gap" + gameObject.name);
            minBarkGap = maxBarkGap;
        }

        if (maxBarkGap < 0)
        {
            Debug.Log("Maximum time gap is zero " + gameObject.name);
            maxBarkGap = 0.1f;
        }

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
