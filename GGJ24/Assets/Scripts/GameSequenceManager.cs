using MainShip;
using OpenCover.Framework.Model;
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

    private void OnEnable()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Show Start UI here

        if (GameManager.currentGameState == GameConstants.GameStates.Ready && Input.GetKeyDown(KeyCode.Space)) 
        {
            GameManager.currentGameState = GameConstants.GameStates.Playing;
        }
    }

    public void InitGame()
    {
        GameManager.currentGameState = GameConstants.GameStates.Playing;
    }

    public void GenerateRandomIndex()
    {

    }

    IEnumerator ActivateGameSequence()
    {
        /// <summary>
        /// 1. Start Timer
        /// 2. While time is not zero, wait for player input.
        /// 3. if player misses time zone, game over.
        /// 4. if player inputs in time, check if input is correct.
        /// 5. if player inputs incorrectly, game over
        /// 6. if they input correctly, generate to action and gradually decrease time.
        /// 7. Increase pace or have a newly generated set called level2?
        /// </summary>
        yield return null;
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return null;
    }
}
