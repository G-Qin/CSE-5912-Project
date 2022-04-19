using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicDamage : MonoBehaviour
{
    private HealthSystem Characterhealth;
    private int DragonDamage = 20;

    void Start()
    {
        Characterhealth = GameObject.Find("/P_LPSP_FP_CH_1").GetComponent<HealthSystem>();
    }
    private void OnParticleCollision(GameObject collision)
    {
/*        if (collision.CompareTag("DragonAttack"))
        {
            healthSystem.Damage(DragonDamage);
            if (healthSystem.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }*/

        if (collision.tag == "Player")
        {
            Characterhealth.Damage(DragonDamage);
            if (Characterhealth.getHealth() == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }

        }
            

    }
}
