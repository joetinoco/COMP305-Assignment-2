// COMP305 Assignment 2 - completed by Winnie Chung

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

    protected GameObject _scoreText, _livesText, _gameOverText1, _gameOverText2;
    protected GameObject _restartButton;
    protected string _nextLevel;
    protected bool _isOver;

    protected GameObject _player;
    
    protected bool _hasKey;

    // public property
    public bool HasKey
    {
        get
        {
            return _hasKey;
        }
    }

    // Use this for initialization (can be overriden by subclasses)
    protected virtual void Start()
    {
        this._scoreText = GameObject.Find("score");
        this._livesText = GameObject.Find("lives");

        this._gameOverText1 = GameObject.Find("txtGame1");
        this._gameOverText2 = GameObject.Find("txtGame2");
        this._restartButton = GameObject.Find("btnRestart");
        this._gameOverText1.SetActive(false);
        this._gameOverText2.SetActive(false);
        this._restartButton.SetActive(false);

        this._player = GameObject.FindGameObjectWithTag("Player");
        this._player.SetActive(true);

        this._hasKey = false;
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
                this._player.SetActive(false);
            }

            this._scoreText.GetComponent<Text>().text = "Score: " + _score;
            this._livesText.GetComponent<Text>().text = "Lives: " + _lives;
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

    }

    // click handler for the restart button
    public void RestartButton_onClick()
    {
        SceneManager.LoadScene("Level1");
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

    // set hasKey flag to be true
    public virtual void GetKey()
    {
        this._hasKey = true;
    }

    // start the next level (can be overriden by subclasses)
    public virtual void ExitLevel()
    {
        this._isOver = true;
        _lives += 5;
        SceneManager.LoadScene(this._nextLevel);
    }
}
