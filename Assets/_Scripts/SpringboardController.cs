// SpringboardController.cs
// Created by: Jose Tinoco
// Last Modified: Dec. 13 by Winnie Chung
// Description: Defines the interaction between the player and springboard game objects
// Revision History:
// Dec. 11: File creation
// Dec. 12: Bug fixes
// Dec. 13: Added header

using UnityEngine;
using System.Collections;

public class SpringboardController : MonoBehaviour {
	public int springStrength = 700;
	public AudioSource SpringSound;
	private float cooloffTime = 0f;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cooloffTime > 0) {
			cooloffTime -= Time.deltaTime;
		}
		if (cooloffTime < 0) cooloffTime = 0;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (cooloffTime == 0) { // This prevents 'double springing' of the player if this collision is triggered twice.
			other.rigidbody.AddForce(
				new Vector2( other.relativeVelocity.x * -40f, springStrength ),
				ForceMode2D.Force);
			SpringSound.Play();
			cooloffTime = 0.5f;
		}
	}
}
