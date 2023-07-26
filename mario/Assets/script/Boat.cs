using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float speed = 5f;
    bool right =false;
    public float offset = 30f;
    
    Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject != null)
        {
            if (right)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);


            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);


            }
            if (transform.position.x >= initialPosition.x + offset)
            {
          
                right = false;
            }
            if (transform.position.x < initialPosition.x - offset)
            {
               
                right = true;
            }
        }
    }
}
