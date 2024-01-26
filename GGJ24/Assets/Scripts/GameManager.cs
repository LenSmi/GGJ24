using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;

        private void Start()
        {
            SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.STARTMENU);
        }
    }
}

