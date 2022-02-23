using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class DamageController : MonoBehaviour
    {
        [SerializeField] private int bulletDamage;

        [SerializeField] private HealthSystem healthSystem;

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Hit!!");
    //    if (other.CompareTag("Bullet"))
    //    {
    //        healthSystem.Damage(50);
    //        if (healthSystem.getHealth() == 0)
    //        {
    //            gameObject.SetActive(false);
    //        }
    //    }
    //}
    
    private void OnCollisionEnter(Collision collisionInfo)
        {
            //Debug.Log("Hit!!" + collisionInfo.collider.tag);
            if (collisionInfo.collider.tag == "Bullet")
            {
                healthSystem.Damage(bulletDamage);
                if (healthSystem.getHealth() == 0)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }

    }

