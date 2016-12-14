// LevelController.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Keeps track of the game state for the scene, and the transitions between scenes
// Revision History:
// Oct. 17: File creation
// Oct. 18: Added control for UI elements
// Oct. 19: Modified updating of UI elements
// Oct. 20: Added check for keys, added internal documentation
// Oct. 21: Added additional internal documentation
// Dec. 5: Added control for coin boxes
// Dec. 11: Added interaction with debug keys
// Dec. 12: Modified check/control for keys, added additional UI elements
// Dec. 13: Modified header

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

// keeps track of the game state for the scene, and the transitions between scenes
public class LevelController : MonoBehaviour
{
    // protected variables shared with subclasses
    // static variables will be preserved among subclasses
    static protected int _score;
    static protected int _lives;

    protected GameObject _scoreText, _livesText, _keysText, _gameOverText1, _gameOverText2;
    protected GameObject _restartButton, _menuButton;
    protected string _nextLevel;
    protected bool _isOver;

    protected GameObject _player;
    
    protected int _keys; // The keys the player collected
    protected int _keysNeeded; // The amount of keys the player needs to complete the level

    // public property
    public bool HasAllKeys
    {
        get
        {
            return _keys == _keysNeeded;
        }
    }

    // Use this for initialization (can be overriden by subclasses)
    protected virtual void Start()
    {
        this._scoreText = GameObject.Find("score");
        this._livesText = GameObject.Find("lives");
        this._keysText = GameObject.Find("keys");
        if (this._keysText != null && this._keysNeeded == 0) this._keysText.SetActive(false);

        this._gameOverText1 = GameObject.Find("txtGame1");
        this._gameOverText2 = GameObject.Find("txtGame2");
        this._restartButton = GameObject.Find("btnRestart");
        this._menuButton = GameObject.Find("btnMenu");
        this._gameOverText1.SetActive(false);
        this._gameOverText2.SetActive(false);
        this._restartButton.SetActive(false);
        this._menuButton.SetActive(false);

        this._player = GameObject.FindGameObjectWithTag("Player");
        this._player.SetActive(true);

        this._keys = 0;
        this._isOver = false;
    }

    // Update is called once per frame, when the game
    // has not been cleared
    void Update()
    {
        if (!this._isOver)
        {
            // score is dependent on time
            if (_lives > 0)
            {
                if (_score > 0)
                    _score--;
            }

            else
            {
                // if player ran out of lives, stop the avatar
                // and display the game over text and restart
                // button
                _lives = 0;
                this._gameOverText1.SetActive(true);
                this._gameOverText2.SetActive(true);
                this._restartButton.SetActive(true);
                this._menuButton.SetActive(true);
                this._player.SetActive(false);
            }

            this._scoreText.GetComponent<Text>().text = "Score: " + _score;
            this._livesText.GetComponent<Text>().text = "Lives: " + _lives;
            if (this._keysText != null) this._keysText.GetComponent<Text>().text = "Keys: " + _keys + "/" + _keysNeeded;
        }

        this._readDebugKeys();
    }

    // Read and process utility keys to help debugging the game.
    private void _readDebugKeys() {

        if (Input.GetKey("2")) {
            SceneManager.LoadScene("Level2");
        }

        if (Input.GetKey("3")) {
            SceneManager.LoadScene("Level3");
        }

        if (Input.GetKey("m")) {
            Camera camera = (Camera) FindObjectOfType(typeof(Camera));
            AudioSource bgSource = (AudioSource) camera.GetComponentInChildren(typeof(AudioSource));
            bgSource.Stop();
        }

    }

    // click handler for the restart button
    public void RestartButton_onClick()
    {
        SceneManager.LoadScene("Level1");
    }

    // click handler for the menu button
    public void MenuButton_onClick()
    {
        SceneManager.LoadScene("Menu");
    }

    // award points to player (when he hits boxes, etc)
    public void AwardPoints(int amount) {
        _score += amount;
    }

    // decrease lives if player hits an enemy
    public void HitEnemy()
    {
        _lives--;
    }

    // mark a key as caught
    public virtual void GetKey()
    {
        this._keys++;
    }

    // start the next level (can be overriden by subclasses)
    public virtual void ExitLevel()
    {
        this._isOver = true;
        _lives += 5;
        SceneManager.LoadScene(this._nextLevel);
    }
}
