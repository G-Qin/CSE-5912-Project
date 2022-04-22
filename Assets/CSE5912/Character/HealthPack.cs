using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private CoinSystem CoinSystem;
    [SerializeField]
    private HealthSystem PlayerHealthSystem;

    private int healthPackCount;

    void Awake()
    {
        healthPackCount = 1;
    }

    public void BuyOneHealthPack()
    {
        bool success = CoinSystem.useCoin(500);
        if(success)
            healthPackCount++;
    }

    public void UseHealthPack()
    {
        if (healthPackCount > 0 && PlayerHealthSystem.getHealth() != 100)
        {
            healthPackCount--;
            gameObject.GetComponent<HealthPackEffect>().DoHealingEffect();
            FindObjectOfType<SoundManager>().Play("HealthPackSound");
        }
    }

    public int GetHealthPackCount()
    {
        return healthPackCount;
    }
}
