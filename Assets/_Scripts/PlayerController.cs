// PlayerController.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Defines the avatar's interaction between other game objects
// Revision History:
// Oct. 17: File creation
// Oct. 19: Added controls for sound
// Oct. 20: Added interaction with keys
// Oct. 21: Added internal documentation
// Nov. 28: Added interaction with moving platforms
// Dec. 5: Added controls for sound
// Dec. 11: Added in-air movement
// Dec. 12: Removed logging
// Dec. 13: Modified header

using UnityEngine;
using System.Collections;
using System;

// controls player behaviour (movement, interaction with other game objects)
public class PlayerController : MonoBehaviour
{
    // private instance variables
    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private float _move;
    private float _jump;
    private Boolean _isFacingRight;
    private Boolean _isGrounded;
    private GameObject _camera;
    private GameObject _spawnPoint;
    private LevelController _controller;

    // public instance variables (for testing)
    public float Velocity = 20f;
    public float JumpForce = 350f;

    [Header("Sound Clips")]
    public AudioSource JumpSound;
    public AudioSource DeadSound;
    public AudioSource HurtSound;
    public AudioSource PickupSound;

    // Use this for initialization
    void Start()
    {
        this._Initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if input for movement is present
        this._move = Input.GetAxis("Horizontal");
        if (this._move > 0f)
        {
            this._animator.SetInteger("playerState", 1);
            this._move = 1;
            this._flip();
            this._isFacingRight = true;
        }
        else if (this._move < 0f)
        {
            this._animator.SetInteger("playerState", 1);
            this._move = -1;
            this._flip();
            this._isFacingRight = false;
        }
        else
        {
            this._animator.SetInteger("playerState", 0);
            this._move = 0;
        }
        
        // Jump checking
        if (this._isGrounded)
        {
            // check if input is present for jumping
            if (Input.GetAxis("Vertical") > 0)
            {
                this._jump = 1;
                JumpSound.Play();
            }
        }
        else
        {
            this._jump = 0;
            
            // Restrict horizontal velocity when in mid-air
            Vector2 currentVelocity = this._rigidBody.GetRelativePointVelocity(_camera.transform.position); 
            // Debug.Log(currentVelocity);
            if (this._move == 1) { // Moving right
                if (currentVelocity.x > (Velocity/4)) this._move = 0;
            } else { // Moving left
                if (currentVelocity.x < -(Velocity/4)) this._move = 0;
            }
        }


        this._rigidBody.AddForce(new Vector2(
            this._move * Velocity, 
            this._jump * JumpForce),
            ForceMode2D.Force
        );
        _camera.transform.position = new Vector3(this._transform.position.x , this._transform.position.y , -10f);
    }

    // private methods
    // this method initializes variables and objects when called
    private void _Initialize()
    {
        this._transform = GetComponent<Transform>();
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._animator = GetComponent<Animator>();
        this._camera = GameObject.FindWithTag("MainCamera");
        this._spawnPoint = GameObject.FindWithTag("Respawn");
        this._move = 0f;
        this._isFacingRight = true;
        this._isGrounded = false;

        this._controller = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
    }

    // this method flips the character's bitmap across the x-axis
    private void _flip()
    {
        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            this._transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("deathPlane"))
        {
            this._transform.position = _spawnPoint.GetComponent<Transform>().position;
            this._rigidBody.velocity = Vector2.zero;
            this._isGrounded = false;
            DeadSound.Play();

            this._controller.HitEnemy();

        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            this._transform.position = _spawnPoint.GetComponent<Transform>().position;
            this._rigidBody.velocity = Vector2.zero;
            this._isGrounded = false;
            HurtSound.Play();
            this._controller.HitEnemy();
        }
        else if (other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
            this._controller.GetKey();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform") || other.gameObject.CompareTag("box"))
        {
            if (other.transform.position.y < this._transform.position.y) {
                this._isGrounded = true;
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        this._animator.SetInteger("playerState", 2);
        this._isGrounded = false;
    }

    // Public methods
	// ==========================================	

	// This method is used by moving platforms
	// to displace the player together with them as they move
	public void Displace(Vector3 displacement) {
		this._transform.position += displacement;
	}

    public void PlayPickupSound() {
        PickupSound.Play();
    }
}
