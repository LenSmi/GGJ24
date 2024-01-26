using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public static class GameConstants
    {
        public enum SceneTypes
        {
            MANAGER,
            STARTMENU,
            MAIN
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

