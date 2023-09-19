using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Lexan (Xan) Hewett (◑_◑)
public class MonkeyShoot : MonoBehaviour
{
    //public Rigidbody m_Bullet;
    //public Transform m_ShootTransform;
    public float m_FirePower = 25f;
    public float m_ShootDelay = 2.5f;
    private bool m_CanShoot;
    private float m_ShootTimer;
    private void Awake()
    {
        m_CanShoot = false;
        m_ShootTimer = 0;
    }
    private void Update()
    {
        if (m_CanShoot == true)
        {
            m_ShootTimer -= Time.deltaTime;
            if (m_ShootTimer <= 0)
            {
                m_ShootTimer = m_ShootDelay;
                //Shoot();                         //WHY IS IT NOT WORKIN
            }
        }
    }
    private void Start()
    {
        //Rigidbody bulletInstance = Instantiate(m_Bullet, m_ShootTransform.position, m_ShootTransform.rotation) as Rigidbody;
        //bulletInstance.velocity = m_FirePower * m_ShootTransform.forward;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_CanShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_CanShoot = false;
        }
    }
}
