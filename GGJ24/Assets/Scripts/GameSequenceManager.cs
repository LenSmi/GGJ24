using MainShip;
using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequenceManager : MonoBehaviour
{
    /// <summary>
    /// In this script we need to have: 
    /// 1. A sequence of actions that are outputted. 
    /// 2. Get an input from the player.
    /// 3. Check if the Input is correct or incorrect.
    /// 4. Continue if correct through action sequences.
    /// For this point we should decide whether we have a certain set of actions, ie 10 actions for Level 1 and 20 for Level 2.
    /// Or have continuous actions and just increase the pace and difficulty.
    /// 5. Count score for actions reacted too.
    /// 6. Game over for fail.
    /// 
    /// </summary>
    /// 

    private GameManager GameManager;
    public GameUIManager GameUIManager;
    public PlayerInputManager PlayerInputManager;
    private int currentActionIndex = 0;
    private string randomActionValue;
    public float guessTimer;
    public int lives = 3;
    private float timer;
    private int previousValue;
    private bool playerHasGivenInput;
    public event Action GameOverEvent;

    private void OnEnable()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.currentGameState == GameConstants.GameStates.Ready && Input.GetKeyDown(KeyCode.Space))
        {
            InitGame();
        }

        GameUIManager.timerText.text = timer.ToString("F2");
    }
    public void InitGame()
    {

        GameOverEvent += GameUIManager.SetGameOverUI;
        GameOverEvent += GameOverSequence;

        GameUIManager.inputText.text = "Listen";
        GameManager.currentGameState = GameConstants.GameStates.Playing;
        StartCoroutine(ActivateGameSequence());
    }

    public string GenerateGameValues()
    {
        int randomValue;
        
        do
        {
            randomValue = UnityEngine.Random.Range(0, GameConstants.possibleActions.Count);

        } while(randomValue == previousValue);

        previousValue = randomValue;

        randomActionValue = GameConstants.possibleActions[randomValue];

        GameUIManager.inputText.text = randomActionValue;

        Debug.Log("======GENERATING VALUES======");
        Debug.Log("Winning value is" + randomActionValue);

        return randomActionValue;

    }

    public void GameOverSequence()
    {
        Debug.Log("You Game Over");
    }

    /// <summary>
    /// 1. Start Timer
    /// 2. While time is not zero, wait for player input.
    /// 3. if player misses time zone, game over.
    /// 4. if player inputs in time, check if input is correct.
    /// 5. if player inputs incorrectly, game over
    /// 6. if they input correctly, generate to action and gradually decrease time.
    /// 7. Increase pace or have a newly generated set called level2?
    /// </summary>
    /// 

    IEnumerator ActivateGameSequence()
    {

        while (lives > 0)
        {
            yield return new WaitForSeconds(1.5f);

            GenerateGameValues();
            PlayerInputManager.playerInput = null;
            GameUIManager.inputText.color = Color.black;

            Debug.Log("Guess now!");
            yield return StartCoroutine(WaitForPlayerInput(guessTimer));
        }
        GameOverEvent?.Invoke();

    }

    IEnumerator WaitForPlayerInput(float timerLength)
    {
        timer = timerLength;
        playerHasGivenInput = false;

        while (timer > 0 && !playerHasGivenInput)
        {

            if (PlayerInputManager.CheckInput())
            {
                PlayerInputManager.HandleInput(PlayerInputManager.currentKey);
                GameUIManager.inputText.text = PlayerInputManager.playerInput;
                playerHasGivenInput = true;
            }

            //Convert timer to integer and show it in text
            timer -= Time.deltaTime;
            GameUIManager.timerText.text = timer.ToString("F2");
            yield return null;
        }

        Debug.Log("Your Input was " + PlayerInputManager.playerInput);

        if (PlayerInputManager.playerInput == randomActionValue)
        {
            Debug.Log("You win!");
            GameUIManager.inputText.color = Color.green;
        }
        else
        {
            Debug.Log("You Lose!");
            lives -= 1;
            GameUIManager.inputText.color = Color.red;
        }

        PlayerInputManager.currentKey = KeyCode.None;

    }
}
