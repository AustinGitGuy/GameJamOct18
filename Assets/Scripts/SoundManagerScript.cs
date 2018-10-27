using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;



public class SoundManagerScript : Singleton<SoundManagerScript> {
    GameObject skullSoundObj;
    GameObject doorSoundObj;
    GameObject ringSoundObj;
    GameObject coinSoundObj;
    GameObject pushPullSoundObj;
    GameObject fountainSoundObj;
    GameObject portalSoundObj;
    GameObject skullOnBloodSoundObj;
    GameObject torchSoundObj;


    AudioSource skullSound;
    AudioSource doorSound;
    AudioSource ringSound;
    AudioSource coinSound;
    AudioSource pushPullSound;
    AudioSource fountainSound;
    AudioSource portalSound;
    AudioSource skullOnBloodSound;
    AudioSource torchSound;

    private void Awake()
    {
        skullSoundObj = GameObject.Find("skullSoundObj");
        doorSoundObj = GameObject.Find("doorSoundObj");
        ringSoundObj = GameObject.Find("ringSoundObj");
        coinSoundObj = GameObject.Find("coinSoundObj");
        pushPullSoundObj = GameObject.Find("pushPullSoundObj");
        fountainSoundObj = GameObject.Find("fountainSoundObj");
        portalSoundObj = GameObject.Find("portalSoundObj");
        skullOnBloodSoundObj = GameObject.Find("skullOnBloodSoundObj");
        torchSoundObj = GameObject.Find("torchSoundObj");
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

    public void playPushPullSound()
    {
        pushPullSound = pushPullSoundObj.GetComponent<AudioSource>();
        pushPullSound.Play();
    }

    public void playFountainSound()
    {
        fountainSound = fountainSoundObj.GetComponent<AudioSource>();
        fountainSound.Play();
    }

    public void playPortalSound()
    {
        portalSound = portalSoundObj.GetComponent<AudioSource>();
        portalSound.Play();
    }

    public void playSkullOnBloodSound()
    {
        skullOnBloodSound = skullOnBloodSoundObj.GetComponent<AudioSource>();
        skullOnBloodSound.Play();
    }

    public void playTorchSound()
    {
        torchSound = torchSoundObj.GetComponent<AudioSource>();
        torchSound.Play();
    }

}
