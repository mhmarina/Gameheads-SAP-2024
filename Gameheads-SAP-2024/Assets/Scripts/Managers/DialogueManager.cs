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
        public Sprite playerSprite;
    }

    [SerializeField] Image characterSpriteImage;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Dialogue dialogue;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
