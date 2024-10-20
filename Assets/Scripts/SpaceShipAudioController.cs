using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipAudioController : MonoBehaviour
{
    public AudioSource SourcePropulsion;
    public AudioSource SourceWeapon; 
    public AudioClip AudioShoot;
    public AudioClip AudioPropulsion;
    public AudioClip AudioDamage;


    public void AudioPropulsionShipOn()
    {
        if (SourcePropulsion.isPlaying)
        {

            return;
        } 
        SourcePropulsion.Play();
    }
    public void AudioPropulsionShipOff()
    {
        SourcePropulsion.Stop();
    }

    public void AudioShooting()
    {
        if (SourcePropulsion.isPlaying)
        {
            return;
        }
        SourceWeapon.PlayOneShot(AudioShoot);
    }

    public void AudioTakeDamage()
    {
        if (SourcePropulsion.isPlaying)
        {
            return;
        }
        SourcePropulsion.PlayOneShot(AudioDamage);
    }

}
