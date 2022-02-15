using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("Monster")]
    [SerializeField] public GameObject monster;
    [SerializeField] public int count;
    
    // instance to store monster being spawn
    private GameObject monsterInstance;

    // testing variables
    private float time;
    private int pos;

    void Start()
    {
        time=0;
    }

    
    void Update()
    {
        time+=Time.deltaTime;

        // spawn every 10 sec
        if(time>10){
           Spawn();
        }   
        //Debug.Log(time);
    }

    void Spawn(){

         // z position
            float z=0;
            for(int i=0;i<count;i++){
                monsterInstance=Instantiate(monster, new Vector3(pos,0.5F,z),Quaternion.identity);
                z++;
                // spawn 3 monters per column
                if(i%2==0 && i!=0){
                    // go to next column
                    pos++;
                    z=0;
                }           
            }
            time-=10;

            // go back 2 units for next spawn
            // pos+=2;

    }
}
