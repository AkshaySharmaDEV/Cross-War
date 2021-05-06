using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;

    Vector3 lastVelocity;

    public GameObject bullet;

    


    public float speed = 50.0f;
    // private Rigidbody2D rb;
    private Vector2 screenBounds;

    // public GameObject explosion;


    public int collisionCount = 0;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        


    }


    void Update()
    {

        lastVelocity = rb.velocity;
        rb = GetComponent<Rigidbody2D>();



        
        
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){



        // var speed = lastVelocity.magnitude;
            
        // var direction = Vector3.Reflect(lastVelocity.normalized,collision.contacts[0].normal);


        // rb.velocity = direction * Mathf.Max(speed, 0f);


        

        
        // if (collision.gameObject.tag == "enemy" ){

        //     collisionCount += 1;

        // }

        // if(collisionCount == 1){

            
            
        //     // Debug.Log("1");

            
        // }

        // if(collisionCount == 2){

            
            
        //     // Debug.Log("2");

            
        // }

        
        // if(collisionCount == 3){

        //     GameObject e = Instantiate(explosion) as GameObject;
        //     e.transform.position = transform.position;
        //     Destroy(collision.gameObject);
        //     Destroy(this.gameObject);
        //     Destroy(e, 2f);

            
            
            
            

            
        // }


        switch (collision.gameObject.tag)
        {
            // //try avoiding to search for too many objects during collision
            // case "bullet":
            //     //Setting gameobject inactive is way better than destroying it everytime it collides with some other
            //     collision.gameObject.SetActive(false);
            //     gameObject.SetActive(false);
            //     break;
            // case "Player":
            //     gameObject.SetActive(false);
            //     break;
            // case "enemy":
            //     gameObject.SetActive(false);
            //     GameObject e = Instantiate(explosion) as GameObject;
            //     e.transform.position = transform.position;
            //     Destroy(e, 2f);
            //     break;
            case "Block":
                var speed = lastVelocity.magnitude;
                // GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
                var direction = Vector3.Reflect(lastVelocity.normalized,collision.contacts[0].normal);
                rb.velocity = direction * Mathf.Max(speed, 0f);
                break;
        }

        
       

        

        
        

        // if(collision.gameObject.tag == "enemy"){
        //     GameObject e = Instantiate(explosion) as GameObject;
        //     e.transform.position = transform.position;
        //     Destroy(collision.gameObject);
        //     Destroy(this.gameObject);
        //     Destroy(e, 2f);



            
        // }
        // if(collision.gameObject.tag == "Player"){
        //     GameObject e = Instantiate(explosion) as GameObject;
        //     e.transform.position = transform.position;
        //     Destroy(collision.gameObject);
        //     Destroy(this.gameObject);
        // }


        

        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        // Destroy(bullet, 3f);

        

    }


  
    
   
    
}
