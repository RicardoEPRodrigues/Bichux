using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class MusicEffects : MonoBehaviour {

    
    public Player player;

    
    
    public AudioClip bunnyClip;
    public AudioClip wormClip;
    public AudioClip elephantClip;
    public AudioClip unicornClip;
    public AudioClip menuClip;
    AudioSource audio;

    private float timeSeconds;
    void Start() {


        audio = GetComponent<AudioSource>();
        audio.clip = menuClip;
        audio.Play();
        

    }


    public void changeClip() {
       
        if (player.status == AnimalTypes.Worm)
        {
            timeSeconds = audio.time;
            audio.Stop();
            audio.clip = wormClip;
            audio.time = timeSeconds;
            audio.Play();
            Debug.Log("y");
            // elephantClip.Stop();
            //bunnyClip.Stop();
            //wormClip.Play();
        }
        if (player.status == AnimalTypes.Bunny)
        {
            timeSeconds = audio.time;
            audio.Stop();
            audio.clip = bunnyClip;
            audio.time = timeSeconds;
            audio.Play();
            //elephantClip.Stop();
            // bunnyClip.Play();
            //wormClip.Stop();
        }
        if (player.status == AnimalTypes.Elephant)
        {
            timeSeconds = audio.time;
            audio.Stop();
            audio.clip = elephantClip;
            audio.time = timeSeconds;
            audio.Play();
            //elephantClip.Play();
            //bunnyClip.Stop();
            //wormClip.Stop();
        }
        if (player.status == AnimalTypes.Unicorn)
        {
            timeSeconds = audio.time;
            audio.Stop();
            audio.clip = unicornClip;
            audio.time = timeSeconds;
            audio.Play();
            //audio.clip = unicornClip;
            //audio.Play();
        }
    

    }
}
