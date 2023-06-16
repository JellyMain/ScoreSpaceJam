using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 2f;

    private bool isDashing = false;
    private bool canDash = true;


    private void OnEnable()
    {
        gameInput.OnDash += StartDash;
    }


    private void OnDisable()
    {
        gameInput.OnDash -= StartDash;
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }



    private void StartDash()
    {
        StartCoroutine(HandleDash());
    }
    //dfafasdf

    IEnumerator HandleDash()
    {
        if (canDash)
        {
            Debug.Log("is Dashing");
            canDash = false;
            isDashing = true;
            rb.velocity = gameInput.GetMovementInput() * dashSpeed;
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }

    }

    private void HandleMovement()
    {
        if (isDashing) return;
        rb.velocity = gameInput.GetMovementInput() * moveSpeed;
    }
}
