using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainShip
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader SceneLoader;

        private void Awake()
        {
            
        }
        // Start is called before the first frame update
        void Start()
        {
            SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.STARTMENU);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

