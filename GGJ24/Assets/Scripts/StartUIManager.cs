using MainShip;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{   
    private GameManager GameManager;
    private SceneLoader SceneLoader;
    public GameObject StartMenu;
    public CanvasGroup startMenuCanvas;
    public float fadeInDuration = 1.0f;

    public event Action FadeInFinished;

    private void OnEnable()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
        GameManager = FindObjectOfType<GameManager>();
        GameManager.currentGameState = GameConstants.GameStates.Menu;
    }

    public void StartGame()
    {
        GameConstants.SceneTypes sceneType = GameConstants.SceneTypes.MAIN;
#if UNITY_EDITOR
        if (GameConstants.isDebug) 
        {
            sceneType = GameConstants.SceneTypes.MAIN;
        }
#endif
        SceneLoader.LoadSceneToWorld(sceneType);
        StartCoroutine(FadeIn(startMenuCanvas,0f));
        FadeInFinished += UnloadStartMenu;
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup, float targetAlpha)
    {
        float elapsedTime = 0f;
        float initialAlpha = canvasGroup.alpha;

        while (fadeInDuration >= elapsedTime)
        {
            canvasGroup.alpha = Mathf.Lerp(initialAlpha, targetAlpha, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        FadeInFinished?.Invoke();
    }


    void UnloadStartMenu()
    {
        StartMenu.SetActive(false);
        GameManager.currentGameState = GameConstants.GameStates.Ready;
    }

}
