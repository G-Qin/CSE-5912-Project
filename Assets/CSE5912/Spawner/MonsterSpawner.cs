using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Monster")]
    [SerializeField] public GameObject monster;
    [SerializeField] public int count;
    [SerializeField] public float spawn_interval;

    // instance to store monster being spawn
    private GameObject monsterInstance;

    // testing variables
    private float time;

    void Start()
    {
        time = 0;
    }


    void Update()
    {
        time += Time.deltaTime;

        // spawn every 10 sec
        if (time > spawn_interval && count > 0)
        {
            Spawn();
            count--;
        }
        //Debug.Log(time);
    }

    void Spawn()
    {

        // z position
        float z = 0;
        monsterInstance = Instantiate(monster, this.gameObject.transform.position, Quaternion.identity);
        z++;
        time = 0;

        // go back 2 units for next spawn
        // pos+=2;

    }
}
