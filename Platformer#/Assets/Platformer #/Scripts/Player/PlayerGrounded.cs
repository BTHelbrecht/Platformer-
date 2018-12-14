// Jerard Carney
// 12.13.18
// PlayerGrounded.cs
// Grounding check

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Public CLass
public class PlayerGrounded : MonoBehaviour 
{
    void OnTriggerStay2D (Collider2D col)
    {
        //Is player on ground?
        if (col.tag == "Ground")                 
        {
            PlayerCtrl.grounded = true;
        }

        //Is player on ground and can jump down?
        if (col.tag == "HalfGround")            
        {
            PlayerCtrl.halfGrounded = true;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        //Is player in air?
        if (col.tag == "Ground")                
        {
            PlayerCtrl.grounded = false;
        }

        //Is player in air?
        if (col.tag == "HalfGround")             
        {
            PlayerCtrl.halfGrounded = false;
        }
    }
}
