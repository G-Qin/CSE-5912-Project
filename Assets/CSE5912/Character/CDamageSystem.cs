using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CDamageSystem : MonoBehaviour
{
    private int weaponDamage = 15;
    private int fireRain = 10;

    [SerializeField] private HealthSystem healthSystem;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "EnemyWeapon")
        {
            healthSystem.Damage(weaponDamage);
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        if (collisionInfo.collider.tag == "FireRain")
        {
            healthSystem.Damage(weaponDamage);
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    


}
