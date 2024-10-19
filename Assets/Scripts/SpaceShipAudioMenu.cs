using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAudioMenu : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioShoot;
    public AudioClip AudioPropulsion;
    public AudioClip AudioDamage;


    public void AudioPropulsionShip()
    {
        AudioSource.PlayOneShot(AudioShoot);
    }

    public void AudioShooting()
    {
        AudioSource.PlayOneShot(AudioPropulsion);
    }

    public void AudioTakeDamage()
    {
        AudioSource.PlayOneShot(AudioDamage);
    }

}
