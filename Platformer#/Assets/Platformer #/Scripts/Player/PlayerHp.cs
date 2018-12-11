using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour 
{
    static public int s_maxHearts;
    static public int s_realMaxHearts;
    static public int s_hp;

    [Header("Settings")]
    [Range(1, 5)]
    public int maxHearts = 3;
    [Range(1, 5)]
    public int realMaxHearts = 5;
    [Range(0, 10)]
    public int hp = 3;
    [Header("GUI Sprites")]
    public GameObject[] hpSpritesBg;
    public GameObject[] hpSprites;

    void Start ()           //Sets the values to the start settings.
    {
        s_maxHearts = maxHearts;
        s_realMaxHearts = realMaxHearts;
        s_hp = hp;
    }

	void Update () 
    {
        ValueCheck();       //Updates the health of the player and enables you to change the health ingame.
        Limitations();      //Limits values.
        UpdateHealth();     //Updates the current health of the player.
	}

    void UpdateHealth ()
    {
        for (int i = (realMaxHearts*2) - hp; i > 0; i--)       //Removes the hp below the current hp count.
        {
            hpSprites[hp +i].SetActive(false);
        }

        for (int i = realMaxHearts - maxHearts; i > 0; i--)    //Removes the hearts below the current heart count.
        {
            hpSpritesBg[maxHearts +i].SetActive(false);
        }

        hpSpritesBg[maxHearts].SetActive(true);                //Makes the current heart count visible.
        hpSprites[hp].SetActive(true);                         //Makes the current hp count visible.
    }

    void Limitations ()
    {
        if (maxHearts >= realMaxHearts)
        {
            maxHearts = realMaxHearts;
        }

        if (hp >= maxHearts * 2)        //Prevents hp to go over the current maximum hp count (Part1).
        {
            hp = maxHearts * 2;
        }

        if (hp <= 0)                    //Prevents hp to go below 0.
        {
            hp = 0;
            PlayerCtrl.died = true;     //Player dead ---> Restart level.
        }

        s_maxHearts = maxHearts;        //Prevents hp to go over the current maximum hp count (Part2).
        s_realMaxHearts = realMaxHearts;
        s_hp = hp;
    }

    void ValueCheck ()
    {
        maxHearts = s_maxHearts;
        realMaxHearts = s_realMaxHearts;
        hp = s_hp;
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/