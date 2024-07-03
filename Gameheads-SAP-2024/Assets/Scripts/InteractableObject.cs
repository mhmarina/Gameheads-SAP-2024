using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] public bool canBePulled;
    [SerializeField] public bool canBePushed;
    [SerializeField] private float pullSpeed;

    public void setPullSpeed(float sp)
    {
        this.pullSpeed = sp;
    }

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    public void moveTowardsPlayer()
    {
        transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, pullSpeed * Time.deltaTime));
    }
}
