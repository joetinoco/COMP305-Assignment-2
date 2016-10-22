// COMP305 Assignment 2 - completed by Winnie Chung

using UnityEngine;
using System.Collections;

// controls check point behaviour with respect to the player and key (when present) game objects
public class CheckPointController : MonoBehaviour
{
    // private instance variable
    private Transform _transform;
    private GameObject _spawnPoint;
    private Animator _animator;
    private GameObject _key;

    // Use this for initialization
    void Start()
    {
        this._transform = GetComponent<Transform>();
        this._animator = GetComponent<Animator>();
        this._spawnPoint = GameObject.FindWithTag("Respawn");
        this._key = GameObject.FindWithTag("key");

        this._animator.enabled = false;

        // hide key, if it exists
        if (this._key)
            this._key.SetActive(false);
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

            // show key, if it exists
            if (this._key)
                this._key.SetActive(true);
        }
    }
}
