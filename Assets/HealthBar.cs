using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Transform player;

    private RectTransform healthBarRectTransform;

    private void Start()
   {     
        // Get the RectTransform component of the health bar
        healthBarRectTransform = GetComponent<RectTransform>();
   }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    
            //healthBarRectTransform.position = player.position;
    private void LateUpdate()
    {
        if (player != null)
        {   
            // // Set the position of the health bar to be above the player
             Vector3 position = player.position + new Vector3(0, 1.5f, 0);
             healthBarRectTransform.position = Camera.main.WorldToScreenPoint(player.position + new Vector3(0, 1.5f, 0));
            // healthBarRectTransform.position = position;
        }
    }
}
