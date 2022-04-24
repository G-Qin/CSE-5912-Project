using InfimaGames.LowPolyShooterPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    [SerializeField] GameObject LevelManager;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject BuffManager;
    [SerializeField] GameObject AmmoBox;
    [SerializeField] GameObject WeaponShop;

    public void SaveCurrentLevel(){
        // Level number
        int levelNum = LevelManager.GetComponent<LevelManager>().levelNum;
        PlayerPrefs.SetInt("LevelNum", levelNum);
        // Health
        int health = Player.GetComponent<HealthSystem>().health;
        PlayerPrefs.SetInt("PlayerHealth", health);
        // Grenade Count
        PlayerPrefs.SetInt("GrenadeCount", Player.GetComponent<Character>().grenadeTotal);
        // Weapon
        int firstWeapon = Player.GetComponent<Character>().available[0];
        int secondWeapon = Player.GetComponent<Character>().available[1];
        PlayerPrefs.SetInt("FirstWeapon", firstWeapon);
        PlayerPrefs.SetInt("SecondWeapon", secondWeapon);
        // Ammo of 1st weapon
        // Ammo of 2nd weapon
        // Health Pack
        int healthPackNum = Player.GetComponent<HealthPack>().healthPackCount;
        PlayerPrefs.SetInt("HealthPack", healthPackNum);
        // Buffs
        PlayerPrefs.SetInt("ArmorBuff", BuffManager.GetComponent<BuffManager>().armorBuffRemain);
        PlayerPrefs.SetInt("SpeedBuff", BuffManager.GetComponent<BuffManager>().speedBuffRemain);
        PlayerPrefs.SetInt("damageBuff", BuffManager.GetComponent<BuffManager>().damageBuffRemain);
        // Player Position
        PlayerPrefs.SetFloat("PlayerPosX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", Player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", Player.transform.position.z);
        // Coins
        int coins = Player.GetComponent<HealthPack>().CoinSystem.currentCoin();
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void LoadCurrLevelData(){
        // Ammo box and shop location
        if (PlayerPrefs.GetInt("LevelNum") >= 6){
            AmmoBox.transform.position = new Vector3(173f,-7.8f,25f);
            WeaponShop.transform.position = new Vector3(165.76f,-5.27f,21f);
        }

        // Level number
        LevelManager.GetComponent<LevelManager>().levelNum = PlayerPrefs.GetInt("LevelNum");
        // Health
        Player.GetComponent<HealthSystem>().health = PlayerPrefs.GetInt("PlayerHealth");
        HealthBar.GetComponent<HealthBar>().slider.value = PlayerPrefs.GetInt("PlayerHealth");
        // Grenade Count
        Player.GetComponent<Character>().grenadeTotal = PlayerPrefs.GetInt("GrenadeCount");
        // Weapon
        Player.GetComponent<Character>().available[0] = PlayerPrefs.GetInt("FirstWeapon");
        Player.GetComponent<Character>().available[1] = PlayerPrefs.GetInt("SecondWeapon");
        // Ammo of 1st weapon
        // Ammo of 2nd weapon
        // Health Pack
        Player.GetComponent<HealthPack>().healthPackCount = PlayerPrefs.GetInt("HealthPack");
        // Buffs
        BuffManager.GetComponent<BuffManager>().armorBuffRemain = PlayerPrefs.GetInt("ArmorBuff");
        BuffManager.GetComponent<BuffManager>().speedBuffRemain = PlayerPrefs.GetInt("SpeedBuff");
        BuffManager.GetComponent<BuffManager>().damageBuffRemain = PlayerPrefs.GetInt("DamageBuff");
        // Player Position
        Player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        // Coins
        Player.GetComponent<HealthPack>().CoinSystem.addCoin(PlayerPrefs.GetInt("Coins") - 500 * PlayerPrefs.GetInt("LevelNum"));
    }
}
