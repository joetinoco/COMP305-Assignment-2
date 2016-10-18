using UnityEngine;
using UnityEngine.UI;

class Level2Controller : LevelController
{
    protected override void Start()
    {
        base.Start();

        this._nextLevel = "Level3";
    }
}
