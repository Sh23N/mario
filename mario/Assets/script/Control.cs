using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedH = 5;
    public float speedV = 7;

    private bool facingRight = true;//true for right
    private bool r = false;
    private bool l = false;
    private bool u = false;
    //public bool Arrow;//

    public FixedJoystick joystick;
    Vector2 move;

    public GameObject mobileJ;

    private bool desktop;

    public bool jump;

    bool OnGround = true;
   
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            desktop = true;
            mobileJ.SetActive(false);
            print("Desktop");
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            desktop =false;
            mobileJ.SetActive(true);
            print("Android");

        }

    }
   /* void Update()
    { if (desktop)
        {


        }
        else if (!desktop)
        {


        }
        /*if (joystick.Horizontal > 0)
        {
            print("r");
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
        else if(joystick.Horizontal <= 0)
        {
            print("l");
            if (facingRight == true)
                 transform.Rotate(0f, 180f, 0f);
                facingRight = false;
        }
        // move.y=joystick.Vertical;*/

   // }

    private void Update()
    {
        print(move.y);
        if (desktop)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // u = false;
                if (OnGround)
                {
                    rb.AddForce(Vector2.up * speedV, ForceMode2D.Impulse);
                    OnGround = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // r = false;
                if (facingRight == false)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = true;
                rb.AddForce(Vector2.right * speedH, ForceMode2D.Impulse);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // l = false;
                if (facingRight == true)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                rb.AddForce(Vector2.left * speedH, ForceMode2D.Impulse);

            }
        }
        else if (!desktop)
        {   
        
            transform.Translate(new Vector3(joystick.Horizontal, 0, 0) * speedH * Time.deltaTime);

        }

        /*  if (Physics2D.Raycast(transform.position, -transform.right,10))
          {  Debug.DrawRay(transform.position, -transform.right, Color.red);
              i++;
              OnGround = true;
              print("ground"+i);
          }*/

    }
    // Start is called before the first frame update

    public void OnClickup()
    { 
            if (OnGround)
            {
                rb.AddForce(Vector2.up * speedV, ForceMode2D.Impulse);
                OnGround = false;
            }
  
    }
    
    void OnCollisionEnter2D(Collision2D a)
    {
        if (a.gameObject.tag == "block")
           {
            OnGround = true;
            print("block");

            }
    }

}


