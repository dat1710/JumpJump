using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSourc;
    public AudioSource vfxAudioSourc;

    public AudioClip musicClip;
    public AudioClip coinClip;
    public AudioClip winClip;

    void start(){
        musicAudioSourc.clip = musicClip;
        musicAudioSourc.Play();
    }
    public void PlaySFX(AudioClip sfxClip){
        vfxAudioSourc.clip = sfxClip;
        vfxAudioSourc.PlayOneShot(sfxClip);
    }
}
