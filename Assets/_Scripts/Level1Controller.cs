// COMP305 Assignment 2 - completed by Winnie Chung

using UnityEngine;
using UnityEngine.UI;

// keeps track of the game state for the first level, and the transition to the next scene
class Level1Controller : LevelController
{
    protected override void Start()
    {
        base.Start();

        _score = 15000;
        _lives = 10;

        this._nextLevel = "Level2";
    }
}
