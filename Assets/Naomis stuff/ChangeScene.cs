using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Naomi K
    public void MoveToScene(int SceneIndex) //displays public option to user in unity to move to a scene from the index number its listed as when u go into build settings
    {
        SceneManager.LoadScene(SceneIndex); //this will load in a scene depending on which index number was input
    }

    public void QuitGame() //func that will quit out of the game entirely
    {
        Application.Quit();
        Debug.Log("Game is exiting...good choice..leave now while you have the chance..."); //will disply this before closing you out of the game
    }
}
