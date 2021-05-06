using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    



    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public GameObject projectile;

    public float speed;


    // public int collisionCount = 0;


    Vector3 localScale;
    [Header("Enemy Health Sprite")]
    public GameObject Indicator;
    [Header("After Death Explosion")]
    public GameObject explosion;
    
    [Header("Enemy Max. Health")]
    public float Health;
    [Header("Enemy Damage")]
    public float Damage;


    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;



        

    }


    

    // Update is called once per frame
    void Update(){
        player = GameObject.FindWithTag("Player").transform;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;


        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){

            transform.position = this.transform.position;

        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

        if(timeBtwShots <= 0){

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


        

        
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    // private void OnCollisionEnter2D(Collision2D collision) {
 
        

    //     if (collision.gameObject.tag == "bullet" ){

    //         collisionCount += 1;

    //     }

    //     if(collisionCount == 1){

            
    //         Indicator.transform.localScale = new Vector3(0.24f,0.11f,0f);
    //         Debug.Log("1");

            
    //     }

    //     if(collisionCount == 2){

            
    //         Indicator.transform.localScale = new Vector3(0.12f,0.11f,0f);
    //         Debug.Log("2");

            
    //     }

        
    //     if(collisionCount == 3){

            
    //         Indicator.transform.localScale = new Vector3(0f,0.11f,0f);
    //         Debug.Log("3");
            
    //         GameObject e = Instantiate(explosion) as GameObject;
    //         e.transform.position = transform.position;
    //         // Destroy(collision.gameObject);
    //         // Destroy(this.gameObject);
    //         // Destroy(e, 2f);
    //         gameObject.SetActive(false);
    //         collision.gameObject.SetActive(false);
            
            

            
    //     }

        
    // }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bullet":
                
                Indicator.transform.localScale = new Vector3((Health -= Damage)/100,0.11f,0f);
                break;
                Debug.Log(Health);
                Debug.Log("Working");
                
                //Logic behind this case is that if you attach this script to enemies they'll take damage colliding with each other
            case "ememy":
                //Health -= Damage;
                break;

        }
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            // Destroy(collision.gameObject);
            // Destroy(this.gameObject);
            Destroy(e, 2f);
            gameObject.SetActive(false);
            
            
        }

    }
 
}
