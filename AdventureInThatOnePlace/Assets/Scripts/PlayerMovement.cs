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

    [SerializeField]
    GameObject [] weapon;

    public GameObject selectedWeapon;

    private float attackTime = .4f; //This will change to the Weapon class
    private float attackCounter = .25f; 
    private bool isAttacking;



    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        selectedWeapon = weapon[0];
        myAnimator.SetFloat("lastMoveY", 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    private void Start()
    {
        
    }

    public static void CursorVisibility(bool input)
    {
        Cursor.visible = input;
        if(input == false)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        Movement();
        CharacterAttack();
        SwitchWeapon();
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
        if(!PauseMenu.isPaused) //Disable movement if paused
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            myAnimator.SetFloat("Horizontal", movement.x);
            myAnimator.SetFloat("Vertical", movement.y);
            myAnimator.SetFloat("Speed", movement.sqrMagnitude);

            if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
            {
                myAnimator.SetFloat("lastMoveX", movement.x);
                myAnimator.SetFloat("lastMoveY", movement.y);
            }
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
        if(Input.GetMouseButtonDown(0) && CooldownController.instance.isFull() && !PauseMenu.isPaused)
        {
            attackCounter = attackTime;
            myAnimator.SetBool("isAttacking", true);
            isAttacking = true;
            CooldownController.instance.UseCooldown(100);
        }
    }
    private void SwitchWeapon()
    {
        if(CooldownController.instance.isFull() == true)
        {
            selectedWeapon = weapon[WeaponSwitching.instance.selectedWeapon];
            CooldownController.instance.ChangeWeapon(selectedWeapon.GetComponent<Weapon>().coolDown);
            attackTime = selectedWeapon.GetComponent<Weapon>().attackDuration;
        }
        if (WeaponSwitching.instance.selectedWeapon == 0)
        {
            myAnimator.SetBool("Dagger", true);
            myAnimator.SetBool("Broadsword", false);
        }
        else if (WeaponSwitching.instance.selectedWeapon == 1) //Every other weapon will default to broadsword, since there's nothing for every other weapon
        {
            myAnimator.SetBool("Dagger", false);
            myAnimator.SetBool("Broadsword", true);
        }
        else if (WeaponSwitching.instance.selectedWeapon == 2)
        {
            //Greatsword
        }
        else if (WeaponSwitching.instance.selectedWeapon == 3)
        {
            //Spear
        }
    }
}
