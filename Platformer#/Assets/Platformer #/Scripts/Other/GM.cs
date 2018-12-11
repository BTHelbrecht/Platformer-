using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour 
{
    public static int score = 0;

    [Header("Settings")]
    public TextMesh textMesh;

	void Start () 
    {
        score = 0;
	}

	void Update () 
    {
        textMesh.text = "Score: " + score.ToString();   //Sets the score (int) to a string and display it on the TextMesh.
	}
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/