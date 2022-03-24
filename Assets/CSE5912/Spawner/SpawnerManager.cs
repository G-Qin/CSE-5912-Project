using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // here are all the object references
    [SerializeField] GameObject monsterSpawner;
    

    // list of game objects


    // for testing only
    [SerializeField] public int monsterType = 0;
    [SerializeField] private List<GameObject> monsters;
    [SerializeField][Range(1,10)] public int monsterCount;
    [SerializeField] public float spawnInterval;

    void Start(){

    }

    public void SetupSpawner()
    {
        monsterSpawner.GetComponent<MonsterSpawner>().monster = monsters[monsterType];
        monsterSpawner.GetComponent<MonsterSpawner>().count = monsterCount;
        monsterSpawner.GetComponent<MonsterSpawner>().spawn_interval = spawnInterval;


    }

}
