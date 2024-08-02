using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isInCave;
    [SerializeField] PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        isInCave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInventory.getNumEnemiesCollected() == playerInventory.getGoalNumEnemies())
        {
            rb.isKinematic = false;
        }
    }
}
