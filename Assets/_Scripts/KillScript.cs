// COMP305 Assignment 2 - completed by Winnie Chung

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
