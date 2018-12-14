// Jerard Carney
// 12.13.18
// Win.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Public Class
public class Win : MonoBehaviour
{
    // Collider trigger, loads win screen
    void OnTriggerEnter2D(Collider2D collisin)
    {
        SceneManager.LoadScene("Win");
    }
}
