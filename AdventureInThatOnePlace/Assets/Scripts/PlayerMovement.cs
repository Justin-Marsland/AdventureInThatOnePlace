using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public Animator myAnimator;
    public bool facingRight = true;

    private float attackTime = .4f; //This will change to the Weapon class
    private float attackCounter = .25f; 
    private bool isAttacking;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        //currentState = State.Normal;
    }

    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        //Input
        //switch(currentState)
        //{
            //case State.Normal:
                Movement();
                CharacterAttack();
                //break;
            //case State.Attacking:
                //break;

        //}



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
    private void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            myAnimator.SetFloat("lastMoveX", movement.x);
            myAnimator.SetFloat("lastMoveY", movement.y);
        }

    }
    private void CharacterAttack()
    {
        if(isAttacking)
        {
            movement = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                myAnimator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if(Input.GetMouseButtonDown(0) && CooldownController.instance.isFull())
        {
            attackCounter = attackTime;
            //AttackDir = transform.position;
            //currentState = State.Attacking;
            myAnimator.SetBool("isAttacking", true);
            isAttacking = true;
            CooldownController.instance.UseCooldown(100);
        }
    }
}
