using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class win : MonoBehaviour
{
    public GameObject winLevelCanvas;
    public AudioSource winSound;
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
            print("win level");
             winSound.Play();
            Control.winLevel++;
           winLevelCanvas.SetActive(true);
            //SceneManager.LoadScene(Control.winLevel);
            
        }
    }
}
