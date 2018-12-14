// Jerard Carney
// 12.13.18
// PlayerHp.cs
// Player diplay and interaction with HP objects

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Used Headers for a more organized inspector


// Public Class
public class PlayerHp : MonoBehaviour 
{
    // Public Variables
        // Amount of health/maxhealth player has, and amout of deaths player has /can have
    static public int s_maxHearts;
    static public int s_realMaxHearts;
    static public int s_hp;
    public int maxDead;
    public int actualDead;

        // Ranges of value for the above variables
    [Header("Settings")]
    [Range(1, 5)]
    public int maxHearts = 3;
    [Range(1, 5)]
    public int realMaxHearts = 5;
    [Range(0, 10)]
    public int hp = 3;

        // Health bar game objects for displaying on screen.
    [Header("GUI Sprites")]
    public GameObject[] hpSpritesBg;
    public GameObject[] hpSprites;

    void Start ()           
    {
        //Sets the values to the start settings.
        s_maxHearts = maxHearts;
        s_realMaxHearts = realMaxHearts;
        s_hp = hp;
    }



	void Update () 
    {
        //Updates the health of the player and enables you to change the health ingame.
        ValueCheck();
        //Limits values.
        Limitations();
        //Updates the current health of the player.
        UpdateHealth();     
	}



    void UpdateHealth ()
    {
        //Removes the hp below the current hp count.
        for (int i = (realMaxHearts*2) - hp; i > 0; i--)       
        {
            hpSprites[hp +i].SetActive(false);
        }

        //Removes the hearts below the current heart count.
        for (int i = realMaxHearts - maxHearts; i > 0; i--)  
        {
            hpSpritesBg[maxHearts +i].SetActive(false);
        }

        //Makes the current heart count visible.
        hpSpritesBg[maxHearts].SetActive(true);
        //Makes the current hp count visible.
        hpSprites[hp].SetActive(true);                         
    }




    void Limitations ()
    {
        // assigns 0 to actual deahts of player
        actualDead = 0;

        if (maxHearts >= realMaxHearts)
        {
            maxHearts = realMaxHearts;
        }

        //Prevents hp to go over the current maximum hp count (Part1).
        if (hp >= maxHearts * 2)        
        {
            // Mult. by 2 becuase you have ability to game half HP
            hp = maxHearts * 2;
        }

        //Prevents hp to go below 0.
        {
            if (hp <= 0)                    
            hp = 0;
            //Player dead ---> Restart level.
            PlayerCtrl.died = true;  
            // Add 1 to actual deaths of player
            ++actualDead;
        }

        // If player reaches max deaths they go to lose screen
        if (actualDead >= maxDead)
        {
            SceneManager.LoadScene("Lose");
        }

        //Prevents hp to go over the current maximum hp count (Part2).
        s_maxHearts = maxHearts;     
        s_realMaxHearts = realMaxHearts;
        s_hp = hp;
    }


    // A final assignment of correct values
    void ValueCheck ()
    {
        maxHearts = s_maxHearts;
        realMaxHearts = s_realMaxHearts;
        hp = s_hp;
    }
}



