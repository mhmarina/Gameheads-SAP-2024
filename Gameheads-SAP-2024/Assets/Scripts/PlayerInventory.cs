using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int enemiesCollected;
    [SerializeField] int goalNumEnemies;

    private void Start()
    {
        enemiesCollected = 0;
    }
    public int getNumEnemiesCollected()
    {
        return enemiesCollected;
    }
    public void addEnemytoInventory()
    {
        enemiesCollected++;
        Debug.Log(enemiesCollected);
    }
    public int getGoalNumEnemies()
    {
        return goalNumEnemies;
    }
    private void Update()
    {
        if(enemiesCollected == goalNumEnemies)
        {
            //do something
        }
    }
}
