using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameInputActions gameInputActions;


    private void Awake()
    {
        gameInputActions = new GameInputActions();
        gameInputActions.Player.Enable();
    }
    //sadfasdf

    private void Update()
    {
        Debug.Log(GetMovementInput());
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = gameInputActions.Player.Move.ReadValue<Vector2>();

        return movementInput;
    }
}
