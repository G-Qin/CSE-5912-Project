using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField]
    public GameObject WeaponShopUI;

    [SerializeField]
    public GameObject PlayerCamera;

    [SerializeField]
    public GameObject Player;

    [SerializeField]
    public GameObject ShopTrigger;

    private bool gamePaused = false;
    private bool shopAvailable;


    // Update is called once per frame
    void Update()
    {
        shopAvailable = ShopTrigger.GetComponent<WeaponShopTrigger>().shopAvailable;
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!gamePaused && shopAvailable)
                Pause();
            else if (gamePaused)
                Resume();
        }
        if (gamePaused && Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public void Resume()
    {
        // Close store and resume game
        WeaponShopUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;

        // Lock Cursor and activate player camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCamera.GetComponent<InfimaGames.LowPolyShooterPack.CameraLook>().enabled = true;

        // Change cursor status in Character
        Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().UpdateCursor();
    }

    public void Pause()
    {
        // Open store and pause game
        WeaponShopUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;

        // Unock Cursor and deactivate player camera
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerCamera.GetComponent<InfimaGames.LowPolyShooterPack.CameraLook>().enabled = false;

        // Change cursor status in Character
        Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().UpdateCursor();
    }

    public bool getGamePauseState() => gamePaused;
}
