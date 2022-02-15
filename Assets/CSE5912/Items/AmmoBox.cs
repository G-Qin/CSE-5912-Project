using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class AmmoBox : MonoBehaviour
{
    public bool inRange=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("in range");
            inRange=true;
        }
    }

    void OnCollisionExit(){
        // Debug.Log("out of range");
        inRange=false;
    }

    public void interaction()
    {
        refillAmmo();
    }

    void refillAmmo()
    {
        if (inRange)
        {
            Debug.Log("Refill");
        }
    }

}
