using MainShip;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    public SceneLoader SceneLoader;
    public GameObject StartMenu;
    public CanvasGroup startMenuCanvas;
    public float fadeInDuration = 1.0f;

    public event Action FadeInFinished;

    private void OnEnable()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void StartGame()
    {
        SceneLoader.LoadSceneToWorld(GameConstants.SceneTypes.MAIN);
        StartCoroutine(FadeIn(startMenuCanvas,0f));
        FadeInFinished += UnloadUIScene;
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


    void UnloadUIScene()
    {
        SceneLoader.UnloadSceneFromWorld(GameConstants.SceneTypes.STARTMENU);
    }

}
