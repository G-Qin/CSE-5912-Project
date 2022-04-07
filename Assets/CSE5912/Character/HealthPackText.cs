using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPackText : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    HealthPack HealthPack;
    private int healthPackCount;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        HealthPack = Player.GetComponent<HealthPack>();
        text = GetComponent<Text>();
        healthPackCount = HealthPack.GetHealthPackCount();
        text.text = ": " + healthPackCount;
    }

    void Update()
    {
        healthPackCount = HealthPack.GetHealthPackCount();
        text.text = ": " + healthPackCount;
    }
}
