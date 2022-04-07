using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDisplay : MonoBehaviour
{
    [SerializeField]
    private BuffManager buffManager;

    [SerializeField]
    private GameObject speedBuffImage;
    [SerializeField]
    private GameObject armorBuffImage;
    [SerializeField]
    private GameObject damageBuffImage;

    private bool speedBuffed;
    private bool armorBuffed;
    private bool damageBuffed;

    private void Update()
    {
        speedBuffed = buffManager.getSpeedBuff();
        armorBuffed = buffManager.getArmorBuff();
        damageBuffed = buffManager.getDamageBuff();
        
        // speed buff modify
        if (speedBuffed)
            speedBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
        else
            speedBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 0.4f);

        // armor buff modify
        if (armorBuffed)
            armorBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
        else
            armorBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 0.4f);

        // damage buff modify
        if (damageBuffed)
            damageBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 1.0f);
        else
            damageBuffImage.GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 0.4f);
    }
}
