using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageBuffText : MonoBehaviour
{
    [SerializeField]
    public BuffManager buffManager;

    private void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "× " + buffManager.getDamageBuffRemain();
    }
}
