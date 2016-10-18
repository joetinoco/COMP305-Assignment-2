using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {
    // private instance variable
    private Transform _transform;
    private GameObject _spawnPoint;
    private Animator _animator;

    // public instance variable (for testing)

    // Use this for initialization
    void Start () {
        this._transform = GetComponent<Transform>();
        this._animator = GetComponent<Animator>();
        this._spawnPoint = GameObject.FindWithTag("Respawn");

        this._animator.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
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
