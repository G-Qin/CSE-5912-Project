using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasiliskController : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform attack;
    public Animation anim;
    public float rotationSpeed = 10f;
    [SerializeField] private int bulletDamage;
    [SerializeField] private HealthSystem healthSystem;
    private CoinSystem coin;
    private bool live;
    Collider m_Collider;
    void Start()
    {
        FindObjectOfType<SoundManager>().Play("Ins");
        anim = gameObject.GetComponent<Animation>();
        live = true;
        Player = GameObject.Find("/P_LPSP_FP_CH_1").transform;
        coin = GameObject.Find("/Canvas/Score").GetComponent<CoinSystem>();
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
            if (dist < 2)
            {
                enemy.ResetPath();
                anim.Play("Attack1");
                yield return new WaitForSeconds(1.5f);
            }
            else if (dist < 10)
            {
                enemy.ResetPath();
                anim.Play("Magic");
                Vector3 pos = Player.position;
                yield return new WaitForSeconds(1.0f);
                Transform eff = Instantiate(attack, pos, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
                Destroy(eff.gameObject);
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
    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("Hit!!" + collisionInfo.collider.tag);
        if (collisionInfo.collider.tag == "Bullet")
        {
            healthSystem.Damage(bulletDamage);
            if (healthSystem.getHealth() == 0)
            {
                FindObjectOfType<SoundManager>().Play("Ins1Die");
                coin.addCoin(150);
                live = false;
                enemy.enabled = false;
                anim.Play("Death1");
                //StartCoroutine("waiter");
                //gameObject.SetActive(false);
                //Destroy(gameObject);
                Destroy(gameObject, 3.0f);
            }
        }

    }
}
