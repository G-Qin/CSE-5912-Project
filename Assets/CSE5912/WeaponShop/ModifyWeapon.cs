using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;

    private List<int> weaponList;

    private void Start()
    {
        weaponList = Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().available;
    }

    // Enable a selected kind of weapon by clicking the enable buttons in shop

    #region ENABLE
    public void EnableWeapon_0()
    {
        if (!weaponList.Contains(0))
        weaponList.Add(0);
    }

    public void EnableWeapon_1()
    {
        if (!weaponList.Contains(1))
        weaponList.Add(1);
    }
    public void EnableWeapon_2()
    {
        if (!weaponList.Contains(2))
        weaponList.Add(2);
    }
    public void EnableWeapon_3()
    {
        if (!weaponList.Contains(3))
        weaponList.Add(3);
    }
    public void EnableWeapon_4()
    {
        if (!weaponList.Contains(4))
        weaponList.Add(4);
    }
    public void EnableWeapon_5()
    {
        if (!weaponList.Contains(5))
        weaponList.Add(5);
    }
    public void EnableWeapon_6()
    {
        if (!weaponList.Contains(6))
        weaponList.Add(6);
    }
    public void EnableWeapon_7()
    {
        if (!weaponList.Contains(7))
        weaponList.Add(7);
    }
    public void EnableWeapon_8()
    {
        if (!weaponList.Contains(8))
        weaponList.Add(8);
    }
    public void EnableWeapon_9()
    {
        if (!weaponList.Contains(9))
        weaponList.Add(9);
    }
    public void EnableWeapon_10()
    {
        if (!weaponList.Contains(10))
        weaponList.Add(10);
    }
    public void EnableWeapon_11()
    {
        if (!weaponList.Contains(11))
            weaponList.Add(11);
    }
    public void EnableWeapon_12()
    {
        if (!weaponList.Contains(12))
            weaponList.Add(12);
    }
    public void EnableWeapon_13()
    {
        if (!weaponList.Contains(13))
            weaponList.Add(13);
    }
    public void EnableWeapon_14()
    {
        if (!weaponList.Contains(14))
            weaponList.Add(14);
    }
    public void EnableWeapon_15()
    {
        if (!weaponList.Contains(15))
            weaponList.Add(15);
    }
    public void EnableWeapon_16()
    {
        if (!weaponList.Contains(16))
            weaponList.Add(16);
    }
    public void EnableWeapon_17()
    {
        if (!weaponList.Contains(17))
            weaponList.Add(17);
    }
    #endregion

    // Disable a selected kind of weapon by clicking the disable buttons in shop

    #region DISABLE
    public void DisableWeapon_0()
    {
        if(weaponList.Contains(0) && CheckEmptyList(weaponList))
            weaponList.Remove(0);
    }
    public void DisableWeapon_1()
    {
        if (weaponList.Contains(1) && CheckEmptyList(weaponList))
            weaponList.Remove(1);
    }
    public void DisableWeapon_2()
    {
        if (weaponList.Contains(2) && CheckEmptyList(weaponList))
            weaponList.Remove(2);
    }
    public void DisableWeapon_3()
    {
        if (weaponList.Contains(3) && CheckEmptyList(weaponList))
            weaponList.Remove(3);
    }
    public void DisableWeapon_4()
    {
        if (weaponList.Contains(4) && CheckEmptyList(weaponList))
            weaponList.Remove(4);
    }
    public void DisableWeapon_5()
    {
        if (weaponList.Contains(5) && CheckEmptyList(weaponList))
            weaponList.Remove(5);
    }
    public void DisableWeapon_6()
    {
        if (weaponList.Contains(6) && CheckEmptyList(weaponList))
            weaponList.Remove(6);
    }
    public void DisableWeapon_7()
    {
        if (weaponList.Contains(7) && CheckEmptyList(weaponList))
            weaponList.Remove(7);
    }
    public void DisableWeapon_8()
    {
        if (weaponList.Contains(8) && CheckEmptyList(weaponList))
            weaponList.Remove(8);
    }
    public void DisableWeapon_9()
    {
        if (weaponList.Contains(9) && CheckEmptyList(weaponList))
            weaponList.Remove(9);
    }
    public void DisableWeapon_10()
    {
        if (weaponList.Contains(10) && CheckEmptyList(weaponList))
            weaponList.Remove(10);
    }
    public void DisableWeapon_11()
    {
        if (weaponList.Contains(11) && CheckEmptyList(weaponList))
            weaponList.Remove(11);
    }
    public void DisableWeapon_12()
    {
        if (weaponList.Contains(12) && CheckEmptyList(weaponList))
            weaponList.Remove(12);
    }
    public void DisableWeapon_13()
    {
        if (weaponList.Contains(13) && CheckEmptyList(weaponList))
            weaponList.Remove(13);
    }
    public void DisableWeapon_14()
    {
        if (weaponList.Contains(14) && CheckEmptyList(weaponList))
            weaponList.Remove(14);
    }
    public void DisableWeapon_15()
    {
        if (weaponList.Contains(15) && CheckEmptyList(weaponList))
            weaponList.Remove(15);
    }
    public void DisableWeapon_16()
    {
        if (weaponList.Contains(16) && CheckEmptyList(weaponList))
            weaponList.Remove(16);
    }
    public void DisableWeapon_17()
    {
        if (weaponList.Contains(17) && CheckEmptyList(weaponList))
            weaponList.Remove(17);
    }
    #endregion

    // Other methods to make sure the enable/disable functions work

    #region METHODS

    /*
     *  Check if the weapon list has only 1 weapon remaining
     *  if only 1 remaining, don't disable weapon
     */
    private bool CheckEmptyList(List<int> list)
    {
        if(list.Count == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion
}
