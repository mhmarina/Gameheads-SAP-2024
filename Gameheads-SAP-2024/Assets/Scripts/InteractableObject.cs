using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] public bool canBePulled;
    [SerializeField] public bool canBePushed;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    public void moveTowardsPlayer(float mS)
    {
        transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, mS * Time.deltaTime));
    }
}
