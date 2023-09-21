using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Milla
public class MONKEYhealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void TargetDestroy()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= collision.gameObject.GetComponent<HandleProjectile>().damage;
            if (currentHealth <= 0)
            {
                TargetDestroy();
            }
        }
    }
}
