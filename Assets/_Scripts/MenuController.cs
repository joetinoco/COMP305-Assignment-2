// MenuController.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Defines the click event for the start button on the menu scene
// Revision History:
// Oct. 20: File creation
// Oct. 21: Added internal documentation
// Dec. 12: Added click handler for the instructions button
// Dec. 13: Added header

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

    public void InstructionsButton_onClick()
    {
        SceneManager.LoadScene("Instructions");
    }
}
