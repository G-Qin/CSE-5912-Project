using InfimaGames.LowPolyShooterPack;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplaceWeaponChoice : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private CoinSystem coinSystem;

    [SerializeField]
    private GameObject replaceCanvas;

    [SerializeField]
    private GameObject Weapon_1_Image;

    [SerializeField]
    private GameObject Weapon_2_Image;

    [SerializeField] public Sprite Weapon0;
    [SerializeField] public Sprite Weapon1;
    [SerializeField] public Sprite Weapon2;
    [SerializeField] public Sprite Weapon3;
    [SerializeField] public Sprite Weapon4;
    [SerializeField] public Sprite Weapon5;
    [SerializeField] public Sprite Weapon6;
    [SerializeField] public Sprite Weapon7;
    [SerializeField] public Sprite Weapon8;
    [SerializeField] public Sprite Weapon10;
    [SerializeField] public Sprite Weapon11;
    [SerializeField] public Sprite Weapon12;
    [SerializeField] public Sprite Weapon13;
    [SerializeField] public Sprite Weapon14;
    [SerializeField] public Sprite Weapon16;
    [SerializeField] public Sprite Weapon17;

    private List<int> availableList;
    private int W1;
    private int W2;

    private int newWeapon;
    private int price;

    private void OnEnable()
    {
        availableList = player.GetComponent<Character>().available;

        W1 = availableList[0];
        W2 = availableList[1];

        // Change Weapon 1 image
        if (W1 == 0)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon0;
        else if (W1 == 1)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon1;
        else if (W1 == 2)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon2;
        else if (W1 == 3)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon3;
        else if (W1 == 4)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon4;
        else if (W1 == 5)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon5;
        else if (W1 == 6)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon6;
        else if (W1 == 7)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon7;
        else if (W1 == 8)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon8;
        else if (W1 == 10)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon10;
        else if (W1 == 11)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon11;
        else if (W1 == 12)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon12;
        else if (W1 == 13)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon13;
        else if (W1 == 14)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon14;
        else if (W1 == 16)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon16;
        else if (W1 == 17)
            Weapon_1_Image.GetComponent<Image>().sprite = Weapon17;

        // Change Weapon 2 image
        if (W2 == 0)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon0;
        else if (W2 == 1)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon1;
        else if (W2 == 2)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon2;
        else if (W2 == 3)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon3;
        else if (W2 == 4)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon4;
        else if (W2 == 5)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon5;
        else if (W2 == 6)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon6;
        else if (W2 == 7)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon7;
        else if (W2 == 8)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon8;
        else if (W2 == 10)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon10;
        else if (W2 == 11)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon11;
        else if (W2 == 12)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon12;
        else if (W2 == 13)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon13;
        else if (W2 == 14)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon14;
        else if (W2 == 16)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon16;
        else if (W2 == 17)
            Weapon_2_Image.GetComponent<Image>().sprite = Weapon17;

        // Modify the image position to make it looks better
        if (W1 == 16 || W1 == 17)
            Weapon_1_Image.GetComponent<RectTransform>().position = 
                new Vector3(Weapon_1_Image.GetComponent<RectTransform>().position.x - 25f,
                Weapon_1_Image.GetComponent<RectTransform>().position.y,
                Weapon_1_Image.GetComponent<RectTransform>().position.z);
        if (W2 == 16 || W2 == 17)
            Weapon_2_Image.GetComponent<RectTransform>().position = 
                new Vector3(Weapon_2_Image.GetComponent<RectTransform>().position.x - 25f,
                Weapon_2_Image.GetComponent<RectTransform>().position.y,
                Weapon_2_Image.GetComponent<RectTransform>().position.z);
    }

    public void ReplaceWeapon1()
    {
        if(newWeapon != W1)
            if (coinSystem.useCoin(price))
                player.GetComponent<Character>().available[0] = newWeapon;
        replaceCanvas.SetActive(false);
    }

    public void ReplaceWeapon2()
    {
        if (newWeapon != W2)
            if (coinSystem.useCoin(price))
                player.GetComponent<Character>().available[1] = newWeapon;
        replaceCanvas.SetActive(false);
    }

    public void cancelReplacement()
    {
        replaceCanvas.SetActive(false);
    }

    public void setCurrentPurchasingWeapon(int number, int p)
    {
        this.newWeapon = number;
        this.price = p;
    }
}
