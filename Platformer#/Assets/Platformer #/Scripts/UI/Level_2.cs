// Jerard Carney
// 12.13.18
// Level_2.cs
// Loads scene

//Librariesusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Public Class
public class Level_2 : MonoBehaviour {

    // Collider trigger, loads level 2
    void OnTriggerEnter2D(Collider2D collisin)
    {
        SceneManager.LoadScene("lvl_2");
    }

    // Loads level 2
    public void Level2()
    {
        SceneManager.LoadScene("lvl_2");
    }
}
