using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// XAN (╥︣﹏᷅╥)
public class BULLETstandard : MonoBehaviour
{
    public float m_MaxLifeTime = 2f;
    public float m_MaxDamage = 30f; // damage done to player/ enemy 
    public float m_ExplosionRadius = 3; // standard bullet so little to no blast radius  
    public float m_ExplosionForce = 50f;
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
