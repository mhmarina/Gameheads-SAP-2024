using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Serialized for metrics testing
    [SerializeField] private int currentHealth;
    [SerializeField] public int MAX_HEALTH;

    private void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth(int h)
    {
        this.currentHealth = Mathf.Clamp(h, 0, MAX_HEALTH);
    }
}
