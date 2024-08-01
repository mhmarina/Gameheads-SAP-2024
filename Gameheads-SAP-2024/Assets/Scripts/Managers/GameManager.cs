using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //This is very rough, would need these actual scenes to map and test

    ///This is how we want to organize our build:
    ///0: Main Menu:
    ///     This may have the following canvasses:
    ///     - Title Screen
    ///     - Settings
    ///     - Controls, etc
    ///1: Start Cutscene
    ///     - This will have its own dialogue manager
    ///     - Different canvas for each frame, tied to the dialogue manager
    ///2: Level 1
    ///     The following canvases can be toggled here:
    ///     - Pause Menu
    ///     - Loss Screen
    ///     - Win Screen
    ///3: Final Cutscene
    ///     - Exact same structure as Start Scene
    ///4: Credits (?) ... moves to main menu directly after end or if player clicks anywhere
    
    public static GameManager instance;
    [SerializeField] string MainMenuScene;
    [SerializeField] string StartCutscene;
    [SerializeField] string Level1Scene;
    [SerializeField] string FinalCutscene;
    [SerializeField] string Credits;

    private void Start()
    {
        if(!instance)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    public void playStartCutscene()
    {
        SceneManager.LoadScene(StartCutscene);
    }

    public void startGame()
    {
        SceneManager.LoadScene(Level1Scene);
    }

    public void playFinalCutScene()
    {
        SceneManager.LoadScene(FinalCutscene);
    }

    public void playCredits()
    {
        SceneManager.LoadScene(Credits);
    }
}
