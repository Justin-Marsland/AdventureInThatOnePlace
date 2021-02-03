using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator myAnimator;
    public bool facingRight = true;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.x > 0)
        {
            myAnimator.SetBool("IsRight", true);
            myAnimator.SetBool("IsLeft", false);
            myAnimator.SetBool("IsUp", false);
            myAnimator.SetBool("IsDown", false);
        }
        else if(movement.x < 0)
        {
            myAnimator.SetBool("IsRight", false);
            myAnimator.SetBool("IsLeft", true);
            myAnimator.SetBool("IsUp", false);
            myAnimator.SetBool("IsDown", false);
        }
        else if(movement.y > 0)
        {
            myAnimator.SetBool("IsRight", false);
            myAnimator.SetBool("IsLeft", false);
            myAnimator.SetBool("IsUp", true);
            myAnimator.SetBool("IsDown", false);
        }
        else if(movement.y < 0)
        {
            myAnimator.SetBool("IsRight", false);
            myAnimator.SetBool("IsLeft", false);
            myAnimator.SetBool("IsUp", false);
            myAnimator.SetBool("IsDown", true);
        }

    }
    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
