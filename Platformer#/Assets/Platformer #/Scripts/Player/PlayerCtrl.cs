using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour 
{
    public static bool died = false;
    public static bool grounded = false;
    public static bool halfGrounded = false;
    public static bool killBounce = false;

    [Header("Movement")]
    public bool doubleJump = true;
	public float speed = 6.0f;
    public float jumpForce = 16.0f;

    [Header("Physics")]
    public float normalGravity = 3.0f;
    public float fallGravity = 5.0f;

    [Header("Animations")]
    public GameObject idleAnimation;
    public GameObject moveAnimation;
    public GameObject jumpAnimation;

    [Header("Timer")]
    public float airTime = 0.5f;
    public float platformFallTime = 0.25f;

    [Header("Other")]
    public float deathZonePosY = -10.0f;
    public bool showDeathZoneLine = true;
    public GameObject deathZoneLine;
    public Collider2D playerCol2D;

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
        thisScene = SceneManager.GetActiveScene();      //Gets the loaded scene.
        rb2d = GetComponent<Rigidbody2D>();             //Gets the Rigidbody2D of the player.
        jumpTimer = airTime;                            //Sets the JumpTimer to the airTime.
        fallTimer = platformFallTime;
	}

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
        if (lookingRight)                               //LookingRight makes char look right...
        {                                               //...(Remember your starting sprite has to look right for this).
            idleAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            moveAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
            jumpAnimation.transform.localScale = new Vector2(1.0f, 1.0f);
        }
        else                                            //Char looks in opposite direction. By changing the localScale...
        {                                               //...of the sprite to [-1.0f] it faces the other direction.
            idleAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            moveAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
            jumpAnimation.transform.localScale = new Vector2(-1.0f, 1.0f);
        }
    }

    void JumpControls ()
    {
        if (killBounce)         //Makes player bounce off a enemy if hit on top.
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            killBounce = false;
        }

        if (isFalling)          //Changes the player collider to trigger for a set...
        {                       //...amount of time to fall through platforms.
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

        if (Input.GetKey(KeyCode.S))    //Enables the player to jump down through a...
        {                               //...platform if it is a half platform.
            if (halfGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isFalling = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpcounter < 1) //If the player is grounded and... 
        {                                                            //...[Space] has been hit then jump.
            jumpcounter++;                                           //Player can jump untile the jumpcounter is >= 1.
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        if (!doubleJump)
        {
            jumpcounter = 1;                            //Limits to a 1 jump.
        }

        if (grounded || halfGrounded)
        {
            jumpcounter = 0;                            //Limits to a 2 jumps.
        }
    }

    void MoveControls ()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            idleAnimation.SetActive(true);               //Starts the idleAnimation.
            moveAnimation.SetActive(false);              //Stops the moveAnimation.
        }
        else
        {
            idleAnimation.SetActive(false);
            moveAnimation.SetActive(true);
        }

        if (!Input.GetKey(KeyCode.S))                    //Stops player from moving when "S" is held pressed.
        {
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
        if (grounded || halfGrounded)
        {
            jumpTimer = airTime;
            rb2d.gravityScale = normalGravity;
            jumpAnimation.SetActive(false);
        }
        else
        {
            jumpTimer -= Time.deltaTime;                   //Counts down while not on the ground.

            if (jumpTimer <= 0.0f)
            {
                rb2d.gravityScale = fallGravity;           //Sets the gravityScale to fallGravity for the fall.
                jumpTimer = airTime;                       //Sets jumpTimer back to airTime.
            }

            idleAnimation.SetActive(false);
            moveAnimation.SetActive(false);
            jumpAnimation.SetActive(true);
        }
    }

    void DeathZone ()
    {
        if (showDeathZoneLine)
        {
            deathZoneLine.SetActive(true);                 //Makes deathZoneLine visible.
            deathZoneLine.transform.position = new Vector3(currentPos.x, deathZonePosY, deathZoneLine.transform.position.z);
        }                                                  //Sets the deathZoneLine to the set Y position.
        else
        {
            deathZoneLine.SetActive(false);                //Makes deathZoneLine invisible.
        }
    }

    void RestartLevel ()
    {
        currentPos = transform.position;

        if (currentPos.y <= deathZonePosY)                                  //If the players Y position goes <= the death zone...
        {                                                                   //...then the level will restart.
            SceneManager.LoadScene(thisScene.name, LoadSceneMode.Single);   //Reload the scene (Ingame progress will be lost).
        }

        if (died)                                                           //Same as above...
        {                                                                   //Reload the scene (Ingame progress will be lost).
            SceneManager.LoadScene(thisScene.name, LoadSceneMode.Single);
            died = false;
        }
    }
}



/*
-------------------------------------------------------------------------
#################################
######### By SchrippleA #########
#################################
*/