using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public float coolDown;  //Value for how long it takes for the cooldown bar to refill
    [SerializeField]
    public float damage;    //Damage, duh
    [SerializeField]
    public float attackDuration; //How long the attack animation is
    [SerializeField]
    public float startUp;   //Time before the hitbox activates
    [SerializeField]
    public float ending;    //Time after the hitbox deactivates
}
