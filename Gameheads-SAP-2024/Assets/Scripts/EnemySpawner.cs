using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int spawnRate;
    [SerializeField] private GameObject enemyObject;

    public void setSpawnRate(int spawnRate) {
        this.spawnRate = spawnRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int timer = 0;
        while(timer < spawnRate * Time.deltaTime)
        {
            timer++;
        }
        GameObject.Instantiate(enemyObject); //TODO: randomize or change spawn position
    }
}
