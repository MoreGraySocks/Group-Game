using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarLizard : MonoBehaviour
{ 
//naomi
public LIZARDhealth LIZARDHealthManager; //get reference to the players health 
public Image healthBarImage; //get reference to the image/ui used to indicate players health


public void Update()
{
    Debug.Log(healthBarImage.fillAmount); //everytime update function runs, the fill amount on the player health bar will update and either stay the same or change depending on players current health 
    healthBarImage.fillAmount = (float)LIZARDHealthManager.currentHealth / (float)LIZARDHealthManager.maxHealth; //(float) 
}


}
