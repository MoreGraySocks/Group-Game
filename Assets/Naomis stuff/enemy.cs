using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float howclose;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);

        if (dist <= howclose)
        {
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        //for melee attack or explosive
        if (dist <= 1.5f)
        {
            //do damage or explode
        }
    }
}
