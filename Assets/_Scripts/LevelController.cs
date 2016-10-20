using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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

    // Use this for initialization
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

        this._isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._isOver)
        {
            if (_score > 0 && _lives > 0)
            {
                _score--;
            }

            else
            {
                _lives = 0;
                this._gameOverText1.SetActive(true);
                this._gameOverText2.SetActive(true);
                this._restartButton.SetActive(true);
                this._player.SetActive(false);
            }

            this._scoreText.GetComponent<Text>().text = "Score: " + _score;
            this._livesText.GetComponent<Text>().text = "Lives: " + _lives;
        }
    }

    public void RestartButton_onClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HitEnemy()
    {
        _lives--;
    }

    public virtual void ExitLevel()
    {
        this._isOver = true;
        _lives += 5;
        SceneManager.LoadScene(this._nextLevel);
    }
}
