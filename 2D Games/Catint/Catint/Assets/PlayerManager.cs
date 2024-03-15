using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerManager : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 3f;
    [SerializeField] Rigidbody2D rb;

    [Header("jump")]
    [SerializeField] Transform pointJump;
    [SerializeField] LayerMask ground;
    [SerializeField] float radiusJump = 0.3f;


    void Start()
    {

    }
    void Update()
    {
        moves();
    }

    void moves()
    {   
        //walk
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (xInput*speed, rb.velocity.y);

        //jump
        if (Physics2D.OverlapCircle(pointJump.position, radiusJump,ground))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            rb.velocity = Vector2.up * jump;
        }
        
    }
}
