using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private bool randomizeSpawnPos;
    [SerializeField] private GameObject player;

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

    private void Update()
    {
        if (!player)
        {
            Destroy(gameObject);
        }
    }

    private void Spawn() {
        ObjectManager.instance.addToList(GameObject.Instantiate(spawnObject, transform.position, transform.rotation));
    }

    private void randomizePosition()
    {
        transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
    }
}
