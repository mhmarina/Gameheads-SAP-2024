using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaMovement : MonoBehaviour
{
    /* I would like to have the mana find the player and orbit around it no matter 
     * how the player moves. */
    private GameObject player;
    [SerializeField] int radius;
    [SerializeField] float orbitSpeed;
    private InputManager im;
    private Vector2 velocity = Vector2.zero;
    [SerializeField] private float smoothTime = 0.0f;

    //angle in radians from 0 to 2pi
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        im = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        angle = Random.Range(0, 2 * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        if(!im.button_inhale)
        {
            angle += orbitSpeed * Time.deltaTime;
            float h = player.transform.position.x - radius * Mathf.Cos(angle);
            float k = player.transform.position.y - radius * Mathf.Sin(angle);
            transform.position = Vector2.SmoothDamp(transform.position, new Vector2(h, k), ref velocity, smoothTime);
        }
    }
}