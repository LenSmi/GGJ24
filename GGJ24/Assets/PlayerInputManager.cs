using MainShip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [HideInInspector]
    public string playerInput;
    [HideInInspector]
    public KeyCode currentKey;

    public void HandleInput(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                playerInput = GameConstants.possibleActions[0];
                break;
            case KeyCode.A:
                playerInput = GameConstants.possibleActions[1];
                break;
            case KeyCode.S:
                playerInput = GameConstants.possibleActions[2];
                break;
            case KeyCode.D:
                playerInput = GameConstants.possibleActions[3];
                break;
        }
    }

    public void CheckInput()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
            {
                currentKey = key;
            }
        }
    }
}
