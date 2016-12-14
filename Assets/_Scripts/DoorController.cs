// DoorController.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Controls the exit's interaction with the player game object
// Revision History:
// Oct. 17: File creation
// Oct. 20: Added check for lock, added interaction with player's avatar
// Oct. 21: Added internal documentation
// Dec. 13: Modified header

using UnityEngine;
using System.Collections;

// controls the exit's interaction with the player game object
public class DoorController : MonoBehaviour {

    // private instance variable
    private LevelController _controller;

    // public instance variable
    public bool _isLocked;

	// Use this for initialization
	void Start () {
        this._controller = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // start the next level when player reaches the exit
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            if (this._isLocked && this._controller.HasAllKeys)
            {
                // 'unlock' door
                Destroy(this.gameObject);
            }

            else if (!this._isLocked)
            {
                this._controller.ExitLevel();
            }
        }
    }
}
