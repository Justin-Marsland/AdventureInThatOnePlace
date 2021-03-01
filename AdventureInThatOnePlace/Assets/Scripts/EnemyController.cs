using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //max range is the maximum range to "aggro" the enemy
        // min range is how far away before it stops (This can change with the weapon distance of each enemy)
        // min range will also need to be updated to start the attack once we get there. 
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

    }

    public void FollowPlayer()
    {
        // sets to follow player
        myAnim.SetBool("isMoving", true);
        // this gets the direction of the player in comparison to the enemy
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        // this tells the enemy to move in the direction of the player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);

    }

    // This is used to send the enemy back to it's starting space. 
    public void GoHome()
    {
        // sets the direction to be facing to the home position
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        // sets the direction of moving to home, 
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        // if enemy is at home spot, is moving set to false. 
        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }

}
