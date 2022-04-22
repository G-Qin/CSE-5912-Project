using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriceColor : MonoBehaviour
{
    [SerializeField]
    private GameObject currentItem;

    [SerializeField]
    private CoinSystem coinSystem;

    [SerializeField]
    private int price;

    private bool buyable;

    private Color red;
    private Color yellow;

    private void Awake()
    {
        red = new Color(255f, 0f, 0f);
        yellow = currentItem.GetComponent<TextMeshProUGUI>().color;
    }

    private void Update()
    {
        if (coinSystem.currentCoin() < price)
        {
            buyable = false;
            currentItem.GetComponent<TextMeshProUGUI>().color = red;
        }
        else
        {
            buyable = true;
            currentItem.GetComponent<TextMeshProUGUI>().color = yellow;
        }
    }

    public bool getBuyable()
    {
        return buyable;
    }
}
