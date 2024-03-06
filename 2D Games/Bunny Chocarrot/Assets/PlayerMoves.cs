using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerJump = 5f;
    [SerializeField] float multiplayerJump = 4.5f;
    [SerializeField] Transform pointJump;
    [SerializeField] LayerMask solo;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] float radiusCircle;
    [SerializeField] Animator anim;

    [SerializeField] bool jump = false;
    [SerializeField] Transform player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();


    }

    void move()
    {
        float xInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y);

        if (Physics2D.OverlapCircle(pointJump.position, radiusCircle, solo))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (jump == true && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * playerJump;

        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 8f)
        {
            rb.velocity = Vector2.up * multiplayerJump;
        }

        if (xInput != 0)
        {

        }
        if (xInput > 0)
        {
            player.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (xInput < 0)
        {
            player.rotation = Quaternion.Euler(0,0,0);
        }

    }
}
