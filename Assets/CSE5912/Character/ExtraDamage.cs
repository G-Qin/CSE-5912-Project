using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDamage : MonoBehaviour
{

    private int extraDamage = 50;

    [SerializeField] private HealthSystem healthSystem;

    private void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Bullet")
        {
            healthSystem.Damage(extraDamage);
        }
    }
}
