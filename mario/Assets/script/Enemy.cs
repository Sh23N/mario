using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 initialPosition;
    public float speed = 2f;
    bool right = true;
    public float offset = 5f;


    public Animator animator;

    bool Death = false;
    float t=0f;
   //
    public static  bool pd=false;
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
            if (transform.position.x >= initialPosition.x + offset)
                right = false;
            if (transform.position.x < initialPosition.x - offset)
                right = true;
        }
        if (Death && Time.time - t >= 0.2)
        {
            //animator.SetBool("disapear", true);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D a)
    {  if (gameObject != null)
        {
            if (a.gameObject.tag == "Player" && transform.position.y+0.01 < a.contacts[0].point.y && Control.OnGround==false)
            {
                //Control.value++;
                Death = true;
                
                print("enemy dieeeeeeee");
                animator.SetBool("isDeath", true);
                t=Time.time;
            }
            else if (a.gameObject.tag == "Player")
            {
                //C//ontrol.value++;
                
                pd = true;
                print("..........................");

            }
            if (a.gameObject.tag == "Coin")
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), a.collider);

            if (a.gameObject.tag == "stop")
            {
                if(right==false)
                    right = true;
                else
                    right=false;
            }

        }
       


    }
  /*  void OnCollisionExit2D(Collision2D a)
    {
        //print("ignor blochkkkkkkk");
        if (a.gameObject.tag == "block")
        {

           // print("ignor blochkkkkkkk");
            
        }
    }/*/


}
