using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private bool ArmorBuffActive = false;
    private bool DamageBuffActive = false;

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

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public int getHealth()
    {
        return health;
    }

    public void Damage(int damageValue)
    {
        if (health > 0) {
            // For player health system
            if (gameObject.tag.Equals("Player"))
            {
                if (ArmorBuffActive)
                    health -= damageValue / 2;
                else
                    health -= damageValue;
            }

            // For enemy health system
            if (!gameObject.tag.Equals("Player"))
            {
                if (DamageBuffActive)
                    health -= damageValue * 3 / 2;
                else
                    health -= damageValue;
            }

            if (health <= 0)
            {
                health = 0;
                if (gameObject.tag.Equals("Enemy") || gameObject.tag.Equals("DragonBug")){
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
        if (gameObject.tag.Equals("Player") && Input.GetKeyDown(KeyCode.U) && HealthPack.GetHealthPackCount() > 0)
        {
            //Debug.Log("Healed 25!");
            HealthPack.UseHealthPack();
            Heal(25);
            healthbar.SetHealth(health);
        }
    }

    #region BUFF METHODS
    public void ArmorBuffed()
    {
        if (gameObject.tag.Equals("Player"))
            ArmorBuffActive = true;
    }

    public void ArmorUnBuffed()
    {
        ArmorBuffActive = false;
    }

    public void DamageBuffed()
    {
        if (!gameObject.tag.Equals("Player"))
            DamageBuffActive = true;
    }

    public void DamageUnBuffed()
    {
        DamageBuffActive = false;
    }
    #endregion
}


