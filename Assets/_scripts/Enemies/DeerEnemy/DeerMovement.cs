using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Milla
public class DeerMovement : MonoBehaviour
{
    public float m_CloseDistance = 2f;
    //public Transform m_Gun;
    private GameObject m_Player;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;
    private bool m_Follow;

    void Start()
    { }

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }
    }

    void Update()
    {
        if (m_Follow == false)
            return;
        float distance = ((m_Player.transform.position - transform.position).magnitude); 
        if (distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            m_NavAgent.isStopped = true;
        }
    }
}
