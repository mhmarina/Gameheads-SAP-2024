using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //singleton class
    [HideInInspector]
    public float button_verticalInput;
    public float button_horizontalInput;
    public bool button_inhale;
    public bool button_exhale;
    public bool mouse_clicked;
    public bool isMoving = true;
    public static InputManager instance;
    public bool pauseKey;
    bool go_next;
    bool go_back;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        button_verticalInput = Input.GetAxis("Vertical");
        button_horizontalInput = Input.GetAxis("Horizontal");
        button_inhale = Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1");
        button_exhale = Input.GetKey(KeyCode.M) || Input.GetButton("Fire2");
        if(button_verticalInput == 0 && button_horizontalInput == 0)
        {
            isMoving = false;
        }
        if(button_horizontalInput < 0)
        {
            go_back = true;
        }
        else
        {
            go_back = false;
        }
        if(button_horizontalInput > 0)
        {
            go_next = true;
        }
        else
        {
            go_next = false;
        }
        mouse_clicked = Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1");
        pauseKey = Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel");
    }
}
