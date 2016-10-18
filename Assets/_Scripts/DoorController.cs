using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    private LevelController _controller;

	// Use this for initialization
	void Start () {
        this._controller = GameObject.FindWithTag("GameController").GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this._controller.ExitLevel();
        }
    }
}
