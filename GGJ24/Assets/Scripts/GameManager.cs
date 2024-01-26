using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;
        public GameConstants.GameStates currentGameState;

        private void Start()
        {
            Init();
        }


        public void Init()
        {
            SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.STARTMENU);
        }
    }
}

