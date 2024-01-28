using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;
        public AudioManager audioManager;
        public GameConstants.GameStates currentGameState;
        public GameConstants.Difficulty difficulty;

        private void Start()
        {
            Init();
        }


        public void Init()
        {
            SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.UI);
        }
    }
}

