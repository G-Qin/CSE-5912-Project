using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HealthSystem : MonoBehaviour
    {
        private int health;
        private int maxHealth;
        public HealthBar healthbar;

        [SerializeField]
        public HealthPack HealthPack;
        private void Awake()
        {
            maxHealth = 100;
            health = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            //Debug.Log(100);
        }

        //public HealthSystem(int maxHealth)
        //{
        //    this.maxHealth = maxHealth;
        //    health = maxHealth;
        //}

        public int getHealth()
        {
            return health;
        }

        public void Damage(int damageValue)
        {
            if (health > 0) {
                health -= damageValue;
            
                if (health <= 0)
                {
                    health = 0;
                    if (gameObject.tag == "Enemy"){
                        GameObject.Find("LevelManager").GetComponent<LevelManager>().EnemyDeath();
                    }
                }
            }
            healthbar.SetHealth(health);
            //Debug.Log("Damage: " + damageValue);
           // Debug.Log("Current Health" + health);
        }

        public void Heal(int healValue)
        {
            health += healValue;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U) && gameObject.tag.Equals("Player") && HealthPack.GetHealthPackCount() > 0)
            {
                //Debug.Log("Healed 25!");
                HealthPack.UseHealthPack();
                Heal(25);
                healthbar.SetHealth(health);
            }
        }

    }


