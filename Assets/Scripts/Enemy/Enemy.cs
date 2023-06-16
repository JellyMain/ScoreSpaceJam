using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public IMove move;
    public IShot shot;
    public IDead dead;
    public Action OnDead;
    public Action OnShot;

    public Rigidbody2D _rigibody2D;
    public SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        OnDead += SoundManager.Instance.PlaySomeSound;
    }

    private void OnDisable()
    {
        OnDead -= SoundManager.Instance.PlaySomeSound;
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    public void EnemyShot()
    {
        shot?.Shot();
    }

    public void EnemyMove()
    {
        move?.Move();
    }

    public void EnemyDead()
    {
        OnDead.Invoke();
        dead?.Dead();
    }

    public void SetInterfaces(IMove move, IDead dead)
    {
        this.move = move;
        this.dead = dead;
    }

    public void SetInterfaces(IMove move, IShot shot, IDead dead)
    {
        this.move = move;
        this.shot = shot;
        this.dead = dead;
    }
}
