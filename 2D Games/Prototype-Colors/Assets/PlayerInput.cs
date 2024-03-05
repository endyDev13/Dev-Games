using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInput : MonoBehaviour
{
    public int SpeedPlayer = 5;
    public float MultiplySpeed = 1.5f;
    public float JumpMultiply = 5f;
    public float JumpMultiply2 = 4.5f;
    [SerializeField] bool Jump = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform CheckGroundPosition;
    [SerializeField] LayerMask chao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        jumpPlayer();
  
    }

    void Moviment()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");


        rb.velocity = new Vector2(xInput * SpeedPlayer, rb.velocity.y);
        // overlapcircle, checa se um objeto esta colidindo na layer atráves de um circulo que se cria de um objeto
        // necessário ter, transform do objeto checkado, tamanho do circulo, e a layer de colisão.
        if (Physics2D.OverlapCircle(CheckGroundPosition.position, 0.3f, chao))
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }
    }

    void jumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && Jump == true)
        {
            rb.velocity = Vector2.up * JumpMultiply;
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 3f)
        {
            rb.velocity = Vector2.up * JumpMultiply2;
        }
       
    }



}