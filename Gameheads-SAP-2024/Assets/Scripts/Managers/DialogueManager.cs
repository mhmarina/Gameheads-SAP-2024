using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Trigger states
    [System.NonSerialized]
    public bool movementTrigger = false;
    public bool deadBodyTrigger = false;
    public bool inhaleTrigger = false;
    public bool releaseTrigger = false;
    public bool targetNumReachedTrigger = false;

    [SerializeField] Image characterSpriteImage;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] List<DialogueLine> tutorialLines;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] AudioSource audioSource;
    public static DialogueManager instance;
    private int dialogueIndex;

    private void Awake()
    {
        instance = this;
        movementTrigger = true;
        dialogueIndex = 0;
        ShowDialogueLine();
    }

    private void Update()
    {
        if (!inhaleTrigger && dialogueIndex == 2 && !dialogueBox.activeSelf)
        {
            handleDelay(0);
            inhaleTrigger = true;
            dialogueIndex = 3;
            ShowDialogueLine();
        }
        if (inhaleTrigger && InputManager.instance.button_inhale && !releaseTrigger)
        {
            releaseTrigger = true;
            dialogueIndex = 4;
            ShowDialogueLine();
            StartCoroutine(handleDelay(2));
        }
        if (playerInventory.getNumEnemiesCollected() == playerInventory.getGoalNumEnemies() && !targetNumReachedTrigger)
        {
            targetNumReachedTrigger = true;
            dialogueIndex = 7;
            ShowDialogueLine();
        }
    }

    public void setDeadTrigger()
    {
        if (!deadBodyTrigger)
        {
            deadBodyTrigger = true;
            dialogueIndex = 1;
            ShowDialogueLine();
            StartCoroutine(handleDelay(1));
        }
    }

    private void ShowDialogueLine()
    {
        if (dialogueIndex >= 0 && dialogueIndex < tutorialLines.Count)
        {
            DialogueLine line = tutorialLines[dialogueIndex];
            characterSpriteImage.sprite = line.charSprite;
            dialogueText.text = line.line;
            dialogueBox.SetActive(true);
            line.playVoiceLine(audioSource);
        }
    }

    private IEnumerator handleDelay(int numFrames)
    {
        if(numFrames > 0)
        {
            for (int i = 1; i <= numFrames; i++)
            {
                yield return new WaitForSeconds(2);
                dialogueIndex++;
                ShowDialogueLine();
            }
        }
        yield return new WaitForSeconds(3);
        dialogueBox.SetActive(false);
    }
}
