using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public CoinSystem coinSystem;

    private List<int> weaponList;

    private void Awake()
    {
        weaponList = Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().available;
    }

    // purchase a weapon

    #region PURCHASE
    public void EnableWeapon_0()
    {
        if (!weaponList.Contains(0) && coinSystem.useCoin(1000))
            weaponList.Add(0);
    }

    public void EnableWeapon_1()
    {
        if (!weaponList.Contains(1) && coinSystem.useCoin(1000))
            weaponList.Add(1);
    }
    public void EnableWeapon_2()
    {
        if (!weaponList.Contains(2) && coinSystem.useCoin(1000))
            weaponList.Add(2);
    }
    public void EnableWeapon_3()
    {
        if (!weaponList.Contains(3) && coinSystem.useCoin(1000))
            weaponList.Add(3);
    }
    public void EnableWeapon_4()
    {
        if (!weaponList.Contains(4) && coinSystem.useCoin(1000))
            weaponList.Add(4);
    }
    public void EnableWeapon_5()
    {
        if (!weaponList.Contains(5) && coinSystem.useCoin(1000))
            weaponList.Add(5);
    }
    public void EnableWeapon_6()
    {
        if (!weaponList.Contains(6) && coinSystem.useCoin(1000))
            weaponList.Add(6);
    }
    public void EnableWeapon_7()
    {
        if (!weaponList.Contains(7) && coinSystem.useCoin(1000))
            weaponList.Add(7);
    }
    public void EnableWeapon_8()
    {
        if (!weaponList.Contains(8) && coinSystem.useCoin(1000))
            weaponList.Add(8);
    }
    public void EnableWeapon_9()
    {
        if (!weaponList.Contains(9) && coinSystem.useCoin(1000))
            weaponList.Add(9);
    }
    public void EnableWeapon_10()
    {
        if (!weaponList.Contains(10) && coinSystem.useCoin(1000))
            weaponList.Add(10);
    }
    public void EnableWeapon_11()
    {
        if (!weaponList.Contains(11) && coinSystem.useCoin(1000))
                weaponList.Add(11);
    }
    public void EnableWeapon_12()
    {
        if (!weaponList.Contains(12) && coinSystem.useCoin(1000))
                weaponList.Add(12);
    }
    public void EnableWeapon_13()
    {
        if (!weaponList.Contains(13) && coinSystem.useCoin(1000))
                weaponList.Add(13);
    }
    public void EnableWeapon_14()
    {
        if (!weaponList.Contains(14) && coinSystem.useCoin(1000))
                weaponList.Add(14);
    }
    public void EnableWeapon_15()
    {
        if (!weaponList.Contains(15) && coinSystem.useCoin(1000))
                weaponList.Add(15);
    }
    public void EnableWeapon_16()
    {
        if (!weaponList.Contains(16) && coinSystem.useCoin(1000))
                weaponList.Add(16);
    }
    public void EnableWeapon_17()
    {
        if (!weaponList.Contains(17) && coinSystem.useCoin(1000))
                weaponList.Add(17);
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
