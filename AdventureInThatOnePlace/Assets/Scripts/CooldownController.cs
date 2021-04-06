using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CooldownController : MonoBehaviour
{
    public Slider cooldownBar;

    private int max = 100;
    private int current;

    [SerializeField]
    private WaitForSeconds regenTick = new WaitForSeconds(0.001f);

    public static CooldownController instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        current = max;
        cooldownBar.maxValue = max;
        cooldownBar.value = max;
    }

    public void ChangeWeapon(float newRegenTick)
    {
        regenTick = new WaitForSeconds(newRegenTick);
    }

    public void UseCooldown(int amount)
    {
        if(current - amount >= 0)
        {
            current -= amount;
            cooldownBar.value = current;

            StartCoroutine(Regen());
        }
        else
        {
            Debug.Log("Lol not enough");
        }
    }

    public bool isFull()
    {
        if(current == max)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Regen()
    {
        yield return new WaitForSeconds(0.5f);

        while(current < max)
        {
            current += max / 100;
            cooldownBar.value = current;
            yield return regenTick;
        }
    }
    
}
