using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    public Action OnDash;
    public Action OnShoot;
    private GameInputActions gameInputActions;
    public bool isShooting;


    private void Awake()
    {
        gameInputActions = new GameInputActions();
        gameInputActions.Player.Enable();
    }


    private void OnEnable()
    {
        gameInputActions.Player.Dash.performed += Dash;
        gameInputActions.Player.Shoot.started += ctx => isShooting = true;
        gameInputActions.Player.Shoot.canceled += ctx => isShooting = false;
    }


    private void OnDisable()
    {
        gameInputActions.Player.Dash.performed -= Dash;
        gameInputActions.Player.Shoot.started -= ctx => isShooting = true;
        gameInputActions.Player.Shoot.canceled -= ctx => isShooting = false;
    }


    private void Dash(InputAction.CallbackContext obj)
    {
        OnDash?.Invoke();
    }


    private void Shoot(InputAction.CallbackContext obj)
    {
        OnShoot?.Invoke();
    }


    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = gameInputActions.Player.Move.ReadValue<Vector2>();

        return movementInput;
    }
}
