// Level2Controller.cs
// Created by: Winnie Chung
// Last Modified: Dec. 13 by Winnie Chung
// Description: Keeps track of the game state for the second level, and the transition to the next scene
// Revision History:
// Oct. 17: File creation
// Oct. 21: Added internal documentation
// Dec. 13: Modified header

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
