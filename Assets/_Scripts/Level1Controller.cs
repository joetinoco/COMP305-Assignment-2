// Level1Controller.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Keeps track of the game state for the first level, and the transition to the next scene
// Revision History:
// Oct. 17: File creation
// Oct. 18: Increased initial score
// Oct. 21: Further increased initial score, added internal documentation
// Dec. 13: Modified header

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
