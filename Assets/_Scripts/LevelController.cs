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

    protected Text _scoreText, _livesText, _gameOverText1, _gameOverText2;
    protected Button _restartButton;
    protected string _nextLevel;

    // Use this for initialization
    protected virtual void Start () {
        this._scoreText = GameObject.Find("score").GetComponent<Text>();
        this._livesText = GameObject.Find("lives").GetComponent<Text>();

        //this._gameOverText1 = GameObject.Find("txtGame1").GetComponent<Text>();
        //this._gameOverText2 = GameObject.Find("txtGame2").GetComponent<Text>();
        //this._restartButton = GameObject.Find("btnRestart").GetComponent<Button>();
        //this._gameOverText1.enabled = false;
        //this._gameOverText2.enabled = false;
        //this._restartButton.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (_lives > 0)
        {
            _score--;
            this._scoreText.text = "Score: " + _score;
            this._livesText.text = "Lives: " + _lives;
        }

        else
        {
            _lives = 0;
            //this._gameOverText1.enabled = true;
            //this._gameOverText2.enabled = true;
            //this._restartButton.enabled = true;
        }
	}

    public virtual void RestartButton_onClick()
    {
        Start();
    }

    public void HitEnemy()
    {
        _lives--;
    }

    public virtual void ExitLevel()
    {
        _lives += 5;
        SceneManager.LoadScene(this._nextLevel);
    }
}
