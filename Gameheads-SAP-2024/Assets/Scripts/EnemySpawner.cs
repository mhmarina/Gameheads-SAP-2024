using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject enemyObject;

    public void setSpawnRate(int spawnRate) {
        this.spawnRate = spawnRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        InvokeRepeating("moveRandomly", 10, 10);
    }

    private void Spawn() {
        GameObject.Instantiate(enemyObject);
    }

    private void moveRandomly()
    {
        transform.position = new Vector2(Random.Range(0, Screen.width),Random.Range(0, Screen.height));
    }
}
