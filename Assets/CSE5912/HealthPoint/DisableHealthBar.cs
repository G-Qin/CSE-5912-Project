using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject bossHealthbar;
    private bool BossAwake = false;
    private void Update()
    {
        if (BossAwake)
            bossHealthbar.SetActive(true);
        if(gameObject.GetComponent<HealthBar>().slider.value == 0 )
        {
            bossHealthbar.SetActive(false);
        }
    }
    public void BossActive()
    {
        BossAwake = true;
    }
}
