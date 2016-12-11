// COMP305 Assignment 2 - completed by Winnie Chung

using UnityEngine;
using UnityEngine.UI;

// keeps track of the game state for the second level, and the transition to the next scene
class Level2Controller : LevelController
{
    protected override void Start()
    {
        base.Start();

        this._nextLevel = "Level3";
    }
}
