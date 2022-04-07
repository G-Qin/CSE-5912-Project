using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderProgress : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider timeSlider;
    public float gameTime;

    private bool isActive = false;
    bool ammoInRange = false;
    [SerializeField] private GameObject ammoBox;
    AmmoBox ammo_script;
    void Start()
    {
        timeSlider.maxValue=gameTime;
        timeSlider.value=0;
    }

    // Update is called once per frame
    void Update()
    {
        ammo_script = ammoBox.GetComponent<AmmoBox>();
        ammoInRange = ammo_script.inRange;
        if(ammoInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isActive){
            timeSlider.gameObject.SetActive(true);
            timeSlider.value = 0;
            isActive = true;
        }

        if (Input.GetKey(KeyCode.E)&& isActive)
        { 
            timeSlider.value += Time.deltaTime;
            if (timeSlider.value >= gameTime){
                isActive = false;
                timeSlider.gameObject.SetActive(false);
            }
        } 
        if (Input.GetKeyUp(KeyCode.E) && isActive)
        { 
            timeSlider.gameObject.SetActive(false);
            timeSlider.value = 0;
            isActive = false;
        }

        }
    }
}