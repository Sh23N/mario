using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightignore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int i = 0;
    void OnCollisionExit2D(Collision2D a)
    {   
        if (a.gameObject.tag == "endBlock")
        {
            includ_Enemy.rightBounded = true;
            print("exitRight"+i+gameObject.name);
            i++;
            if (gameObject.name == "colliderR")
            {
                includ_Enemy.rightBounded = true;
            }
            else if(gameObject.name == "colliderL")
            {
                includ_Enemy.leftBounded = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D a)
    {
        if (a.gameObject.tag == "Coin")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), a.collider);

        }

    
}
