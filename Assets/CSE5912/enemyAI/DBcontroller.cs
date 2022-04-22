using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DBcontroller : MonoBehaviour
{
    private BulletDamageSystem bulletDamageSystem;
    public bool alive;
    public NavMeshAgent enemy;
    public Transform Player;
    public Animation anim;
    public float rotationSpeed = 10f;
    [SerializeField] private int bulletDamage;
    [SerializeField] private HealthSystem healthSystem;
    private CoinSystem coin;
    private bool live;
    Collider m_Collider;
    void Start()
    {
        
        alive = true;
        FindObjectOfType<SoundManager>().Play("Ins2");
        anim = gameObject.GetComponent<Animation>();
        live = true;
        Player = GameObject.Find("/P_LPSP_FP_CH_1").transform;
        bulletDamageSystem = GameObject.Find("/P_LPSP_FP_CH_1").GetComponent<BulletDamageSystem>();
        coin = GameObject.Find("/Canvas/Score").GetComponent<CoinSystem>();
        StartCoroutine("waiter");
        enemy.enabled = true;
        m_Collider = GetComponent<Collider>();
        healthSystem.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        if (healthSystem.getHealth() == 0 && live)
        {
            alive = false;
            //FindObjectOfType<SoundManager>().Play("Ins2Die");
            coin.addCoin(125);
            live = false;
            enemy.enabled = false;
            GetComponent<Rigidbody>().detectCollisions = false;
            m_Collider.enabled = !m_Collider.enabled;
            anim.Play("Death");
            //StartCoroutine("waiter");
            //gameObject.SetActive(false);
            //Destroy(gameObject);
            Destroy(gameObject, 3.0f);
        }
    }
    IEnumerator waiter()
    {
        if (live == true)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 2.0)
                {
                    enemy.ResetPath();
                    anim.Play("Attack1");
                    yield return new WaitForSeconds(1.0f);
                }
                else
                {

                    enemy.SetDestination(Player.position);
                    anim.Play("Walk");
                    enemy.speed = 5f;
                }
            yield return new WaitForSeconds(0.1f);
            StartCoroutine("waiter");
        }
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet")
        {
            healthSystem.Damage(bulletDamageSystem.getBulletDamage());
            Debug.Log("Damage :" + bulletDamageSystem.getBulletDamage());
        }
        if (collisionInfo.collider.tag == "Knife")
        {
            healthSystem.Damage(30);
            Debug.Log("Damage :" + 30);
        }

    }
}
