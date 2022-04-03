using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class WyvernController : MonoBehaviour
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
    public Transform attack;
    public Transform eff;
    int att;
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
        att = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Player.position.x - transform.GetChild(3).position.x,0.0f, Player.position.z - transform.GetChild(3).position.z).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    IEnumerator waiter()
    {
        if (live == true)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (att >= 1 && att <= 3 && dist < 13.0)
            {
                enemy.ResetPath();
                Transform bullet = Instantiate(attack, transform.GetChild(3).position, Quaternion.identity);
                Vector3 dir = (Player.position - transform.GetChild(3).position).normalized;
                bullet.rotation = Quaternion.LookRotation(dir);
                anim.Play("Breath fire");
                att++;
                yield return new WaitForSeconds(1.5f);
                Destroy(bullet.gameObject);
            }
            else if (att == 0 && dist < 3.0)
            {
                enemy.ResetPath();
                anim.Play("Bite");
                att++;
                yield return new WaitForSeconds(2.0f);
            }
            else if (att == 4 && dist < 3.0)
            {
                enemy.ResetPath();
                anim.Play("Whip tail");
                yield return new WaitForSeconds(1.1f);
                Transform effect = Instantiate(eff, new Vector3(transform.GetChild(3).position.x,0, transform.GetChild(3).position.z), Quaternion.identity);
                effect.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
                yield return new WaitForSeconds(1.3f);
                Destroy(effect.gameObject);
                att = 0;
            }
            else
            {

                enemy.SetDestination(Player.position);
                anim.Play("Fly forward");
                if (att != 4)
                {
                    enemy.speed = 5f;
                }
                else
                {
                    enemy.speed = 7f;
                }
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
                anim.Play("Death");
                //StartCoroutine("waiter");
                //gameObject.SetActive(false);
                //Destroy(gameObject);
                Destroy(gameObject, 3.0f);
            }
        }

    }
}
