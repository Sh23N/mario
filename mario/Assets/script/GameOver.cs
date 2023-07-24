using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class GameOver : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Control.marioDeath)
        {
            print("ddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            gameObject.SetActive(true);
        }
    }
}
