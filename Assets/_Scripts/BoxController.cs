// BoxController.cs
// Created by: Jose Tinoco
// Last Modified: Dec. 13 by Winnie Chung
// Description: Defines interaction of the coin box game object with the player game object
// Revision History:
// Dec. 5: File creation
// Dec. 13: Added header

using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

	private LevelController _levelController;

	// Use this for initialization
	void Start () {
		_levelController = (LevelController) GameObject.FindObjectOfType(typeof(LevelController));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter2D(Collision2D other) {
		// Give points to player if he headbutts the box
		if (other.collider.gameObject.name.EndsWith("Head")) {
			_levelController.SendMessage("AwardPoints", 1000);
			other.gameObject.SendMessage("PlayPickupSound");
			Destroy(this.gameObject);
		}
	}
}
