using UnityEngine;
using UnityEngine.UI;

class Level1Controller : LevelController
{
    protected override void Start()
    {
        base.Start();

        _score = 10000;
        _lives = 10;

        this._nextLevel = "Level2";
    }
}
