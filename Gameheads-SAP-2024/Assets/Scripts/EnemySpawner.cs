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

    }

    private void Spawn() {
        GameObject.Instantiate(enemyObject);
    }
}
