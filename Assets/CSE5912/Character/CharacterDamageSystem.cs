using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageSystem : MonoBehaviour
{
    // Here is the setting for different weapons' demage.
    private int knifelDamage = 20;

    [SerializeField] private HealthSystem healthSystem;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "EnemyWeapon")
        {
            Debug.Log("Hit !!  ");
            healthSystem.Damage(knifelDamage);
            /**if (healthSystem.getHealth() == 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }*/
        }
    }
}
