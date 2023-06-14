using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;


    private void Update()
    {
        HandleMovement();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = gameInput.GetMovementInput() * moveSpeed;
    }
}
