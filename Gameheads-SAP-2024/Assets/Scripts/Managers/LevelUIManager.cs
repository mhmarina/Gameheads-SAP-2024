using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject lossCanvas;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI lossScore;
    private GameObject player;

    void Update()
    {
        if (!player) {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player)
            {
                inventory.SetActive(false);
                minimap.SetActive(false);
                lossCanvas.SetActive(true);
                lossScore.text = currentScore.text;
            }
        }
    }
}
