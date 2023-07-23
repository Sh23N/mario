using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
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
        if (a.gameObject.tag != "Enemy")
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), a.collider);
    }
}
