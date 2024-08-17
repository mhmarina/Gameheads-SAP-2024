using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, playerSource;
    public float musicVol, sfxVol, playerVol;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            musicSource.volume = 1f;
            instance.PlayMusic("Main Menu Song");
        }
        else if (SceneManager.GetActiveScene().name == "Credits")
        {
            musicSource.volume = 1f;
            instance.PlayMusic("Credits Music");
        } 
        else if (SceneManager.GetActiveScene().name == "Opening Cutscene")
        {
            musicSource.volume = 0.5f;
            instance.PlayMusic("hallway music");
        }
        else if(SceneManager.GetActiveScene().name == "Final Cutscene")
        {
            //TODO: add final cutscene music here.
            musicSource.volume = 0.5f;
            musicSource.Stop();
        }
        else
        {
            musicSource.volume = 0.1f;
            playerSource.volume = 0.5f;
            sfxSource.volume = 0.3f;
            instance.PlayMusic("Background Music");
        }
        /*
        else
        {
            musicSource.Stop();
        }
        */
        musicVol = musicSource.volume;
        playerVol = playerSource.volume;
        sfxVol = sfxSource.volume;
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
        musicVol = musicSource.volume;
        playerVol = playerSource.volume;
        sfxVol = sfxSource.volume;
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
        if (mySound != null && sfxSource.clip?.name != mySound.clip.name)
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
        if (mySound != null && playerSource.clip?.name != mySound.clip.name)
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