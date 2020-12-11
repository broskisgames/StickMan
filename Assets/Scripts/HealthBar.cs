using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void resetHealth()
    {
        slider.value = slider.maxValue;
    }

    public void SetHealth(float damage)
    {
        if (slider.value - damage >= 0)
            slider.value -= damage;
        else
            slider.value = 0;
    }
}
