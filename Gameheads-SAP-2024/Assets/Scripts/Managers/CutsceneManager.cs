using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] cutSceneSprites;
    [SerializeField] Image cutSceneImage;
    private int imageIndex;
    void Start()
    {
        if(cutSceneSprites.Length != 0)
        {
            cutSceneImage.sprite = cutSceneSprites[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.mouse_clicked)
        {
            imageIndex++;
            if(imageIndex < cutSceneSprites.Length)
            {
                cutSceneImage.sprite = cutSceneSprites[imageIndex];
            }
            else
            {
                if(SceneManager.GetActiveScene().name == "Opening Cutscene")
                {
                    SceneManager.LoadScene("Level, Art, UI");
                }
                else
                {
                    //could also load credits here
                    //when we have credits ready.
                    //credits could then go to main menu
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    }
}