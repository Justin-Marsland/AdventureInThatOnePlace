using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public static WeaponController instance;
    private void Awake()
    {
        instance = this;
    }
    class Weapon
    {
        [SerializeField]
        public float coolDown;
        [SerializeField]
        public float damage;
        [SerializeField]
        public float attackDuration;
        public Weapon(float _coolDown, float _damage, float _attackDuration)
        {
            coolDown = _coolDown;
            damage = _damage;
            attackDuration = _attackDuration;
        }
    }

    // Start is called before the first frame update

    void Start()
    {
        Weapon dagger = new Weapon(0.001f, 1f, 0.4f);
        Weapon broadSword = new Weapon(0.01f, 1f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
