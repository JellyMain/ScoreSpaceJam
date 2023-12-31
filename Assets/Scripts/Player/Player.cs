using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] Leaderboard leaderboard;
    [SerializeField] GameInput gameInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float roationSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 2f;

    public bool isDashing = false;
    public bool gotHit = false;
    private bool canDash = true;

    public static Player Instance;

    public int countCoin = 0;

    public int score = 0;

    private void Awake()
    {
        Instance = this;
        EventAgregator.playerAddCoin.AddListener(AddCoin);
    }

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


    IEnumerator HandleDash()
    {
        if (canDash)
        {
            SoundManager.Instance.PlayDashSound(transform.position);
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

        Vector2 direction = gameInput.GetMovementInput();


        rb.velocity = direction * moveSpeed;

        transform.up = Vector2.Lerp(transform.up, direction, roationSpeed * Time.deltaTime);
    }


    private bool isMoving()
    {
        return gameInput.GetMovementInput() != Vector2.zero;
    }

    public void AddCoin()
    {
        countCoin++;
        EventAgregator.updatePlayerUI.Invoke();
    }

    public void AddScore(int score)
    {
        this.score += score;
        EventAgregator.updatePlayerUI.Invoke();
    }


    public void IncreasePlayerSpeed(float percentage)
    {
        float speedToAdd = moveSpeed / 100 * percentage;
        moveSpeed += speedToAdd;
    }
}
