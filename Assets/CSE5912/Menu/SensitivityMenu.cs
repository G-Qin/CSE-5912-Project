using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class SensitivityMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    private float currentSensitivity = 1.0f;

    public void ChangeSensitivity_VerySlow()
    {
        player.GetComponent<Character>().ChangeAxisLookVector(1 / currentSensitivity);
        player.GetComponent<Character>().ChangeAxisLookVector(0.25f);
        currentSensitivity = 0.25f;
    }

    public void ChangeSensitivity_Slow()
    {
        player.GetComponent<Character>().ChangeAxisLookVector(1 / currentSensitivity);
        player.GetComponent<Character>().ChangeAxisLookVector(0.5f);
        currentSensitivity = 0.5f;
    }

    public void ChangeSensitivity_Medium()
    {
        player.GetComponent<Character>().ChangeAxisLookVector(1 / currentSensitivity);
        player.GetComponent<Character>().ChangeAxisLookVector(1.0f);
        currentSensitivity = 1.0f;
    }

    public void ChangeSensitivity_Fast()
    {
        player.GetComponent<Character>().ChangeAxisLookVector(1 / currentSensitivity);
        player.GetComponent<Character>().ChangeAxisLookVector(2.0f);
        currentSensitivity = 2.0f;
    }

    public void ChangeSensitivity_VeryFast()
    {
        player.GetComponent<Character>().ChangeAxisLookVector(1 / currentSensitivity);
        player.GetComponent<Character>().ChangeAxisLookVector(4.0f);
        currentSensitivity = 4.0f;
    }

}
