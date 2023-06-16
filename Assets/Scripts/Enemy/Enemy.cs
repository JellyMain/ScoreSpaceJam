using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public IMove move;
    public IShot shot;
    public IDead dead;

    protected Rigidbody2D _rigibody2D;
    protected SpriteRenderer _spriteRenderer;
    public void Start()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        dead?.Dead();
    }

    public void SetInterfaces(IMove move, IDead dead)
    {
        this.move = move;
        this.dead = dead;
    }

    public void SetInterfaces(IShot shot, IDead dead)
    {
        this.shot = shot;
        this.dead = dead;   
    }

    public void SetInterfaces(IMove move, IShot shot, IDead dead)
    {
        this.move = move;
        this.shot = shot;
        this.dead = dead;
    }
}
