using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopTrigger : MonoBehaviour
{
    [SerializeField]
    public bool shopAvailable = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            shopAvailable = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            shopAvailable = false;
    }
}
