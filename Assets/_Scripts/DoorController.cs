using UnityEngine;
using System.Collections;

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
            if (this._isLocked && this._controller.HasKey)
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
