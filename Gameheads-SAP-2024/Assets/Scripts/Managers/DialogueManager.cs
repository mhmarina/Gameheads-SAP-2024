using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized]
    public bool movementTrigger = false;
    public bool deadBodyTrigger = false;
    public bool inhaleTrigger = false;
    public bool releaseTrigger = false;
    public bool targetNumReachedTrigger = false;

    [SerializeField] Image characterSpriteImage;
    [SerializeField] TextMeshProUGUI dialogueText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVoiceLine(DialogueLine voiceLine)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(voiceLine.voiceLine);
    }
}
