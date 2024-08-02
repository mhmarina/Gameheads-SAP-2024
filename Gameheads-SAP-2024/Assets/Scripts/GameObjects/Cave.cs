using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractableObject ib = collision.gameObject.GetComponent<InteractableObject>();
        if (ib?.getObjectType() == "enemy" /*&& ib.isPushed*/)
        {
            inventory.addEnemytoInventory();
            Destroy(collision.gameObject);
        }
    }
}
