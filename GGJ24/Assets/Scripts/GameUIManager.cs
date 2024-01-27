using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject GameOverUI;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameOverUI()
    {
        GameOverUI.SetActive(true);
    }
}
