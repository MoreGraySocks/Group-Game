using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Milla
public class MONKEYshooting : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform fireTransform;
    public float bulletForce = 30f;
    public float shootDelay = 1.5f;
    private bool canShoot;
    private float shootTimer;

    void Start()
    {
        canShoot = false;
        shootTimer = 0;
    }

    void Update()
    {
        if (canShoot == true)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = shootDelay;
                Fire();
            }
        }
    }

    private void Fire()
    {
        Rigidbody bulletInstance = Instantiate(bullet, fireTransform.position, fireTransform.rotation) as Rigidbody;
        bulletInstance.velocity = bulletForce * fireTransform.right;   //bullet goes sideways if sent forward due to the LookAt making the gun face the wrong way
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = false;
        }
    }
}
