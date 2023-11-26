using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;

    private AudioSource laserAudioSource;

    private void Awake() 
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        //animate the gun
        laserAnimator.SetTrigger("Fire");

        //play laser gun SFX
        laserAudioSource.PlayOneShot(laserSFX);
    }
}
