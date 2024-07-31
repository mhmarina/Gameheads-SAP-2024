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
    
    static GameManager instance;
    [SerializeField] Scene MainMenuScene;
    [SerializeField] Scene StartCutscene;
    [SerializeField] Scene Level1Scene;
    [SerializeField] Scene FinalCutscene;
    [SerializeField] Scene Credits;

    private void Start()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene.name);
    }

    public void playStartCutscene()
    {
        SceneManager.LoadScene(StartCutscene.name);
    }

    public void startGame()
    {
        SceneManager.LoadScene(Level1Scene.name);
    }

    public void playFinalCutScene()
    {
        SceneManager.LoadScene(FinalCutscene.name);
    }

    public void playCredits()
    {
        SceneManager.LoadScene(Credits.name);
    }
}
