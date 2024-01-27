using MainShip;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    private GameManager GameManager;
    public GameObject GameUI;
    public GameObject GameOverUI;
    public TextMeshPro inputText;
    public TextMeshProUGUI timerText;
    public Image fill;

    private void OnEnable()
    {
        GameManager = FindObjectOfType<GameManager>();
        fill.fillAmount = GameConstants.maxLaughFill;
    }
    public void SetGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    public void RestartGame() 
    {
        GameOverUI.SetActive(false);
        GameManager.currentGameState = GameConstants.GameStates.Ready;
        
    }
}
