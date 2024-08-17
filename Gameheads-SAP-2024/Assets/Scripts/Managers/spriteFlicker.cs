using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spriteFlicker : MonoBehaviour
{

    [SerializeField] GameObject flickerIcon;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeIconState", 2f,1f);
    }

    void ChangeIconState()
    {
        flickerIcon.SetActive(!flickerIcon.activeInHierarchy);
            
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
