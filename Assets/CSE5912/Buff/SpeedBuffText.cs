using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedBuffText : MonoBehaviour
{
    [SerializeField]
    public BuffManager buffManager;

    private void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "× " + buffManager.getSpeedBuffRemain();
    }
}
