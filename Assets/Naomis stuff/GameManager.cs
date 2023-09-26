using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        listOfEnemies = getOfType < enemy > ()
    }

    // Update is called once per frame
    void Update()
    {
        int counter = 0;
        foreach enemy in listOfEnemies
            if(enemy == null)
            {
                counter++;
            }
        if (counter >= listOfEnemies.length)
        {
            endgame()
        }
    }
}
