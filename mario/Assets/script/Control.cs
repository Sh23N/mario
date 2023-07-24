using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedH = 5;
    public float speedV = 25;

    private bool facingRight = true;//true for right

    public FixedJoystick joystick;
    Vector2 move;

    public GameObject mobileJ;

    private bool desktop;

    static public bool jump;

    public static bool OnGround = true;

    public Animator animator;

    public static int value = 0;

    public TMP_Text showVal;

    //public GameObject preobj;
    public GameObject Enemy;

    private float detectRange = 8f;

    bool[] createEnemies;
    int L = 0;

    public static bool marioDeath = false;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    public AudioSource winSound;
    public AudioSource coinSound;
    bool  playDeath=false;

    static public bool coinBlock = false;

    static public int winLevel = 1;// for every level that win winLevel++

    public GameObject GameOverCanvas;
    public GameObject levelWinCanvas;
    void Start()
    {
        marioDeath = false;
       //// source = GetComponent<AudioSource>();
        createEnemies = new bool[30];

        for (int i = 0; i < 30; i++)
        {
            createEnemies[i] = false;
        }
        
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
 

    private void Update()
    {
       
        GameObject[] nearbymario = GameObject.FindGameObjectsWithTag("emptyEnemy");
        L = nearbymario.Length;
        for (int i = 0; i < L; i++)
        {
            float dis = Vector2.Distance(transform.position, nearbymario[i].transform.position);
            if (dis <= detectRange && createEnemies[i]==false)
            {
               
                createEnemies[i]=true;
                Instantiate(Enemy, new Vector2(nearbymario[i].transform.position.x, nearbymario[i].transform.position.y), Quaternion.identity);
            }
        }
        if (marioDeath)
        {
            
            GameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
        if ( marioDeath ==true && !playDeath)
        {   animator.SetBool("Death", true);
            deathSound.Play();
            print("death");
            playDeath = true;
            
        }
        if (coinBlock)
        {
            coinSound.Play();
            coinBlock = false;
        }


        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//*********

        if (desktop)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpSound.Play();
                animator.SetBool("isjump", true);
          
                if (OnGround)
                {
                    rb.AddForce(Vector2.up * speedV, ForceMode2D.Impulse);
                    OnGround = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetFloat("Speed", Mathf.Abs(0.2f));
                // r = false;
                if (facingRight == false)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = true;
                rb.AddForce(Vector2.right * speedH, ForceMode2D.Impulse);
                

            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow))
            {   //if(!OnGround)
                animator.SetBool("isjump",false);

                animator.SetFloat("Speed", Mathf.Abs(0.01f));
            }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetFloat("Speed", Mathf.Abs(0.2f));
                // l = false;
                if (facingRight == true)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                rb.AddForce(Vector2.left * speedH, ForceMode2D.Impulse);

            }
           /* if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                animator.SetFloat("Speed", Mathf.Abs(0.05f));

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetFloat("Speed", Mathf.Abs(0.05f));
            }*/
        }
        else if (!desktop)
        {

            if (joystick.Horizontal > 0)
            {
                if (facingRight == false)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = true;
                animator.SetFloat("Speed", Mathf.Abs(0.2f));
                transform.Translate(Vector3.right * speedH * Time.deltaTime);
                print("right");
            }
            if (joystick.Horizontal < 0)
            {
                if (facingRight == true)
                    transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                animator.SetFloat("Speed", Mathf.Abs(0.2f));
                transform.Translate(Vector3.right * speedH * Time.deltaTime);
                print("left");
            }
            if (joystick.Horizontal == 0 && OnGround)
            {
                animator.SetBool("isjump", false);

                animator.SetFloat("Speed", Mathf.Abs(0.01f));
                print("statick");
            }

        }
        showVal.text=value.ToString();
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

               jumpSound.Play();
               animator.SetBool("isjump", true);
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
        if (a.gameObject.tag == "ignor")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), a.collider);
            print("ignor");

        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("level"+winLevel);
    }
    public void levelSelect()
    {
        SceneManager.LoadScene("menu");
    }
    public void NextSelect()
    {
        SceneManager.LoadScene("level" + winLevel);
    }


}


