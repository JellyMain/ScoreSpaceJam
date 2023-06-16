using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : Enemy , IMove, IDead
{
    [SerializeField] private float moveSpeed;

    public void Dead()
    {
        Destroy(gameObject, 1f);
    }

    public void Move()
    {
        _rigibody2D.velocity = Vector2.down * moveSpeed;
    }

    private void Start()
    {
        base.Start();
        SetInterfaces(this, this);
    }
}
