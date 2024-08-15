using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string clipName;
    public AudioClip clip;
   [Range(0.0f,1.0f)] public float volume =1.0f;
}