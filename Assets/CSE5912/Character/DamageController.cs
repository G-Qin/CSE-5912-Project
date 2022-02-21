using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    [SerializeField] private HealthSystem healthSystem;
    public Animator anim;
    public NavMeshAgent enemy;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
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
                enemy.enabled = false;
                anim.SetBool("dead", true);
                //StartCoroutine("waiter");
                //gameObject.SetActive(false);
                //Destroy(gameObject);
                Destroy(gameObject, 3.0f);
            }
            else
            {
                anim.SetBool("dead", false);
            }
        }

    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
    }


}

