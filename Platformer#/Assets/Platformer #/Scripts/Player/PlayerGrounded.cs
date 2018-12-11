using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour 
{
    void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "Ground")                 //Is player on ground?
        {
            PlayerCtrl.grounded = true;
        }

        if (col.tag == "HalfGround")            //Is player on ground and can jump down?
        {
            PlayerCtrl.halfGrounded = true;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.tag == "Ground")                 //Is player in air?
        {
            PlayerCtrl.grounded = false;
        }

        if (col.tag == "HalfGround")             //Is player in air?
        {
            PlayerCtrl.halfGrounded = false;
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/