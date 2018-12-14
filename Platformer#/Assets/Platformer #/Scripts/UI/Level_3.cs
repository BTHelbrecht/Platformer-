// Jerard Carney
// 12.13.18
// Level_3.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Public Class
public class Level_3 : MonoBehaviour
{
    // Collider Trigger, loads level 3
    void OnTriggerEnter2D(Collider2D collisin)
    {
        SceneManager.LoadScene("lvl_3");
    }

    // Loads level 3
    public void Level3()
    {
        SceneManager.LoadScene("lvl_3");
    }
}