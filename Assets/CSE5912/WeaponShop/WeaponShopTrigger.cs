using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopTrigger : MonoBehaviour
{
    [SerializeField]
    public bool shopAvailable = false;

    GameObject openShopText;

    void Start(){
        openShopText = GameObject.Find("/Canvas/OpenShopText");
        openShopText.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            shopAvailable = true;
            openShopText.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            shopAvailable = false;
            openShopText.SetActive(false);
    }
}
