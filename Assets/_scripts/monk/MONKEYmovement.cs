using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Lexan (Xan) Hewett T-T
public class MONKEYmovement : MonoBehaviour
{
    public float m_CloseDistance = 10f;          // distance from player 
    public Transform m_Gun;                      // npc yk gun lol
    private GameObject m_Player;                 // self explanitory 
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;
    // npc follows player 
 
    void Start()
    { }
    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        
    }
    private void OnEnable()
    {
        m_Rigidbody.isKinematic = true;
    }
    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;          // probably change this?? so like add the animation in or have it moving around small area??
    }
   
    void Update()                                   // someone not tired needs to work out haw to make it, most likely needed with a new script 
    {
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

}
