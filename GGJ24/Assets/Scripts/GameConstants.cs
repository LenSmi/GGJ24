using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public static class GameConstants
    {
        //For Lenny -> Remember to set to false when pushing to git.
        public const bool isDebug = true;

        public const string StartText = "Press Space to Start!";

        public const float gameTextSize = 1f;
        public const float dialogueTextSize = 0.6f;

        public const float maxLaughFill = 0.5f;
        public const float laughLossAmount = 0.2f;
        public const float laughGainAmount = 0.1f;

        public const float easyGuessTimerConst = 1f;
        public const float mediumGuessTimerConst = 0.7f;
        public const float hardGuessTimerConst = 0.5f;
        public const float masterGuessTimerConst = 0.25f;

        public const int mediumThreshold = 10;
        public const int hardThreshold = 20;
        public const int masterThreshold = 50;


        public enum SceneTypes
        {
            MANAGER,
            UI,
            MAIN,
            TESTSCENE
        }

        public enum GameStates
        {
            Menu,
            Paused,
            Ready,
            Playing,
            GameOver
        }

        public enum Difficulty
        {
            EASY,
            MEDIUM,
            HARD,
            MASTER
        }


       public static readonly List<string> possibleActions = new List<string> 
       {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
       };
    }
}

