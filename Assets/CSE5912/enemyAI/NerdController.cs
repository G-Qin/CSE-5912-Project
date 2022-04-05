using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NerdController : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Animator anim;
    [SerializeField] private int bulletDamage;
    [SerializeField] private HealthSystem healthSystem;
    private CoinSystem coin;
    private bool live;
    Collider m_Collider;
    void Start()
    {
        anim = GetComponent<Animator>();
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
        
    }
    IEnumerator waiter()
    {
        if (live == true)
        {
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 1.5)
            {
                enemy.ResetPath();
                anim.SetBool("attack", true);
                yield return new WaitForSeconds(2.8f);
            }          
            else
            {
                enemy.SetDestination(Player.position);
                anim.SetBool("attack", false);
                enemy.speed = 1.5f;
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
                FindObjectOfType<SoundManager>().Play("GetAttack");
                coin.addCoin(100);
                live = false;
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
}