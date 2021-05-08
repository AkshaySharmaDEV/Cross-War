using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Vector3 lastVelocity;
    // private Rigidbody2D rb;
    private Rigidbody2D rb;


    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            //try avoiding to search for too many objects during collision
            case "bullet":
                //Setting gameobject inactive is way better than destroying it everytime it collides with some object
                break;
            case "player":
                gameObject.SetActive(false);
                break;
            case "enemy":
                gameObject.SetActive(false);
                break;
            case "boundary":
                break;
        }
    }
}
