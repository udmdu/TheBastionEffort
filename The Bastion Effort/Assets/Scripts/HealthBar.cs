using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider, ShieldSlider;

    public void SetHealth(float health)
    {
        HealthSlider.value = health;
    }

    public void setShield(float shield)
    {
        ShieldSlider.value = shield;
    }
}
