using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("waiter");
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator waiter()
    {
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist < 2)
        {
            enemy.ResetPath();
            anim.SetBool("run", false);
            anim.SetBool("move", false);
            anim.SetBool("attack", true);
            yield return new WaitForSeconds(2.8f);
        }
        else if (dist < 10)
        {
            enemy.SetDestination(Player.position);
            anim.SetBool("move", false);
            anim.SetBool("run", true);
            anim.SetBool("attack", false);
            enemy.speed = 5;
        }
        else
        {
            enemy.SetDestination(Player.position);
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
            anim.SetBool("move", true);
            enemy.speed = 3.5f;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("waiter");
    }
}
