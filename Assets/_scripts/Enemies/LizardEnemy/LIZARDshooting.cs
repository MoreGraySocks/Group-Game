using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Milla
public class LIZARDshooting : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform fireTransform;
    public float bulletForce = 30f;
    public float shootDelay = 3f;
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
        bulletInstance.velocity = bulletForce * -fireTransform.right;  // this one's the other way for some unknown reason
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
