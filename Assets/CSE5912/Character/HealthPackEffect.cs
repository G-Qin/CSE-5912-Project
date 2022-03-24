using UnityEngine;

public class HealthPackEffect : MonoBehaviour
{
    [SerializeField] private GameObject HealthRecover;
    [SerializeField] private HealthPack HealthPack;

    public void DoHealingEffect()
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, Vector3.down);
        Vector3 postion = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        var effect = Instantiate(HealthRecover, postion, rot);
        Destroy(effect, 3f);
    }
}