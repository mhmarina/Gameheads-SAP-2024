using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string line;
    public AudioClip voiceLine;
    public Sprite charSprite;

    public void playVoiceLine(AudioSource audioSource)
    {
        if (voiceLine)
        {
            audioSource.PlayOneShot(voiceLine);
        }
    }
}

