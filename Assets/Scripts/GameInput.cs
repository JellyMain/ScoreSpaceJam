using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public Action OnDash;
    private GameInputActions gameInputActions;


    private void Awake()
    {
        gameInputActions = new GameInputActions();
        gameInputActions.Player.Enable();
    }
    //sadfasdf

    private void OnEnable()
    {
        gameInputActions.Player.Dash.performed += Dash;
    }


    private void Dash(InputAction.CallbackContext obj)
    {
        OnDash?.Invoke();
    }


    private void Update()
    {
        // Debug.Log(GetMovementInput());
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = gameInputActions.Player.Move.ReadValue<Vector2>();

        return movementInput;
    }
}
