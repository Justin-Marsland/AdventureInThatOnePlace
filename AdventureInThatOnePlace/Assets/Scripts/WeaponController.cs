using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator parentAni;
    float movement;
    class Weapon
    {
        float coolDown;
        float damage;
        float attackDuration;
    }

    // Start is called before the first frame update

    void Start()
    {
        //parentAni = GetComponentInParent();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            myAnimator.SetFloat("lastMoveX", movement.x);
            myAnimator.SetFloat("lastMoveY", movement.y);
        }*/
    }
}
