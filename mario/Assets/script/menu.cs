using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class menu : MonoBehaviour
{
    float t;

    public Button level1;
    public Button level2;
    public Button level3;

    public Sprite lockImage;
    public Sprite notLockImage;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-t>=1.5f)
        {
            level1.gameObject.SetActive(true);
            level2.gameObject.SetActive(true);
            level3.gameObject.SetActive(true);

        }
        if (Control.winLevel == 1)
        {
            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";
        }
        if (Control.winLevel == 2)
        {
            level2.GetComponent<Image>().sprite = notLockImage;
            level2.GetComponentInChildren<TMP_Text>().text = "2";

            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";
        }
        if (Control.winLevel >= 3 )
        {
            level3.GetComponent<Image>().sprite = notLockImage;
            level3.GetComponentInChildren<TMP_Text>().text = "3";

            level2.GetComponent<Image>().sprite = notLockImage;
            level2.GetComponentInChildren<TMP_Text>().text = "2";

            level1.GetComponent<Image>().sprite = notLockImage;
            level1.GetComponentInChildren<TMP_Text>().text = "1";
        }

    }
    public void OnClicklevel1()
    {   if(Control.winLevel>=1)
          SceneManager.LoadScene("level1");
    }
    public void OnClicklevel2()
    {
        if (Control.winLevel >= 2)
            SceneManager.LoadScene("level2");
    }
    public void OnClicklevel3()
    {
        if (Control.winLevel >= 3)
            SceneManager.LoadScene("level3");
    }

}
