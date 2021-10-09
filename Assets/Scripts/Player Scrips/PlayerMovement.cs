using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed=8;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float size = 1;
    private Rigidbody2D body;
    private bool grounded;
    private BoxCollider2D boxCollider;
    private Animator anim;
    
    

    private void Awake()
    {   //pegando as referências dos componentes do player
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y, 0);
        if (Input.GetKey(KeyCode.Space) && isGrounded())//&&grounded
        {
            Jump();
            
        }
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1)*size; // vira o personagem para a direita
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1)*size;//vira o personagem para a esquerda
        }

        anim.SetBool("Grounded", grounded);
     
    }
    private void Jump()
    {
        body.velocity = new Vector3(body.velocity.x, speed,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
