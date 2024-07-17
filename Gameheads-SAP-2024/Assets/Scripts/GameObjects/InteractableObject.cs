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

    protected string objectType;
    protected pushPullType pushOrPull;

    public abstract void onCollisionWithPlayer(GameObject player);

    public void onInhale(GameObject playerObject, float pullSpeed)
    {
        Debug.Log($"inhale: {pushOrPull}");
        if (pushOrPull == pushPullType.CAN_PULL || pushOrPull == pushPullType.BOTH)
        {
            Debug.Log($"Player Object is: {playerObject}");
            Debug.Log($"Old Pos: {transform.position}");
            transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, pullSpeed * Time.deltaTime));
            Debug.Log($"New Pos: {transform.position}");
        }
    }

    public void onExhale(GameObject playerObject, float pushForce)
    {
        Debug.Log($"exhale: {pushOrPull}");
        if (pushOrPull == pushPullType.CAN_PUSH || pushOrPull == pushPullType.BOTH)
        {
            Debug.Log($"Player Object is: {playerObject}");
            Vector2 direction = (Vector2)(transform.position - playerObject.transform.position).normalized;
            Vector2 targetPosition = (Vector2)direction * pushForce;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime);

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
