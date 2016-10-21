using UnityEngine;
using System.Collections;
using System;

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

    // Use this for initialization
    void Start()
    {
        this._Initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this._isGrounded)
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

            // check if input is present for jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._jump = 1;
                JumpSound.Play();
            }

            this._rigidBody.AddForce(new Vector2(this._move * Velocity, this._jump * JumpForce), ForceMode2D.Force);
        }
        else
        {
            this._move = 0;
            this._jump = 0;
        }

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
        if (other.gameObject.CompareTag("platform"))
        {
            this._isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        this._animator.SetInteger("playerState", 2);
        this._isGrounded = false;
    }
}
