using MainShip;
using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    private float guessTimer;
    private int correctActions;
    private float currentLaughs;
    private float timer;
    private int previousValue;
    private bool playerHasGivenInput;
    public event Action GameOverEvent;

    private void OnEnable()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        GameOverEvent += GameUIManager.SetGameOverUI;
        GameOverEvent += GameOverSequence;

        GameManager.difficulty = GameConstants.Difficulty.EASY;
        guessTimer = GameConstants.easyGuessTimerConst;
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
        currentLaughs = GameConstants.maxLaughFill;
        GameUIManager.fill.fillAmount = currentLaughs;
        GameUIManager.inputText.text = "Listen";
        GameManager.currentGameState = GameConstants.GameStates.Playing;
        correctActions = 0;
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
        StartCoroutine(ShowWantedAction(GameConstants.bigGameTextSize, guessTimer));

        Debug.Log("======GENERATING VALUES======");
        Debug.Log("Winning value is" + randomActionValue);

        return randomActionValue;

    }

    public void GameOverSequence()
    {
        Debug.Log("You Game Over");
        correctActions = 0;
        currentLaughs = GameConstants.maxLaughFill;
        GameUIManager.fill.fillAmount = currentLaughs;

        guessTimer = GameConstants.easyGuessTimerConst;

        GameManager.currentGameState = GameConstants.GameStates.GameOver;
        GameUIManager.inputTextTransform.eulerAngles = new Vector3(0, 0, 0);
        GameUIManager.timerText.text = GameConstants.easyGuessTimerConst.ToString();
        GameUIManager.inputText.text = GameConstants.StartText;
        GameUIManager.inputText.fontSize = GameConstants.dialogueTextSize;
        GameUIManager.timerText.text = guessTimer.ToString("Text");
        GameUIManager.inputText.color = Color.black;
    }

    void SetDifficulty(int currentCorrectAmount)
    {
  

        if (currentCorrectAmount >= GameConstants.mediumThreshold && GameManager.difficulty == GameConstants.Difficulty.EASY)
        {
            GameUIManager.inputTextTransform.eulerAngles = new Vector3(0, 0, 0);
            guessTimer = GameConstants.mediumGuessTimerConst;
            GameManager.difficulty = GameConstants.Difficulty.MEDIUM;
            StartCoroutine(DifficultyTransition(GameManager.difficulty, 2f));
        }
        else if (currentCorrectAmount >= GameConstants.hardThreshold && GameManager.difficulty == GameConstants.Difficulty.MEDIUM)
        {
            GameUIManager.inputTextTransform.eulerAngles = new Vector3(0, 0, 0);
            guessTimer = GameConstants.hardGuessTimerConst;
            GameManager.difficulty = GameConstants.Difficulty.HARD;
            StartCoroutine(DifficultyTransition(GameManager.difficulty, 2f));
        }
        else if (currentCorrectAmount >= GameConstants.masterThreshold && GameManager.difficulty == GameConstants.Difficulty.HARD)
        {
            GameUIManager.inputTextTransform.eulerAngles = new Vector3(0, 0, 0);
            guessTimer = GameConstants.masterGuessTimerConst;
            GameManager.difficulty = GameConstants.Difficulty.MEDIUM;
            StartCoroutine(DifficultyTransition(GameManager.difficulty, 2f));
        }

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

        while (currentLaughs > 0f)
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
                GameUIManager.inputText.fontSize = GameConstants.gameTextSize;
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
            float laughsGained = GameUIManager.fill.fillAmount + GameConstants.laughGainAmount;
            correctActions += 1;
            GameUIManager.inputText.color = Color.green;
            yield return StartCoroutine(GainHealth(0.3f, laughsGained));
        }
        else
        {

            Debug.Log("Your health is " + currentLaughs.ToString());
            StartCoroutine(ShowFailedAction(GameConstants.failedActionRotZ, GameConstants.rotSpeed));
            float laughsLost = GameUIManager.fill.fillAmount - GameConstants.laughLossAmount;
            GameUIManager.inputText.color = Color.red;
            yield return StartCoroutine(LoseHealth(0.3f, laughsLost));
        }

        SetDifficulty(correctActions);
        PlayerInputManager.currentKey = KeyCode.None;

    }

    IEnumerator LoseHealth(float duration,float target)
    {
        float elapsedTime = 0f;

        currentLaughs -= GameConstants.laughLossAmount;


        while (duration >= elapsedTime)
        {
            GameUIManager.fill.fillAmount = Mathf.Lerp(GameUIManager.fill.fillAmount, target , elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameUIManager.fill.fillAmount = target;

    }

    IEnumerator GainHealth(float duration, float target)
    {
        float elapsedTime = 0f;

        while (duration >= elapsedTime)
        {
            GameUIManager.fill.fillAmount = Mathf.Lerp(GameUIManager.fill.fillAmount, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameUIManager.fill.fillAmount = target;
        currentLaughs += GameConstants.laughGainAmount;
        currentLaughs = Mathf.Clamp(currentLaughs, 0, 1);
    }

    IEnumerator DifficultyTransition(GameConstants.Difficulty difficulty, float duration)
    {
        GameUIManager.inputText.color = Color.black;
        GameUIManager.inputText.text = $"Hoho let's see if you can keep up with my {difficulty} tricks!";
        GameUIManager.inputText.fontSize = GameConstants.dialogueTextSize;

        yield return new WaitForSeconds(duration);
    }

    IEnumerator ShowWantedAction(float target, float duration)
    {

        float elapsedTime = 0f;
        GameUIManager.inputTextTransform.eulerAngles = new Vector3(0, 0, 0);
        while (duration >= elapsedTime && !PlayerInputManager.CheckInput())
        {
            GameUIManager.inputText.fontSize = Mathf.Lerp(target,GameConstants.gameTextSize, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameUIManager.inputText.fontSize = GameConstants.gameTextSize;


    }

    IEnumerator ShowFailedAction(float target, float duration)
    {
        float elapsedTime = 0f;
        StopCoroutine("ShowWantedAction");

        while (duration >= elapsedTime || PlayerInputManager.CheckInput())
        {
            float newRotation = Mathf.LerpAngle(GameUIManager.inputTextTransform.rotation.z, target, elapsedTime / duration);
            GameUIManager.inputTextTransform.eulerAngles = new Vector3(GameUIManager.inputTextTransform.rotation.x, GameUIManager.inputTextTransform.rotation.y, newRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        GameUIManager.inputText.fontSize = GameConstants.gameTextSize;
    }

}
