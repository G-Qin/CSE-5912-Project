using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // here are all the object references
    [SerializeField] GameObject monsterSpawner;
    

    // list of game objects


    // for testing only
    [SerializeField] private GameObject monster1;
    [SerializeField][Range(1,10)] private int monsterCount;
    [SerializeField] float spwanInterval;

    void Start()
    {
        monsterSpawner.GetComponent<MonsterSpawner>().monster=monster1;
        monsterSpawner.GetComponent<MonsterSpawner>().count=monsterCount;
        monsterSpawner.GetComponent<MonsterSpawner>().spawn_interval=spwanInterval;


    }

}
