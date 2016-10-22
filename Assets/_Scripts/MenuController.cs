// COMP305 Assignment 2 - completed by Winnie Chung

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// defines the click event for the start button on the menu scene
public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton_onClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
