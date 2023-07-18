using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedH = 5;
    public float speedV = 7;

    private bool facingRight = true;//true for right
    private bool r = false;
    private bool l = false;
    private bool u = false;                               //public bool Arrow;//

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || u)
        {
            u = false;
            rb.AddForce(Vector2.up * speedV, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || r)
        {
            r = false;
            if (facingRight == false)
                transform.Rotate(0f, 180f, 0f);
            facingRight = true;
            rb.AddForce(Vector2.right * speedH, ForceMode2D.Impulse);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || l)
        {
            l = false;
            if (facingRight == true)
                transform.Rotate(0f, 180f, 0f);
            facingRight = false;
            rb.AddForce(Vector2.left * speedH, ForceMode2D.Impulse);

        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnClickup()
    {
        u = true;
    }
    public void OnClickright()
    {
        r = true;
    }
    public void OnClicleft()
    {
        l = true;
    }


}


