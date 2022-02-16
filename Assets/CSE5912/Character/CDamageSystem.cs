using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDamageSystem : MonoBehaviour
{
    private int weapomDamage = 15;

    [SerializeField] private HealthSystem healthSystem;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "EnemyWeapon")
        {
            healthSystem.Damage(weapomDamage);
            if (healthSystem.getHealth() == 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
