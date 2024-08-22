using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMana : MonoSingleton<SoundMana>
{
    public AudioSource aud;



    public void AudPlay(AudioClip clip)
    {
        aud.PlayOneShot(clip);
    }
    public void AudPlay(AudioClip clip,float vol)
    {
        aud.PlayOneShot(clip,vol);
    }
}
