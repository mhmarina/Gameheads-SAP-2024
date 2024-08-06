using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class CutsceneManager : MonoBehaviour
{
    [System.Serializable]
    public class CutsceneFrame
    {
        public Sprite sprite;
        public List<DialogueLine> dialogueLines;
    }

    [SerializeField] CutsceneFrame[] cutSceneFrames;
    [SerializeField] Image cutSceneImage;
    [SerializeField] Image characterSpriteImage;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] UnityEvent goToNextScene;

    private int imageIndex;
    private int dialogueIndex;

    void Start()
    {
        imageIndex = 0;
        dialogueIndex = 0;
        setDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (cutSceneFrames[imageIndex].dialogueLines.Count == 0 || cutSceneFrames[imageIndex].dialogueLines[dialogueIndex].line == "")
        {
            dialogueBox.SetActive(false);
        }
        else
        {
            dialogueBox.SetActive(true);
        }
        if (InputManager.instance.mouse_clicked)
        {
            dialogueIndex++;
            if (dialogueIndex >= cutSceneFrames[imageIndex].dialogueLines.Count)
            {
                dialogueIndex = 0;
                imageIndex++;
                if(imageIndex >= cutSceneFrames.Length)
                {
                    goToNextScene.Invoke();
                }
            }
            setDialogue();
        }
    }

    private void setDialogue()
    {
        cutSceneImage.sprite = cutSceneFrames[imageIndex].sprite;
        if(cutSceneFrames[imageIndex].dialogueLines.Count != 0 && dialogueIndex < cutSceneFrames[imageIndex].dialogueLines.Count)
        {
            dialogueText.text = cutSceneFrames[imageIndex].dialogueLines[dialogueIndex].line;
            characterSpriteImage.sprite = cutSceneFrames[imageIndex].dialogueLines[dialogueIndex].charSprite;
            cutSceneFrames[imageIndex].dialogueLines[dialogueIndex].playVoiceLine(audioSource);
        }
    }
}
