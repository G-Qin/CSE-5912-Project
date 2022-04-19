using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;

    [SerializeField]
    private CoinSystem CoinSystem;

    public void BuyGrenade()
    {
        if(CoinSystem.useCoin(500))
            Player.GetComponent<Character>().AddGrenade();
    }
}
