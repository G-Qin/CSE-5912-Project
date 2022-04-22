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
    private GameObject QualityCanvas;

    [SerializeField]
    private GameObject SensitivityCanvas;

    [SerializeField]
    private GameObject AudioCanvas;

    [SerializeField]
    public GameObject PlayerCamera;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private WeaponShop weaponShop;

    private bool gamePaused = false;
    private bool menuIsOpen = false;
    private bool optionIsOpen = false;
    private bool qualityIsOpen = false;
    private bool sensitivityIsOpen = false;
    private bool audioIsOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (!weaponShop.getGamePauseState() && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        // Close all menus and resume game
        MenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(false);
        QualityCanvas.SetActive(false);
        SensitivityCanvas.SetActive(false);
        AudioCanvas.SetActive(false);
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
        qualityIsOpen = false;
        sensitivityIsOpen = false;
        audioIsOpen = false;
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
        if (menuIsOpen)
        {
            MenuCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);

            // Modify bool values
            menuIsOpen = false;
            optionIsOpen = true;
        }
    }

    public void QualityOptions()
    {
        if (optionIsOpen)
        {
            OptionsCanvas.SetActive(false);
            QualityCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = false;
            qualityIsOpen = true;
        }
    }

    public void SensitivityOptions()
    {
        if (optionIsOpen)
        {
            OptionsCanvas.SetActive(false);
            SensitivityCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = false;
            sensitivityIsOpen = true;
        }
    }

    public void AudioOptions()
    {
        if (optionIsOpen)
        {
            OptionsCanvas.SetActive(false);
            AudioCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = false;
            audioIsOpen = true;
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

    public void QualityBackToOptions()
    {
        if (qualityIsOpen)
        {
            QualityCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = true;
            qualityIsOpen = false;
        }
    }

    public void SensitivityBackToOptions()
    {
        if (sensitivityIsOpen)
        {
            SensitivityCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = true;
            sensitivityIsOpen = false;
        }
    }

    public void AudioBackToOptions()
    {
        if (audioIsOpen)
        {
            AudioCanvas.SetActive(false);
            OptionsCanvas.SetActive(true);

            // Modify bool values
            optionIsOpen = true;
            audioIsOpen = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
