using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSystem : MonoBehaviour
{
    int bulletDamage;
    int[] damageArray;

    void Start()
    {
        damageArray = new int[] { 25, 15, 20, 1, 8, 20, 10, 10, 1, 0, 14, 18, 11, 12, 16, 0, 70, 250 };
        bulletDamage = 20;
    }

    public void setBulletDamage(int index)
    {
        bulletDamage = damageArray[index];
    }

    public int getBulletDamage()
    {
        return bulletDamage;
    }
}
