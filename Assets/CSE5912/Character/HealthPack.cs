using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private int healthPackCount;

    void Awake()
    {
        healthPackCount = 1;
    }

    public void AddOneHealthPack()
    {
        healthPackCount++;
    }

    public void UseHealthPack()
    {
        if (healthPackCount > 0)
            healthPackCount--;
    }

    public int GetHealthPackCount()
    {
        return healthPackCount;
    }
}
