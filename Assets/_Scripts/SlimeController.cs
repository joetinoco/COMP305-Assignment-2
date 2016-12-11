﻿using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {


	// PRIVATE INSTANCE VARIABLES
	private Rigidbody2D _rigidbody;
	private Transform _transform;
	private bool _isGrounded = false;
	private bool _isGroundAhead = true;
	private bool _isPlayerDetected = false;


	// PUBLIC INSTANCE VARIABLES (FOR TESTING)
	public float Speed;
	public Transform SightStart;
	public Transform SightEnd;

	// Use this for initialization
	void Start () {
		this._rigidbody = GetComponent<Rigidbody2D> (); // create reference to object's rigidbody2d component
		this._transform = GetComponent<Transform>(); // create a reference to object's Transform component
	}
	
	// Update is called once per frame (Physics)
	void FixedUpdate () {
		// check if enemy is grounded
		if (this._isGrounded) {
			this._rigidbody.velocity = new Vector2 (-this._transform.localScale.x, 0) * this.Speed;

			// check if there is ground ahead
			this._isGroundAhead = Physics2D.Linecast (
				this.SightStart.position, 
				this.SightEnd.position, 
				1 << LayerMask.NameToLayer ("Solid"));

			// just for debugging purposes
			Debug.DrawLine (this.SightStart.position, this.SightEnd.position);

			// if there is no ground ahead then flip the enemy direction
			if (this._isGroundAhead == false) {
				this._flip ();
			}

		}
	}

	private void OnCollisionStay2D(Collision2D other) {
		if(other.gameObject.CompareTag("platform")) {
			this._isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.CompareTag("platform")) {
			this._isGrounded = false;
		}
	}

	/**
	 * This method flips the character's bitmap across the x-axis
	 */
	private void _flip () {
		if (this._transform.localScale.x == 1) {
			this._transform.localScale = new Vector2 (-1f, 1f);
		} else {
			this._transform.localScale = new Vector2 (1f, 1f);
		}
	}
}