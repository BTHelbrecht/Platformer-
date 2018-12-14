// Jerard Carney
// 12.13.18
// StartGame.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Public Class
public class StartGame : MonoBehaviour {

    // Loads level 1
	public void StartPlaying()
    {
        SceneManager.LoadScene("lvl_1");
    }
}
