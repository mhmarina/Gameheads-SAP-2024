using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    //I want this array to map to the cutscenesprites array
    [SerializeField] int[] numToClick;
    [SerializeField] Sprite[] cutSceneSprites;
    [SerializeField] Image cutSceneImage;
    private int imageIndex;
    //either want to have an array of frame objects
    //which consist of sprite and int numToClick or map
    //both arrays together
    //I'm leaning towards OOP..
    private int numClicked;
    void Start()
    {
        if(cutSceneSprites.Length != 0)
        {
            cutSceneImage.sprite = cutSceneSprites[0];
        }
        imageIndex = 0;
        numClicked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.mouse_clicked)
        {
            //move through numToClick, changing the dialogue
            //when numToClick is reached, reset to 0 and change the sprite image
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
