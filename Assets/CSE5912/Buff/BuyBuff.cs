using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBuff : MonoBehaviour
{
    [SerializeField]
    public BuffManager buffManager;

    public void BuySpeedBuff()
    {
        buffManager.addOneBuff("speed", 500);
    }

    public void BuyArmorBuff()
    {
        buffManager.addOneBuff("armor", 500);
    }

    public void BuyDamageBuff()
    {
        buffManager.addOneBuff("damage", 500);
    }
}
