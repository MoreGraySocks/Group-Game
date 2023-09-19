using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Lexan (Xan) Hewett ( ͡❛ ⏥ ͡❛)
public class MonkeyMovement : MonoBehaviour
{
    public float m_PlayerDistance = 10f;          // distance from player 
    public Transform m_Gun;                      // npc yk gun lol
    private GameObject m_Player;                 // self explanitory 
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;
    private bool m_Shoot;                        // sniper monkey snipes :)
    void Start()
    { }
    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Shoot = false;
    }
    private void OnEnable()                      //sniper monkey is idle so he doesnt move, though adding in the animations is probably important 
    {
        m_Rigidbody.isKinematic = true;
    }
    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;         
    }
    private void OnTriggerEnter(Collider other)  //monke shoot
    {
        if (other.tag == "Player")
        {
            m_Shoot = true;     
        }
    }
    private void OnTriggerExit(Collider other)   //monke no shoot
    {
        if (other.tag == "Player")
        {
            m_Shoot = false;
        }
    }
    void Update()
    {
        float distance = (m_Player.transform.position - transform.position).magnitude;
        if (distance > m_PlayerDistance)
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
            m_Gun.LookAt(m_Player.transform);   // monk aim
        }
    }
}
