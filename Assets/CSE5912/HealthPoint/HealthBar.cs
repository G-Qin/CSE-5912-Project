using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image blood;
       //123
       //123
        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
            gradient.Evaluate(1f);
        }
        public void SetHealth(int health)
        {
            slider.value = health;
            blood.color = gradient.Evaluate(slider.normalizedValue);
        }

    }


