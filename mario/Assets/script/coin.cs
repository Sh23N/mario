using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int value = Control.value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D a)
    {
        if (a.gameObject.tag == "Player")
        {
            Control.value++;
            Destroy(gameObject);
            print("val" + Control.value);

        }
        if (a.gameObject.tag == "block")
        {
            Destroy(gameObject);
            print("valid");

        }


    }
}
