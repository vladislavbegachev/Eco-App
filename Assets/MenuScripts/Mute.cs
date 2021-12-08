using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{ 
    public static bool isMute = false;

    public void isMusicMute()
    {
        if (isMute)
        {
            isMute = !isMute;
            GetComponent<AudioSource>().volume = 0.5f;
        }
        else
        {
            isMute = !isMute;
            GetComponent<AudioSource>().volume = 0f;
        }
    }
}
