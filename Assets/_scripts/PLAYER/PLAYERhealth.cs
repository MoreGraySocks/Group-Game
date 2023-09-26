using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERhealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            currentHealth -= collision.gameObject.GetComponent<HandleProjectile>().damage;
            Debug.Log("player health is " + currentHealth);
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "EnemyProjectile")
    //    {
    //        currentHealth -= other.gameObject.GetComponent<HandleProjectile>().damage;
    //        if (currentHealth <= 0)
    //        {
    //            GameOver();
    //        }
    //    }
    //}
}
