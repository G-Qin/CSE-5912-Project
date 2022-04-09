using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    private int coinNum;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        coinNum = 0;
    }

    private void LateUpdate()
    {
        text.text = coinNum.ToString();
    }

    public void addCoin(int coins)
    {
        coinNum = coinNum + coins;
    }

    public int currentCoin()
    {
        return coinNum;
    }

    public bool useCoin(int i)
    {
        if (coinNum >= i)
        {
            coinNum -= i;
            return true;
        }
        return false;
    }
}
