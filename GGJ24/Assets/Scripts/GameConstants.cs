using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public static class GameConstants
    {
        //For Lenny -> Remember to set to false when pushing to git.
        public const bool isDebug = false;
        public enum SceneTypes
        {
            MANAGER,
            STARTMENU,
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
    }
}

