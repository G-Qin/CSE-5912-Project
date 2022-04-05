using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CDamageSystem : MonoBehaviour
{
    public Animation anim;
    private int weaponDamage = 19;
    private int fireRain = 5;
    private int DragonBugDamage = 10;
    private int DragonDamage = 25;

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
        /*        if (collisionInfo.collider.tag == "DragonBug")
                {
                    anim = collisionInfo.collider.gameObject.GetComponent<Animation>();
                    if (anim.IsPlaying("Attack1"))
                    {
                        healthSystem.Damage(DragonBugDamage);
                        if (healthSystem.getHealth() == 0)
                        {
                            SceneManager.LoadScene("GameOverScene");
                        }
                    }
                }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireRain")
        {
            healthSystem.Damage(fireRain);
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

        

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "DragonBug")
        {
                
            anim = other.gameObject.GetComponent<Animation>();
            if (anim.IsPlaying("Attack1"))
            {
                if (timeRemaining <= 0)
                {
                    Debug.Log("Dragon 111111111");
                    healthSystem.Damage(DragonBugDamage);
                    if (healthSystem.getHealth() == 0)
                    {
                        SceneManager.LoadScene("GameOverScene");
                    }
                    timeRemaining = 1.3f;
                }
            }
        }
    }

    public float timeRemaining = 0;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    private void OnParticleCollision(GameObject collision)
    {
        if (collision.CompareTag("DragonDamage")) 
        {
            healthSystem.Damage(DragonDamage);
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }



}
