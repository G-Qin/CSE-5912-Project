using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect_1;
    [SerializeField] private GameObject hitEffect_2;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("Hit!!" + collisionInfo.collider.tag);
        if (collisionInfo.collider.tag == "Wall")
        {

            ContactPoint contact = collisionInfo.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 postion = contact.point;
            var effect = Instantiate(hitEffect_1, postion, rot);
            //var bullet = Instantiate(hitEffect, collisionInfo.transform.position, Quaternion.LookRotation(Vector3.up));
            Destroy(effect, 1f); 
        }
        else if(collisionInfo.collider.tag == "Enemy")
        {
            ContactPoint contact = collisionInfo.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 postion = contact.point;
            var effect = Instantiate(hitEffect_2, postion, rot);
            //var bullet = Instantiate(hitEffect, collisionInfo.transform.position, Quaternion.LookRotation(Vector3.up));
            Destroy(effect, 1f);
        }
        else
        {

        }
    }
}
