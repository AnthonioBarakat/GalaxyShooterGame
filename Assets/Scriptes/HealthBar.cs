using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private static Slider slider;
    public static Image fill;

    

    public void Awake()
    {
        slider = GetComponent<Slider>();
        fill = GameObject.Find("Fill").GetComponent<Image>();
    }

    public static void SetHealth(int health)
    {
        slider.value = health;
        if (health < 30)
        {
            fill.color = Color.red;
        }
        else if(health > 30 && health <= 50)
        {
            fill.color = Color.yellow;
        }
        else
        {
            fill.color = Color.green;
        }
    }

}
