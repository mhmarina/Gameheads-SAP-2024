using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject lossCanvas;
    private GameObject player;

    void Update()
    {
        if (!player) {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player)
            {
                Time.timeScale = 0;
                scoreText.SetActive(false);
                minimap.SetActive(false);
                lossCanvas.SetActive(true);
            }
        }
    }
}
