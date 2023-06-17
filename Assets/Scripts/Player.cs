using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float roationSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 2f;

    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;

    public bool isDashing = false;
    private bool canDash = true;

    public static Player Instance;

    public int countCoin = 0;

    public int score = 0;

    public int HP;

    public Action OnLoose;

    private void Awake()
    {
        Instance = this;
        EventAgregator.playerAddCoin.AddListener(AddCoin);

        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        gameInput.OnDash += StartDash;
        OnLoose += PlayerLoose;
    }


    private void OnDisable()
    {
        gameInput.OnDash -= StartDash;
        OnLoose -= PlayerLoose;
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

    public void UpdatePlayerHP(int amount)
    {
        if (HP > amount)
        {
            HP -= amount;
        }
        else
        {
            OnLoose?.Invoke();
        }

        EventAgregator.updatePlayerUI.Invoke();
    }

    private void PlayerLoose()
    {
        _spriteRenderer.color = Color.white;
        _boxCollider2D.enabled = false;
        Destroy(this.gameObject, 2f);
    }
}
