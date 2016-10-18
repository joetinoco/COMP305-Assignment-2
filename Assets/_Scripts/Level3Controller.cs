using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level3Controller : LevelController {

    private Text _gameClearText;

    protected override void Start()
    {
        base.Start();

        //this._gameClearText = GameObject.Find("txtGame3").GetComponent<Text>();
        //this._gameClearText.enabled = false;
    }

    public override void ExitLevel()
    {
        //this._gameOverText1.enabled = false;
        //this._gameClearText.enabled = false;
        //this._restartButton.enabled = false;
    }

    public override void RestartButton_onClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
