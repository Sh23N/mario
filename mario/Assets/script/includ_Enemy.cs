using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class includ_Enemy : MonoBehaviour
{
    Vector2 initialPosition;
    public float speed = 1f;
    bool right = false;
    public float offset = 2f;

    public static bool rightBounded=false;
    public static bool leftBounded=false;



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
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (/*transform.position.x >= initialPosition.x + offset ||*/ rightBounded == true)
            {
                right = false;
                rightBounded = false;
            }

            if (/*transform.position.x < initialPosition.x - offset || */ leftBounded == true)
            {
                right = true;
                leftBounded = false;
            }
        }
    }
}