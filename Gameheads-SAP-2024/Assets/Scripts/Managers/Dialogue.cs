using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//honestly I'd rather hardcode this than make a scriptable object
//unfortunately it has to be a scriptable object for the sprites and such :(
[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> levelDialogue;
    public List<DialogueLine> openingCutsceneDialogue;
    public List<DialogueLine> finalCutsceneDialogue;
}

[System.Serializable]
public class DialogueLine
{
    public string line;
    public AudioClip voiceLine;
    public Sprite charSprite;
}

