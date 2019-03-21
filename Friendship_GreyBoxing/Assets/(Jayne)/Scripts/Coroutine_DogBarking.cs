using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine_DogBarking : MonoBehaviour {
    bool notBarking = true;
    bool stopBark = false;
    // Use this for initialization
    AudioSource dogBarkAudio;

    void Start() {
        dogBarkAudio = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update() {
        if (notBarking)
        {
            StartCoroutine(Bark());
        }
    }

    IEnumerator Bark()
    {
        notBarking = false;
        //Play sound
        dogBarkAudio.Play();
        print("Bark");
        //Get random delay
        int randomDelay = UnityEngine.Random.Range(3, 3);
        //Wait for random delay
        yield return new WaitForSeconds(randomDelay);
        stopBark = true;
        StartCoroutine(StopBark());
    }


    IEnumerator StopBark()
    {
        dogBarkAudio.Stop();
        print("Stop Bark");
        int randomDelay2 = 6;
        //Wait for random delay
        yield return new WaitForSeconds(randomDelay2);
        stopBark = false;
        notBarking = true;
    }
}
