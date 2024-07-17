using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Image playerHealthBar;
    [SerializeField] TextMeshProUGUI inventoryText;

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerHealth.getHealth() / (float)playerHealth.MAX_HEALTH;
        inventoryText.text = $"{inventory.getNumEnemiesCollected()} / {inventory.getGoalNumEnemies()}";
    }
}
