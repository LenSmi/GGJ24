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
            case KeyCode.A:
                playerInput = GameConstants.possibleActions[0];
                break;
            case KeyCode.B:
                playerInput = GameConstants.possibleActions[1];
                break;
            case KeyCode.C:
                playerInput = GameConstants.possibleActions[2];
                break;
            case KeyCode.D:
                playerInput = GameConstants.possibleActions[3];
                break;
            case KeyCode.E:
                playerInput = GameConstants.possibleActions[4];
                break;
            case KeyCode.F:
                playerInput = GameConstants.possibleActions[5];
                break;
            case KeyCode.G:
                playerInput = GameConstants.possibleActions[6];
                break;
            case KeyCode.H:
                playerInput = GameConstants.possibleActions[7];
                break;
            case KeyCode.I:
                playerInput = GameConstants.possibleActions[8];
                break;
            case KeyCode.J:
                playerInput = GameConstants.possibleActions[9];
                break;
            case KeyCode.K:
                playerInput = GameConstants.possibleActions[10];
                break;
            case KeyCode.L:
                playerInput = GameConstants.possibleActions[11];
                break;
            case KeyCode.M:
                playerInput = GameConstants.possibleActions[12];
                break;
            case KeyCode.N:
                playerInput = GameConstants.possibleActions[13];
                break;
            case KeyCode.O:
                playerInput = GameConstants.possibleActions[14];
                break;
            case KeyCode.P:
                playerInput = GameConstants.possibleActions[15];
                break;
            case KeyCode.Q:
                playerInput = GameConstants.possibleActions[16];
                break;
            case KeyCode.R:
                playerInput = GameConstants.possibleActions[17];
                break;
            case KeyCode.S:
                playerInput = GameConstants.possibleActions[18];
                break;
            case KeyCode.T:
                playerInput = GameConstants.possibleActions[19];
                break;
            case KeyCode.U:
                playerInput = GameConstants.possibleActions[20];
                break;
            case KeyCode.V:
                playerInput = GameConstants.possibleActions[21];
                break;
            case KeyCode.W:
                playerInput = GameConstants.possibleActions[22];
                break;
            case KeyCode.X:
                playerInput = GameConstants.possibleActions[23];
                break;
            case KeyCode.Y:
                playerInput = GameConstants.possibleActions[24];
                break;
            case KeyCode.Z:
                playerInput = GameConstants.possibleActions[25];
                break;
        }
    }

    public bool CheckInput()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
            {
                currentKey = key;
            }
        }

        if(currentKey != KeyCode.None)
        {
            return true;
        }
        else
        { 
        return false; 
        }
    }
}
