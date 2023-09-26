using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSFX : MonoBehaviour
{

    public AudioSource playSound;
    public AudioSource pauseSound;
    public GameObject TheyJumpedEnding;

    void OnTriggerEnter(Collider other)
    {
        playSound.Play();
        pauseSound.Stop();
        TheyJumpedEnding.SetActive(true);
    }

}
