using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuCanvas;

    [SerializeField]
    private GameObject OptionsCanvas;

    [SerializeField]
    public GameObject PlayerCamera;

    [SerializeField]
    private GameObject Player;

    private bool gamePaused = false;
    private bool menuIsOpen = false;
    private bool optionIsOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        // Close menu and resume game
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;

        // Lock Cursor and activate player camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCamera.GetComponent<InfimaGames.LowPolyShooterPack.CameraLook>().enabled = true;

        // Change cursor status in Character
        Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().UpdateCursor();

        // Modify bool values
        menuIsOpen = false;
        optionIsOpen = false;
    }

    public void Pause()
    {
        // Open menu and pause game
        MenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;

        // Unock Cursor and deactivate player camera
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerCamera.GetComponent<InfimaGames.LowPolyShooterPack.CameraLook>().enabled = false;

        // Change cursor status in Character
        Player.GetComponent<InfimaGames.LowPolyShooterPack.Character>().UpdateCursor();

        // Modify bool values
        menuIsOpen = true;
    }

    public void Options()
    {
        if(menuIsOpen)
        {
            MenuCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);

            // Modify bool values
            menuIsOpen = false;
            optionIsOpen = true;
        }
    }

    public void BackToMainMenu()
    {
        if (optionIsOpen)
        {
            OptionsCanvas.SetActive(false);
            MenuCanvas.SetActive(true);

            // Modify bool values
            menuIsOpen = true;
            optionIsOpen = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionTest1()
    {
        Debug.Log("Test 1 pressed!");
    }

    public void OptionTest2()
    {
        Debug.Log("Test 2 pressed!");
    }

    public void OptionTest3()
    {
        Debug.Log("Test 3 pressed!");
    }
}
