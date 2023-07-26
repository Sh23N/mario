using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class coopa : MonoBehaviour
{
    public float speed = 2f;
    bool right = true;
    public float offset = 5f;
    public Animator animator;
    Vector2 initialPosition;
    bool isInShell=false;
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
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                
                
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                
                
            }
            if (transform.position.x >= initialPosition.x + offset)
            {
                    transform.Rotate(0f, 180f, 0f);
                right = false;
            }
            if (transform.position.x < initialPosition.x - offset)
            {
                    transform.Rotate(0f, 180f, 0f);
                right = true;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D a)
    {
        if (gameObject != null)
        {
            if (a.gameObject.tag == "Player" && transform.position.y+0.5 < a.contacts[0].point.y)
            {
                //Control.value++;
                //  Death = true;

                print("Coopa enemy in its shell");
                print(transform.position.y);
                print(a.contacts[0].point.y);

                animator.SetBool("isInShell", true);
                isInShell = true;
               /* if (isInShell)
                {
                    Destroy(gameObject);
                }*/
               /* else if (!isInShell)
                {
                    animator.SetBool("isInShell", true);
                    
                }*/
                //t = Time.time;
            }
            else if (a.gameObject.tag == "Player" && Control.value<10)
            {
                if(!isInShell) 
                Control.marioDeath = true;
                // a.gameObject.SetActive(false);

                print("..........................");

            }
        }
    }
}

