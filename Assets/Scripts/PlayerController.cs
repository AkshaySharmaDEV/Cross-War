using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public Camera cam;

    private Vector2 moveVelocity;

    // Vector2 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;      
        
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
    }
    

    

    
}
