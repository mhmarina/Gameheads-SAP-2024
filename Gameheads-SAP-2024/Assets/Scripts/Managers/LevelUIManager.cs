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
        if(playerInventory.getNumEnemiesCollected() == playerInventory.getGoalNumEnemies())
        {
            handleVictory();
        }

        //handle pause
        if (Input.GetKeyDown(KeyCode.Escape))
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
        while (waitTime < 10 * Time.deltaTime)
        {
            waitTime += 1 * Time.deltaTime;
        }
        SceneManager.LoadScene("Final Cutscene");
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
