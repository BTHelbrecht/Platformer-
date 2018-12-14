// Jerard Carney
// 12.13.18
// PlayerCtrl.cs
// Grounding check

//Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Used Headers for a more organized inspector


// Public Class
public class PlayerCtrl : MonoBehaviour 
{
    // Public Variables
        // Dead?, Grounded?, half grounded = platforms, bounce of enemy after kill, and player deaths
    public static bool died = false;
    public static bool grounded = false;
    public static bool halfGrounded = false;
    public static bool killBounce = false;
    public static int playerDeaths;

        // Double jump?, speed of move while jump, and add force of jump
    [Header("Movement")]
    public bool doubleJump = true;
	public float speed = 6.0f;
    public float jumpForce = 16.0f;

        // Gravity standard, and gravity for falling
    [Header("Physics")]
    public float normalGravity = 3.0f;
    public float fallGravity = 5.0f;

        // Animations for player
    [Header("Animations")]
    public GameObject idleAnimation;
    public GameObject moveAnimation;
    public GameObject jumpAnimation;

        // Fall Speeds
    [Header("Timer")]
    public float airTime = 0.5f;
    public float platformFallTime = 0.25f;

        // Lower limit of level, make line interaction with player collider
    [Header("Other")]
    public float deathZonePosY = -10.0f;
    public bool showDeathZoneLine = true;
    public GameObject deathZoneLine;
    public Collider2D playerCol2D;

    // Private Variables
        // Facings, jump timer for acurrences, respawning, rigibody of player, and position o fplayer
    private bool lookingRight = true;
    private bool isFalling = false;
    private float jumpTimer = 0.0f;
    private float fallTimer = 0.0f;
    private int jumpcounter = 0;
    private Rigidbody2D rb2d;
    private Scene thisScene;
    private Vector2 currentPos;



	void Start ()
    { 
        //Gets the loaded scene.
        thisScene = SceneManager.GetActiveScene();
        //Gets the Rigidbody2D of the player.
        rb2d = GetComponent<Rigidbody2D>();
        //Sets the JumpTimer to the airTime.
        jumpTimer = airTime;                           
        fallTimer = platformFallTime;
	}


    // Calls and updates each function for every frame
	void Update ()
	{
        RestartLevel();
        JumpControls();
        MoveControls();
        LookingInDirection();
        AnimationSwitch();
        DeathZone();
	}




    void LookingInDirection ()
    {
        //LookingRight makes char look right...
        //...(Remember your starting sprite has to look right for this).
        if (lookingRight)                               
        {                                              
            idleAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            moveAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            jumpAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
        }
        //Char looks in opposite direction. By changing the localScale...
        //...of the sprite to [-1.0f] it faces the other direction.
        else
        {                                              
            idleAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            moveAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            jumpAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
        }
    }

    void JumpControls ()
    {
        //Makes player bounce off a enemy if hit on top.
        if (killBounce)         
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            killBounce = false;
        }

        //Changes the player collider to trigger for a set...
        //...amount of time to fall through platforms.
        if (isFalling)         
        {                     
            fallTimer -= Time.deltaTime;
            playerCol2D.isTrigger = true;
        }
        else
        {
            playerCol2D.isTrigger = false;
            fallTimer = platformFallTime;
        }

        if (fallTimer <= 0)
        {
            fallTimer = 0;
            isFalling = false;
        }

        //Enables the player to jump down through a...
        //...platform if it is a half platform.
        if (Input.GetKey(KeyCode.S))   
        {                              
            if (halfGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isFalling = true;
                }
            }
        }
        //If the player is grounded and... 
        //...[Space] has been hit then jump.
        //Player can jump untile the jumpcounter is >= 1.
        else if (Input.GetKeyDown(KeyCode.Space) && jumpcounter < 1) 
        {                                                           
            jumpcounter++;                                          
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if (!doubleJump)
        {
            //Limits to a 1 jump.
            jumpcounter = 1;                           
        }

        if (grounded || halfGrounded)
        {
            //Limits to a 2 jumps.
            jumpcounter = 0;                           
        }
    }

    // All player Move Controls
    void MoveControls ()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            //Starts the idleAnimation.
            idleAnimation.SetActive(true);
            //Stops the moveAnimation.
            moveAnimation.SetActive(false);             
        }
        else
        {
            idleAnimation.SetActive(false);
            moveAnimation.SetActive(true);
        }

        //Stops player from moving when "S" is held pressed.
        if (!Input.GetKey(KeyCode.S))                    
        {
            // Player will still look in the direction of right or left
            if (Input.GetKey(KeyCode.D)) 
            {
                rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
                lookingRight = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
                lookingRight = false;
            }
        }
    }


    void AnimationSwitch ()
    {
        // player uses normal gravity on the ground
        if (grounded || halfGrounded)
        {
            jumpTimer = airTime;
            rb2d.gravityScale = normalGravity;
            jumpAnimation.SetActive(false);
        }
        else
        {
            //Counts down while not on the ground.
            jumpTimer -= Time.deltaTime;                   

            if (jumpTimer <= 0.0f)
            {
                //Sets the gravityScale to fallGravity for the fall.
                rb2d.gravityScale = fallGravity;
                //Sets jumpTimer back to airTime.
                jumpTimer = airTime;                      
            }

            // Sets Jump Animation
            idleAnimation.SetActive(false);
            moveAnimation.SetActive(false);
            jumpAnimation.SetActive(true);
        }
    }


    void DeathZone ()
    {
        if (showDeathZoneLine)
        {
            //Makes deathZoneLine visible.
            deathZoneLine.SetActive(true);
            //Sets the deathZoneLine to the set Y position.
            deathZoneLine.transform.position = new Vector3(currentPos.x, deathZonePosY, deathZoneLine.transform.position.z);
        }                                                 
        else
        {
            //Makes deathZoneLine invisible.
            deathZoneLine.SetActive(false);              
        }
    }

    void RestartLevel ()
    {
        currentPos = transform.position;

        //If the players Y position goes <= the death zone...
        //...then the level will restart.
        if (currentPos.y <= deathZonePosY)                                  
        {
            //Reload the scene (Ingame progress will be lost).
            SceneManager.LoadScene(thisScene.name, LoadSceneMode.Single);   
        }

        //Same as above...
        if (died)                                                           
        {
            //Reload the scene (Ingame progress will be lost).
            SceneManager.LoadScene(thisScene.name, LoadSceneMode.Single);
            died = false;
        }
    }
}



