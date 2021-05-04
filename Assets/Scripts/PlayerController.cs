using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public Camera cam;

    private Vector2 moveVelocity;

    

    

    public static float healthAmount;

    // Vector2 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 1;
        rb = GetComponent<Rigidbody2D>();

        


        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;




        
        transform.Rotate( 0f ,0f , SimpleInput.GetAxis("Rotate") * 5f, Space.Self );
        
        if (healthAmount <= 0){
            Destroy (gameObject);
        }
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        // Vector2 lookDir = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Projectile"))
        {
            healthAmount -= 0.1f;
        }
    }

    
}
