using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public GameObject projectile;

    public float speed;

    Vector3 localScale;

    public GameObject Indicator;


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

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
 
}
