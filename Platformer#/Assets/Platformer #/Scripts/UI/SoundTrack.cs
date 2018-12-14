// Jerard Carney
// 12.13.18
// SoundTrack.cs
// Loads same music into each screen

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Public Class
public class SoundTrack : MonoBehaviour {

    private void Awake()
    {
        // Gets game object via tag "Music"
        GameObject[] play = GameObject.FindGameObjectsWithTag("Music");

        // If this game object is already in Hierarchy then destroy that game oject and use this one
        if (play.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // do not distrory this game object on a new screen
        DontDestroyOnLoad(this.gameObject);
    }
   
}
