using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, playerSource;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Level, Art, UI")
        {
            instance.PlayMusic("Background Music");
            musicSource.volume = 0.25f;
        }
        else if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            musicSource.volume = 1f;
            instance.PlayMusic("Main Menu Song");
        }
        else
        {
            musicSource.Stop();
        }
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }

    public void PlayMusic(string name)
    {
        Sounds mySound = Array.Find(musicSounds, x => x.clipName == name);
        if (mySound != null)
        {
            musicSource.clip = mySound.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.Log($"Sound \"{name}\" not found (Possible Misspelling?)");
        }
    }

    public void PlaySFX(string name)
    {
        Sounds mySound = Array.Find(sfxSounds, x => x.clipName == name);
        if (mySound != null)
        {
            sfxSource.clip = mySound.clip;
            sfxSource.Play();
        }
        else
        {
            Debug.Log($"Sound \"{name}\" not found (Possible Misspelling?)");
        }
    }

    public void PlaySFXFromPlayer(string name)
    {
        Sounds mySound = Array.Find(sfxSounds, x => x.clipName == name);
        if (mySound != null)
        {
            playerSource.clip = mySound.clip;
            playerSource.Play();
        }
        else
        {
            Debug.Log($"Sound \"{name}\" not found (Possible Misspelling?)");
        }
    }
}