using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleProjectile : MonoBehaviour
{
    public float projectileLife = 2f;
    private float timer;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= projectileLife)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
