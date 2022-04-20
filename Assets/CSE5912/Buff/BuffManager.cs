using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public CoinSystem coinSystem;

    private bool speedBuffed = false;
    private bool armorBuffed = false;
    private bool damageBuffed = false;

    private int speedBuffTimer = 0;
    private int armorBuffTimer = 0;
    private int damageBuffTimer = 0;

    private int speedBuffRemain = 1;
    private int armorBuffRemain = 1;
    private int damageBuffRemain = 1;

    private void Update()
    {
        // Speed Buff
        if (Input.GetKeyDown(KeyCode.Z) && !speedBuffed && speedBuffRemain > 0)
        {
            Player.GetComponent<Movement>().BuffSpeed();
            speedBuffed = true;
            speedBuffRemain--;
        }
        if (speedBuffed)
            speedBuffTimer++;
        else
            speedBuffTimer = 0;

        if (speedBuffTimer == 1000)
        {
            Player.GetComponent<Movement>().UnBuffSpeed();
            speedBuffed = false;
        }

        // Armor Buff
        if (Input.GetKeyDown(KeyCode.X) && !armorBuffed && armorBuffRemain > 0)
        {
            Player.GetComponent<HealthSystem>().ArmorBuffed();
            armorBuffed = true;
            armorBuffRemain--;
        }
        if (armorBuffed)
            armorBuffTimer++;
        else
            armorBuffTimer = 0;

        if (armorBuffTimer == 1000)
        {
            Player.GetComponent<HealthSystem>().ArmorUnBuffed();
            armorBuffed = false;
        }

        // Damage Buff
        if (Input.GetKeyDown(KeyCode.C) && !damageBuffed && damageBuffRemain > 0)
        {
            var healthSystemGroup = FindObjectsOfType<HealthSystem>();
            foreach (HealthSystem HS in healthSystemGroup)
                HS.DamageBuffed();
            damageBuffed = true;
            damageBuffRemain--;
        }
        if (damageBuffed)
            damageBuffTimer++;
        else
            damageBuffTimer = 0;

        if (damageBuffTimer == 1000)
        {
            var healthSystemGroup = FindObjectsOfType<HealthSystem>();
            foreach (HealthSystem HS in healthSystemGroup)
                HS.DamageUnBuffed();
            damageBuffed = false;
        }

        //Debug.Log(speedBuffed + ", " + armorBuffed + ", " + damageBuffed);
    }

    public void addOneBuff(string buffType, int cost)
    {
        if (buffType.Equals("speed") && coinSystem.useCoin(cost))
            speedBuffRemain++;
        if (buffType.Equals("armor") && coinSystem.useCoin(cost))
            armorBuffRemain++;
        if (buffType.Equals("damage") && coinSystem.useCoin(cost))
            damageBuffRemain++;
    }

    #region GETTERS
    public bool getSpeedBuff() => speedBuffed;
    public bool getArmorBuff() => armorBuffed;
    public bool getDamageBuff() => damageBuffed;
    public int getSpeedBuffRemain() => speedBuffRemain;
    public int getArmorBuffRemain() => armorBuffRemain;
    public int getDamageBuffRemain() => damageBuffRemain;
    #endregion
}
