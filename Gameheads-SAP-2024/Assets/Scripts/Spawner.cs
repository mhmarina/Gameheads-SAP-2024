using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private bool randomizeSpawnPos;

    public void setSpawnRate(int spawnRate) {
        this.spawnRate = spawnRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        if (randomizeSpawnPos)
        {
            InvokeRepeating("randomizePosition", 1, 1);
        }
    }

    private void Spawn() {
        GameObject.Instantiate(spawnObject, transform.position, transform.rotation);
    }

    private void randomizePosition()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;


        transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
    }
}
