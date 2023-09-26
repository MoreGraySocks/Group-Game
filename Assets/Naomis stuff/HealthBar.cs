using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PLAYERhealth playerHealthManager;
    public Image healthBarImage;


    private void Update()
    {
        healthBarImage.fillAmount = playerHealthManager.currentHealth / playerHealthManager.maxHealth;
    }


}
