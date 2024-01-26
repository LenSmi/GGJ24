using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainShip
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneToWorld(GameConstants.SceneTypes sceneToLoad)
        {
            string _sceneName = sceneToLoad.ToString();
            Scene scene = SceneManager.GetSceneByName(_sceneName);

            if (IsSceneLoaded(scene))
            {
                Debug.LogWarning(_sceneName + " is already loaded!");
            }
            else
            {
                SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }

        }

        public void UnloadSceneFromWorld(GameConstants.SceneTypes sceneToUnload)
        {
            string _sceneName = sceneToUnload.ToString();
            Scene scene = SceneManager.GetSceneByName(_sceneName);
          

            if (IsSceneLoaded(scene))
            {
                SceneManager.UnloadSceneAsync(_sceneName, UnloadSceneOptions.None);
            }

        }

        bool IsSceneLoaded(Scene scene)
        {

            if (scene.isLoaded)
            {
                return true;

            }else{ 

                return false; 

            }
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.SetActiveScene(scene);
        }
    }
}