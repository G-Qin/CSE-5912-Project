using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlaneTriggerScript : MonoBehaviour
{
    [SerializeField]GameObject LevelManager;
    

    private void OnTriggerEnter(Collider other)
    {
        LevelManager.GetComponent<LevelManager>().TriggerPlane();
    }
}
