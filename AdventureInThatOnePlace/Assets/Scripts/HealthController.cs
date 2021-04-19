using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    public int numOfHearts;
    [SerializeField]
    public Image[] hearts;
    [SerializeField]
    public Sprite fullHeart;
    [SerializeField]
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if( i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = true;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "HealingZone" && health < 3)
            health = 3;
    }
}
