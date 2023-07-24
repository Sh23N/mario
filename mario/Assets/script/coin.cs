using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class coin : MonoBehaviour
{
    public int value = Control.value;

    public AudioSource coinSound;

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
            coinSound.Play();
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
