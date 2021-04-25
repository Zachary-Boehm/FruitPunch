using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Players")]
    [SerializeField] private AudioSource[] sources;
    [Header("FX Audio Sources")]
    [SerializeField] private AudioClip[] fx;
    [Header("Music Audio Sources")]
    [SerializeField] private AudioClip[] music;
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer Mixer;

    public void playFx(string fxName)
    {
        foreach(AudioClip clip in fx)
        {
            if(clip.name == fxName)
            {
                sources[0].volume = GameManager.GAMEMANAGER.getFXVolume();
                sources[0].PlayOneShot(clip);
                return;
            }
        }
        Debug.Log("Incorrect Audio Clip");
    }

    public void playMusic(string musicName)
    {
        foreach(AudioClip clip in music)
        {
            if (clip.name == musicName)
            {
                //Fade out current music
                sources[1].clip = clip;
                sources[1].volume = GameManager.GAMEMANAGER.getMusicVolume();
                sources[1].Play();
                //Fade in new music
                return;
            }
        }
        Debug.Log("Invalid Audio Clip");
    }

    public void updateVolume(int audioSource, float volume)
    {
        sources[audioSource].volume = volume;
    }

    public void stopMusic()
    {
        sources[1].Stop();
    }
}
