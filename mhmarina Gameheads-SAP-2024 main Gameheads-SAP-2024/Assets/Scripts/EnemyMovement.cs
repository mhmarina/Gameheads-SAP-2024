using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootingSpeed;

    void Update()
    {
        InteractableObject iO = GetComponent<InteractableObject>();
        iO.setPullSpeed(moveSpeed);
        iO.moveTowardsPlayer();
    }
}
