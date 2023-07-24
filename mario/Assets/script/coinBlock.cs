
using UnityEngine;

public class coinBlock : MonoBehaviour
{   public GameObject coin;

    public Rigidbody2D rb;

    int i = 1;

    int value = Control.value;
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
        if (a.gameObject.tag == "Player"  && transform.position.y > a.contacts[0].point.y && i==1)
        {
            Control.value++;
            GameObject C=Instantiate(coin, transform.position + Vector3.up * 2, transform.rotation);
            rb = C.AddComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            print("down");
            print("val" + Control.value);
            i++;
            Control.coinBlock = true;
        }


    }
}
