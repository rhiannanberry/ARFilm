using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public AudioClip[] feetSounds;
    public float[] timingLoop;
    // Start is called before the first frame update
    public AudioClip thud;

    bool playFeet = true;
    AudioSource aus;
    int currentWait = 0;
    float time = 0;
    
    void Start()
    {
        aus = GetComponent<AudioSource>();
        aus.clip = GetRandom();
        aus.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!aus.isPlaying && playFeet) {
            time += Time.deltaTime;
            if (timingLoop[currentWait] <= time) {
                time = 0;
                currentWait = (currentWait + 1)%(timingLoop.Length);
                aus.clip = GetRandom();
                aus.Play();
            }
        }*/
    }

    AudioClip GetRandom() {
        return feetSounds[Random.Range(0, feetSounds.Length)];
    }

    void StopFeet() {
        playFeet = false;
    }

    public void PlayFoot() {
        aus.Stop();
        aus.clip = GetRandom();
        aus.Play();
    }

    void PlayThud() {
        aus.clip = thud;
        aus.Play();
    }
}
