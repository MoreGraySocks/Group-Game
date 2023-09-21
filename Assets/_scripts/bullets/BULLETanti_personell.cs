using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// XAN (╥﹏╥)
// it is currently not working because no player health and one of us needs to do that 
public class BULLETanti_personell : MonoBehaviour
{
    public float m_MaxLifeTime = 2f;
    public float m_MaxDamage = 50f; // damage done to player/ enemy 
    public float m_ExplosionRadius = 10; // antipersonell so it has larger blast radius and force 
    public float m_ExplosionForce = 150f;
    // public ParticleSystem m_ExplosionParticles;
    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody targetRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (targetRigidbody != null)
        {
            targetRigidbody.AddExplosionForce(m_ExplosionForce,
           transform.position, m_ExplosionRadius);
            PlayerHeath targetHealth = targetRigidbody.GetComponent<PlayerHealth>();
            if (targetHealth != null)
            {
                float damage = CalculateDamage(targetRigidbody.position);
                targetHealth.TakeDamage(damage);
            }
        }
        // m_ExplosionParticles.transform.parent = null;
        // m_ExplosionParticles.Play();
        //  Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        // Destroy(gameObject);
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance =
       (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}
