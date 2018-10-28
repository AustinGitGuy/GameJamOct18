using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Managers
{
    public class SoundManagerScript : Singleton<SoundManagerScript>
    {
        GameObject skullSoundObj;
        GameObject doorSoundObj;
        GameObject ringSoundObj;
        GameObject coinSoundObj;
        GameObject pushPullSoundObj;
        GameObject fountainSoundObj;
        GameObject portalSoundObj;
        GameObject skullOnBloodSoundObj;
        GameObject torchSoundObj;
        GameObject deathSoundObj;

        AudioSource skullSound;
        AudioSource doorSound;
        AudioSource ringSound;
        AudioSource coinSound;
        AudioSource pushPullSound;
        AudioSource fountainSound;
        AudioSource portalSound;
        AudioSource skullOnBloodSound;
        AudioSource torchSound;
        AudioSource deathSound;

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
            deathSoundObj = GameObject.Find("deathSoundObj");

            skullSound = skullSoundObj.GetComponent<AudioSource>();
            doorSound = doorSoundObj.GetComponent<AudioSource>();
            ringSound = ringSoundObj.GetComponent<AudioSource>();
            coinSound = coinSoundObj.GetComponent<AudioSource>();
            pushPullSound = pushPullSoundObj.GetComponent<AudioSource>();
            fountainSound = fountainSoundObj.GetComponent<AudioSource>();
            portalSound = portalSoundObj.GetComponent<AudioSource>();
            skullOnBloodSound = skullOnBloodSoundObj.GetComponent<AudioSource>();
            torchSound = torchSoundObj.GetComponent<AudioSource>();
            deathSound = deathSoundObj.GetComponent<AudioSource>();

        }

        public void playSkullSound()
        {
            skullSound.Play();
        }

        public void playDoorSound()
        {
            doorSound.Play();
        }

        public void playRingSound()
        {

            ringSound.Play();
        }

        public void playCoinSound()
        {
            coinSound.Play();
        }

        public void playPushPullSound()
        {
            pushPullSound.Play();
        }

        public void playFountainSound()
        {
            fountainSound.Play();
        }

        public void playPortalSound()
        {
            portalSound.Play();
        }

        public void playSkullOnBloodSound()
        {
            skullOnBloodSound.Play();
        }

        public void playTorchSound()
        {
            torchSound.Play();
        }

        public void playDeathSound()
        {
            deathSound.Play();
        }


        public void pauseSkullSound()
        {
            skullSound.Pause();
        }

        public void pauseDoorSound()
        {
            doorSound.Pause();
        }

        public void pauseRingSound()
        {

            ringSound.Pause();
        }

        public void pauseCoinSound()
        {
            coinSound.Pause();
        }

        public void pausePushPullSound()
        {
            pushPullSound.Pause();
        }

        public void pauseFountainSound()
        {
            fountainSound.Pause();
        }

        public void pausePortalSound()
        {
            portalSound.Pause();
        }

        public void pauseSkullOnBloodSound()
        {
            skullOnBloodSound.Pause();
        }

        public void pauseTorchSound()
        {
            torchSound.Pause();
        }

        public void pauseDeathSound()
        {
            deathSound.Pause();
        }

    }

}