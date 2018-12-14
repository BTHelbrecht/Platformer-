// Jerard Carney
// 12.13.18
// Menu.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Public Class
public class Menu : MonoBehaviour
{
    // Loads the menu screen
    public void GetMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
