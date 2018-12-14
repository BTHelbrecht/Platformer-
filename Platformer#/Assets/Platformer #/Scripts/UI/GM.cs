// Jerard Carney
// 12.13.18
// GM.cs
// Loads scene

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used headers for organizing inspector

// Public Class
public class GM : MonoBehaviour 
{
    // Public Variable
        // Score for player starts at 0
    public static int score = 0;

        // Text overlay on the screen
    [Header("Settings")]
    public TextMesh textMesh;

	void Start () 
    {
        // player score
        score = 0;
	}

	void Update () 
    {
        //Sets the score (int) to a string and display it on the TextMesh.
        textMesh.text = "Score: " + score.ToString();   
	}
}
