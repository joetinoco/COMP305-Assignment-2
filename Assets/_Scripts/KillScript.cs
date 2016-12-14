// KillScript.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Keeps track of the game state for the third level, and the transition to the next scene
// Revision History:
// Oct. 17: File creation
// Oct. 21: Added internal documentation
// Dec. 13: Modified header

using UnityEngine;
using System.Collections;

// controls the crate's behaviour when they hit the death plane
public class KillScript : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("deathPlane"))
        {
            Destroy(this.gameObject);
        }
    }
}
