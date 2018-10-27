using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;



public class SoundManagerScript : Singleton<SoundManagerScript> {
    GameObject skullSoundObj;
    GameObject doorSoundObj;
    GameObject ringSoundObj;
    GameObject coinSoundObj;
    GameObject potSoundObj;
    GameObject fountainSoundObj;

    AudioSource skullSound;
    AudioSource doorSound;
    AudioSource ringSound;
    AudioSource coinSound;
    AudioSource potSound;
    AudioSource fountainSound;

    private void Awake()
    {
        skullSoundObj = GameObject.Find("skullSoundObj");
        doorSoundObj = GameObject.Find("doorSoundObj");
        ringSoundObj = GameObject.Find("ringSoundObj");
        coinSoundObj = GameObject.Find("coinSoundObj");
        potSoundObj = GameObject.Find("potSoundObj");
        fountainSoundObj = GameObject.Find("fountainSoundObj");
    }

    public void playSkullSound()
    {
        skullSound = skullSoundObj.GetComponent<AudioSource>();
        skullSound.Play();
    }

    public void playDoorSound()
    {
        doorSound = doorSoundObj.GetComponent<AudioSource>();
        doorSound.Play();
    }

    public void playRingSound()
    {
        ringSound = ringSoundObj.GetComponent<AudioSource>();
        ringSound.Play();
    }
    public void playCoinSound()
    {
        coinSound = coinSoundObj.GetComponent<AudioSource>();
        coinSound.Play();
    }
    public void playPotSound()
    {
        potSound = potSoundObj.GetComponent<AudioSource>();
        potSound.Play();
    }
    public void playFountainSound()
    {
        fountainSound = fountainSoundObj.GetComponent<AudioSource>();
        fountainSound.Play();
    }
}
