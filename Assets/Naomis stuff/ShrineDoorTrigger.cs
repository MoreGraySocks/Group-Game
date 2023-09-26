using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ShrineDoorTrigger : MonoBehaviour
{ 
public Animator animation;
public GameObject trigger;
public GameObject door;


void Start()
{
    animation.enabled = false;
}

void OnTriggerEnter(Collider collision)
{
    if (collision.gameObject.tag == ("Player"))
    {
        animation.enabled = true;
    }
}
}
