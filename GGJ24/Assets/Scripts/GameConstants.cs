using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public static class GameConstants
    {
        //For Lenny -> Remember to set to false when pushing to git.
        public const bool isDebug = true;

        public const string StartText = "Make me laugh...<br>Space to start...";

        public const float easyTempo = 1.0f;
        public const float mediumTempo = 1.1f;
        public const float hardTempo = 1.2f;
        public const float masterTemp = 1.3f;


        public const float bigGameTextSize = 6f;
        public const float gameTextSize = 3f;
        public const float dialogueTextSize = 1.2f;

        public const float startFadeInDuration = 0.1f;

        public const float failedActionRotZ = 90f;
        public const float rotSpeed = 0.15f;

        public const float maxLaughFill = 0.5f;
        public const float laughLossAmount = 0.2f;
        public const float laughGainAmount = 0.1f;

        public const float easyGuessTimerConst = 1f;
        public const float mediumGuessTimerConst = 0.7f;
        public const float hardGuessTimerConst = 0.5f;
        public const float masterGuessTimerConst = 0.25f;

        public const int mediumThreshold = 7;
        public const int hardThreshold = 18;
        public const int masterThreshold = 30;

        public const string incorrectAnswerTrigger = "Incorrect";
        public const string correctAnswerTrigger = "Correct";
        public const string idleTrigger = "Idle";
        public const string deathTrigger = "Death";

        public const float happyThreshold = 0.8f;
        public const float smilingThreshold = 0.6f;
        public const float neutralThreshold = 0.5f;
        public const float sadThreshold = 0.4f;
        public const float angryThreshold = 0.2f;



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

