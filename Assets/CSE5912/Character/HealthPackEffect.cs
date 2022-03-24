using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackEffect : MonoBehaviour
{
    [SerializeField] private GameObject HealthRecover;
    [SerializeField] private HealthPack HealthPack;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && HealthPack.GetHealthPackCount() > 0)
        {
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, Vector3.down);
            Vector3 postion = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            var effect = Instantiate(HealthRecover, postion, rot);
            Destroy(effect, 3f);

        }
    }
}