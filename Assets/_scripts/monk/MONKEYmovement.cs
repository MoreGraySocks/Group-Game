using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Lexan (Xan) Hewett T-T
public class MONKEYmovement : MonoBehaviour
{
    public float m_CloseDistance = 10f;          // distance from player 
    public Transform m_Gun;                      // npc yk gun lol
    private GameObject m_Player;                 // self explanitory 
    private UnityEngine.AI.NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;
    // npc follows player 
 
    void Start()
    { }
    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }
    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }
    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;          // probably change this?? so like add the animation in or have it moving around small area??
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
        float distance = (m_Player.transform.position - transform.position).magnitude;
        if (distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            m_NavAgent.isStopped = true;
        }
        if (m_Gun != null)
        {
            m_Gun.LookAt(m_Player.transform);
        }
    }
}


