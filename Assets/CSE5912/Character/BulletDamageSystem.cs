using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSystem : MonoBehaviour
{
    int bulletDamage;
    int grenadeDamage;
    int GlDamage;

    void Start()
    {
        bulletDamage = 20;
        grenadeDamage = 50;
        GlDamage = 40;
    }

    public void setBulletDamage(int i)
    {
        bulletDamage = i;
    }

    public int getBUlletDamage()
    {
        return bulletDamage;
    }

    public void setGlDamage(int i)
    {
        GlDamage = i;
    }

    public int getGlDamage()
    {
        return GlDamage;
    }

    public void setgrenadeDamage(int i)
    {
        grenadeDamage = i;
    }

    public int getgrenadeDamage()
    {
        return grenadeDamage;
    }



}
