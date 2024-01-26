using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;
        public bool isDebug;

        private void Start()
        {
            SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.STARTMENU);
        }
    }
}

