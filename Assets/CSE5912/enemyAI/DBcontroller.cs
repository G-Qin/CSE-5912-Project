using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DBcontroller : MonoBehaviour
{
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
        FindObjectOfType<SoundManager>().Play("Ins2");
        anim = gameObject.GetComponent<Animation>();
        live = true;
        Player = GameObject.Find("/P_LPSP_FP_CH_1").transform;
        coin = GameObject.Find("/Canvas/Score").GetComponent<CoinSystem>();
        StartCoroutine("waiter");
        enemy.enabled = true;
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
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
        //Debug.Log("Hit!!" + collisionInfo.collider.tag);
        if (collisionInfo.collider.tag == "Bullet")
        {
            healthSystem.Damage(bulletDamage);
            if (healthSystem.getHealth() == 0)
            {
                FindObjectOfType<SoundManager>().Play("Ins2Die");
                coin.addCoin(50);
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

    }
}
