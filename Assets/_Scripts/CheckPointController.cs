// CheckPointController.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Controls check point behaviour with respect to the player and key (when present) game objects
// Revision History:
// Oct. 17: File creation
// Oct. 20: Added check for key
// Oct. 21: Added internal documentation
// Dec. 12: Removed check for key
// Dec. 13: Modified header

using UnityEngine;
using System.Collections;

// controls check point behaviour with respect to the player and key (when present) game objects
public class CheckPointController : MonoBehaviour
{
    // private instance variable
    private Transform _transform;
    private GameObject _spawnPoint;
    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        this._transform = GetComponent<Transform>();
        this._animator = GetComponent<Animator>();
        this._spawnPoint = GameObject.FindWithTag("Respawn");

        this._animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnPoint.GetComponent<Transform>().position != this._transform.position)
        {
            this._animator.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this._animator.enabled = true;
            _spawnPoint.GetComponent<Transform>().position = this._transform.position;
        }
    }
}
