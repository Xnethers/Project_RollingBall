using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    #region Static Fields
    public static SoundManager Instance;
    #endregion

    #region Public Fields
    public AudioSource SceneAudioSource;//全場景音效
    public AudioSource EffectsSource;//個人音效
    public float fadeTime = 1;

    [HideInInspector]
    public Sound[] soundData;
    // public AudioClip ClikUI;
    // public AudioClip BGM;
    // public AudioClip Occupation;
    // public AudioClip Win;
    // public AudioClip Lose;
    #endregion

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    public void PlayEffectSound(String sound)//個人音效
    {
        AudioClip c = FindClipByName(sound);
        EffectsSource.PlayOneShot(c);
    }

    // Play a single clip through the music source.
    public void PlaySceneEffect(String sound)//全場景音效
    {
        AudioClip c = FindClipByName(sound);
        SceneAudioSource.PlayOneShot(c);
    }

    public void PlayMusic(String sound)
    {
        // AudioClip c = FindClipByName(sound);
        // SceneAudioSource.PlayClipAtPoint(c,);
    }

    public void FadeOutBGM()
    {
        StartCoroutine(lerpBGMvolumeScale(fadeTime, "Out"));
    }

    public void FadeInBGM()
    {
        StartCoroutine(lerpBGMvolumeScale(fadeTime, "In"));
    }

    IEnumerator lerpBGMvolumeScale(float FadeTime, String InOut)
    {
        float startVolume = SceneAudioSource.volume;

        while (InOut == "Out")
        {
            SceneAudioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            if (SceneAudioSource.volume <= 0)
            {
                SceneAudioSource.Stop();
                SceneAudioSource.volume = 1.0f;
                break;
            }
            yield return null;
        }

        while (InOut == "In")
        {
            SceneAudioSource.volume += startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public AudioClip FindClipByName(String clipname)
    {
        foreach (var item in soundData)
        {
            if (clipname == item.name)
            { return item.audioClip; }
        }
        return null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}

[System.Serializable]
public class Sound
{
    public String name;
    public AudioClip audioClip;

}