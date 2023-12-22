using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform laserBeamSpawnPoint;
    [SerializeField] private GameObject laserBeamPrefab;

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

        //initialize laser beam object
        GameObject laserBeam = Instantiate(laserBeamPrefab, laserBeamSpawnPoint.position, laserBeamSpawnPoint.rotation);

        laserBeam.GetComponent<Rigidbody>().velocity = laserBeamSpawnPoint.forward * 70f;
    }
}
