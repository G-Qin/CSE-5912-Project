using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CDamageSystem : MonoBehaviour
{
    private int weaponDamage = 15;

    [SerializeField] private HealthSystem healthSystem;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "EnemyWeapon")
        {
            healthSystem.Damage(weaponDamage);
            FindObjectOfType<SoundManager>().Play("CGetAttack");
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
