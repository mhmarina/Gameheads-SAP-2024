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
        button_inhale = Input.GetKey(KeyCode.Space);
        button_exhale = Input.GetKey(KeyCode.M);
        if(button_verticalInput == 0 && button_horizontalInput == 0)
        {
            isMoving = false;
        }
        mouse_clicked = Input.GetMouseButtonDown(0);
        pauseKey = Input.GetKeyDown(KeyCode.Escape);
    }
}
