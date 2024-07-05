using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] TextMeshProUGUI playerHealthText;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Player Health: " + playerHealth.getHealth();
    }
}
