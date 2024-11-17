using System;
using UnityEditor.Media;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager instance;
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, playerSource;
    public float musicVol, sfxVol, playerVol;


    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float userVol;

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            musicVol = 1f;
            instance.PlayMusic("Main Menu Song");
        }
        else if (SceneManager.GetActiveScene().name == "Credits")
        {
            musicVol = 1f;
            instance.PlayMusic("Credits Music");
        } 
        else if (SceneManager.GetActiveScene().name == "Opening Cutscene")
        {
            musicVol = 0.5f;
            instance.PlayMusic("hallway music");
        }
        else if(SceneManager.GetActiveScene().name == "Final Cutscene")
        {
            //TODO: add final cutscene music here.
            musicVol = 0.5f;
            instance.PlayMusic("drums music");
        }
        else
        {
            musicVol = 0.1f;
            playerVol = 0.5f;
            sfxVol = 0.3f;
            instance.PlayMusic("Background Music");
        }
        /*
        else
        {
            musicSource.Stop();
        }
        */
        musicSource.volume = musicVol * userVol;
        playerSource.volume = playerVol * userVol;
        sfxSource.volume = sfxVol * userVol;
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
        volumeSlider = GameObject.FindWithTag("VolumeSlider").GetComponent<Slider>();
        musicSource.volume = musicVol * userVol;
        playerSource.volume = playerVol * userVol;
        sfxSource.volume = sfxVol * userVol;
        Debug.Log(userVol);
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

    /// <summary>
    /// Sets user volume to value on volume slider. called by the volume slider.
    /// </summary>
    public void ChangeVolume() {
        //TO-DO: the below throws an object reference exception. fix.
        Debug.Log(volumeSlider + " " + volumeSlider.value);    
        userVol = volumeSlider.value;
        musicSource.volume = musicVol * userVol;
        playerSource.volume = playerVol * userVol;
        sfxSource.volume = sfxVol * userVol;
        Debug.Log(userVol);
    }

}