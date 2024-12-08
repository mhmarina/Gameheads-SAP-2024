using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject lossCanvas;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI lossScore;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Boulder boulder;
    [SerializeField] int levelNumber;

    private GameObject player;
    private bool isPaused;

    private void Start()
    {
        if (pauseCanvas.activeSelf)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }
        Debug.Log(isPaused);
    }
    void Update()
    {
        //handle defeat
        if (!player) {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player)
            {
                handleDefeat();
            }
        }
        //handle victory
        if(boulder.isInCave)
        {
            handleVictory();
        }

        //handle pause
        if (InputManager.instance.pauseKey)
        {
            if (!isPaused)
            {
                pauseGame();
            }
            else if (isPaused)
            {
                resumeGame();
            }
        }
    }

    public void handleDefeat()
    {
        inventory.SetActive(false);
        minimap.SetActive(false);
        lossCanvas.SetActive(true);
        lossScore.text = currentScore.text;
    }

    public void handleVictory()
    {
        //maybe wait or show a screen or some kind of transition idk.
        float waitTime = 0;
        while (waitTime < 30 * Time.deltaTime)
        {
            waitTime += 1 * Time.deltaTime;
        }
        if (levelNumber == 1)
        {
            SceneManager.LoadScene("Proto Level 2");
        }
        else if (levelNumber == 2) {
            SceneManager.LoadScene("Final Cutscene");
        }
    }

    public void pauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void resumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
