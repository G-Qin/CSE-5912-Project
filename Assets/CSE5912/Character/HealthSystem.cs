using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HealthSystem : MonoBehaviour
    {
        private int health;
        private int maxHealth;
        public HealthBar healthbar;
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
            health -= damageValue;
            
        if (health < 0)
            {
                health = 0;
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



    }


