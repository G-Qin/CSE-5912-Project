using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTurnOff : MonoBehaviour
{
    private BoxCollider[] coll;
    private float startTime = 0f;
    public float timer = 6f;


    void Start ()
    {
        startTime = timer;
        coll = gameObject.GetComponents<BoxCollider>();
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        if (startTime <= 0)
        {
            foreach (BoxCollider bc in coll) bc.enabled = false;
        }
	}
}
