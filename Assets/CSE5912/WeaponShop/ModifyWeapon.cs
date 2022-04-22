using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject replaceCanvas;

    // purchase a weapon

    #region PURCHASE
    public void PurchaseWeapon_0()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(0, 7500);
    }
    public void PurchaseWeapon_1()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(1, 6000);
    }
    public void PurchaseWeapon_2()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(2, 5000);
    }
    public void PurchaseWeapon_3()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(3, 8000);
    }
    public void PurchaseWeapon_4()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(4, 4000);
    }
    public void PurchaseWeapon_5()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(5, 9000);
    }
    public void PurchaseWeapon_6()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(6, 500);
    }
    public void PurchaseWeapon_7()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(7, 3000);
    }
    public void PurchaseWeapon_8()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(8, 10000);
    }
    public void PurchaseWeapon_10()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(10, 4500);
    }
    public void PurchaseWeapon_11()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(11, 5500);
    }
    public void PurchaseWeapon_12()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(12, 1000);
    }
    public void PurchaseWeapon_13()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(13, 20000);
    }
    public void PurchaseWeapon_14()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(14, 6500);
    }
    public void PurchaseWeapon_16()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(16, 6000);
    }
    public void PurchaseWeapon_17()
    {
        replaceCanvas.SetActive(true);
        replaceCanvas.GetComponent<ReplaceWeaponChoice>().setCurrentPurchasingWeapon(17, 10000);
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
