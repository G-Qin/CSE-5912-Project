using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerHealthText;

    [SerializeField]
    Slider bar;
    
    void Update() {
        playerHealthText.text = bar.value.ToString();
    }
}
