// Jerard Carney
// 12.13.18
// Win.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Public Class
public class MusicOnOff : MonoBehaviour {

    // Private Variable
        // 
    private bool status = false;
    public GameObject clip;

    public void OnOff ()
    {
        status = !status;
        clip.SetActive(status);
    }
}
