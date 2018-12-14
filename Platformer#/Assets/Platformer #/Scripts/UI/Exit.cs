// Jerard Carney
// 12.13.18
// Exit.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Public Variable
public class Exit : MonoBehaviour {

    public void ExitGame()
    {
        // Quits the game
        Application.Quit();
    }
}
