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
    [SerializeField] Image playerBreathBar;
    [SerializeField] PlayerController playerController;

    //green, yellow, red..

    // Update is called once per frame
    void Update()
    {
        if(playerHealth && inventory && playerController)
        {
            float breathFill = playerController.breathMeter / playerController.breathMax;
            Color breathColor;
            if(breathFill <= 0.3)
            {
                breathColor = Color.green;
            }
            else if(breathFill > 0.3 && breathFill <= 0.6)
            {
                breathColor = Color.yellow;
            }
            else
            {
                breathColor = Color.red;
            }
            playerHealthBar.fillAmount = playerHealth.getHealth() / (float)playerHealth.MAX_HEALTH;
            playerBreathBar.fillAmount = breathFill;
            playerBreathBar.color = breathColor;
            inventoryText.text = $"{inventory.getNumEnemiesCollected()} / {inventory.getGoalNumEnemies()}";
        }
    }
}
