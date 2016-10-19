using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level3Controller : LevelController {

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
