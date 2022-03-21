using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasiliskController : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Animation anim;
    public float rotationSpeed = 10f;
    //[SerializeField] private int bulletDamage;
    //[SerializeField] private HealthSystem healthSystem;
    private CoinSystem coin;
    private bool live;
    Collider m_Collider;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        live = true;
        Player = GameObject.Find("/P_LPSP_FP_CH_1").transform;
        coin = GameObject.Find("/Canvas/Score").GetComponent<CoinSystem>();
        StartCoroutine("waiter");
        enemy.enabled = true;
        m_Collider = GetComponent<Collider>();

        //Player=GameObject.Find("/P_LPSP_FP_CH_1/SK_FP_CH_Default_Root/Armature/root/pelvis/spine_01/spine_02/spine_03/neck_01/head/SOCKET_Camera/Camera/Camera Depth");
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
            if (dist < 2)
            {
                enemy.ResetPath();
                anim.Play("Attack1");
                yield return new WaitForSeconds(1.5f);
            }
            else if (dist < 10)
            {
                enemy.ResetPath();
                anim.Play("Attack2");
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                enemy.SetDestination(Player.position);
                anim.Play("Move");
                enemy.speed = 3.5f;
            }
            yield return new WaitForSeconds(0.1f);
            StartCoroutine("waiter");
        }
    }
    //private void OnCollisionEnter(Collision collisionInfo)
    //{
    //    //Debug.Log("Hit!!" + collisionInfo.collider.tag);
    //    if (collisionInfo.collider.tag == "Bullet")
    //    {
    //        healthSystem.Damage(bulletDamage);
    //        coin.addCoin(10);
    //        if (healthSystem.getHealth() == 0)
    //        {
    //            coin.addCoin(100);
    //            live = false;
    //            enemy.enabled = false;
    //            anim.Play("Death");
    //            //StartCoroutine("waiter");
    //            //gameObject.SetActive(false);
    //            //Destroy(gameObject);
    //            Destroy(gameObject, 3.0f);
    //        }
    //    }

    //}
}
