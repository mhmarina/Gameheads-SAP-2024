using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// TODO: Create Enemy and Mana Managers.
    /// This will hold an array of mana and enemy objects.
    /// This allows us to control how many mana and enemies are in the scene
    /// it'll also make accessing them from the player for example easier..
    /// </summary>

    public enum pushPullType
    {
        CAN_PUSH,
        CAN_PULL,
        BOTH,
        NONE,
    };

    protected bool canMoveTowardPlayer = true;
    protected string objectType;
    protected pushPullType pushOrPull;
    [SerializeField] float pullRange;

    public abstract void onCollisionWithPlayer(GameObject player);

    public void onInhale(GameObject playerObject, float pullSpeed)
    {
        float distance = Vector2.Distance(playerObject.transform.position, transform.position);
        //Debug.Log($"inhale: {pushOrPull}");
        if ((pushOrPull == pushPullType.CAN_PULL || pushOrPull == pushPullType.BOTH) && distance <= pullRange)
        {
            if (getObjectType() == "enemy")
            {
                Vector2 rayDirection = (playerObject.transform.position - this.transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, rayDirection, distance, LayerMask.GetMask("TransparentFX"));
                Debug.DrawRay(this.transform.position, rayDirection * distance, Color.red);
                if (hit.collider != null)
                {
                    return;
                }
            }
            transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, pullSpeed * Time.deltaTime));
        }
    }

    //work on this more
    //maybe apply some velocity to push the object away idk..
    public void onExhale(GameObject playerObject, float pushForce)
    {
        //raycast logic:
        if ((pushOrPull == pushPullType.CAN_PUSH || pushOrPull == pushPullType.BOTH))
        {
            if (getObjectType() == "enemy")
            {
                float distance = Vector2.Distance(playerObject.transform.position, this.transform.position);
                Vector2 rayDirection = (playerObject.transform.position - this.transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, rayDirection, distance, LayerMask.GetMask("TransparentFX"));
                Debug.DrawRay(this.transform.position, rayDirection * distance, Color.red);
                if (hit.collider != null)
                {
                    return;
                }
            }
            Vector2 direction = (Vector2)(transform.position - playerObject.transform.position).normalized;
            Vector2 targetPosition = (Vector2)transform.position + (direction * pushForce * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, pushForce * Time.deltaTime / 10);

            //Vector2 direction = transform.position - playerObject.transform.position;
            //Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.AddForce(direction.normalized * pushForce, ForceMode2D.Impulse);
        }
    }

    public string getObjectType()
    {
        return objectType;
    }
}
