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
            if (dis <= detectRange && createEnemies[i]==false) // instantiate only one enemy in each empty enemy
            {
               
                createEnemies[i]=true;
                
                Instantiate(Enemy, new Vector2(nearbymario[i].transform.position.x, nearbymario[i].transform.position.y), Quaternion.identity);
            }
        }
       /* if (marioDeath )
        {
            
            GameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
           // value = value - 10;
        }*/
        if ( marioDeath ==true && !playDeath)
        {
            if (value < 15)
            { 
            animator.SetBool("Death", true);
            deathSound.Play();
            print("death");
            playDeath = true;
           
            GameOverCanvas.SetActive(true);//
            gameObject.SetActive(false);//
            }
           if(value >= 15)
           {
               value = value - 15;
               marioDeath = false;
                print("moreeeeee" + value);
           }

        }
        if (coinBlock)
        {
            coinSound.Play();
            coinBlock = false;
        }


        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//*********

        if (desktop)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))// jump
            {
                jumpSound.Play();// play sound for jump
                animator.SetBool("isjump", true);//play jump aniamtion
          
                if (OnGround)// prevent to jump higher when in jump
                {
                    rb.AddForce(Vector2.up * speedV, ForceMode2D.Impulse);// add force up
                    OnGround = false;// mario is not on Ground 

                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) // run right
            {
                animator.SetFloat("Speed", Mathf.Abs(0.2f));// play run animation
               
                if (facingRight == false)//to rotate his face 
                    transform.Rotate(0f, 180f, 0f);
                facingRight = true;
                rb.AddForce(Vector2.right * speedH, ForceMode2D.Impulse); //go right
                
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow))
            {   
                animator.SetBool("isjump",false);// stop playing jump animation

                animator.SetFloat("Speed", Mathf.Abs(0.01f));// stop playing run animation
            }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetFloat("Speed", Mathf.Abs(0.2f));//play animation for run
              
                if (facingRight == true)// rotate face to left
                    transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                rb.AddForce(Vector2.left * speedH, ForceMode2D.Impulse);//go left

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
            if (joystick.Horizontal > 0)// if joy stick to right
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
            if (OnGround)//prevent jump when jump
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
        if (a.gameObject.tag == "water")
        {
            marioDeath = true;
            print("die in water");
            GameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
                animator.SetBool("Death", true);
                deathSound.Play();

            }
    }
    public void Retry()
    {
        value = 0;
        SceneManager.LoadScene("level"+winLevel);
    }
    public void levelSelect()
    {
        value = 0;
        SceneManager.LoadScene("menu");
    }
    public void NextSelect()
    {
        value = 0;
        SceneManager.LoadScene("level" + winLevel);
    }
    public void OnClickClose()
    {
        Application.Quit();
    }
   


}


