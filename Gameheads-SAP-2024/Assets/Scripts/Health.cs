using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private int MAX_HEALTH;

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
        this.currentHealth = h;
    }
}
