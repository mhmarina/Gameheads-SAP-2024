using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI inventoryText;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player Health: " + playerHealth.getHealth();
        inventoryText.text = $"{inventory.getNumEnemiesCollected()} / {inventory.getGoalNumEnemies()}";
    }
}
