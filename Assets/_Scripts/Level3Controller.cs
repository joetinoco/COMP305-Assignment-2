using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level3Controller : LevelController {

    // private instance variables
    private GameObject _finish;

    protected override void Start()
    {
        base.Start();
        
        this._finish = GameObject.FindGameObjectWithTag("Finish");
        this._finish.SetActive(false);
    }

    public override void GetKey()
    {
        base.GetKey();
        this._finish.SetActive(true);
    }

    /* instead of starting a new level,
     * present the game clear text and
     * restart button */
    public override void ExitLevel()
    {
        this._isOver = true;

        this._gameOverText2.GetComponent<Text>().text = "Clear";

        this._gameOverText1.SetActive(true);
        this._gameOverText2.SetActive(true);
        this._restartButton.SetActive(true);
        this._player.SetActive(false);
    }
}
