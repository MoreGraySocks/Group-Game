using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYERhealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
    }

    private void GameOver() //you dead function
    {
        //gameObject.SetActive(false);
        //Scene manager will load a scene depending on the current scene index number +1. this one will load the death screen scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            currentHealth -= collision.gameObject.GetComponent<HandleProjectile>().damage;
            Debug.Log("player health is " + currentHealth);
            if (currentHealth <= 0)
            {
                //GameOver function aka you dead
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
