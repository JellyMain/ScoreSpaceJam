using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : Enemy , IMove, IDead
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem deadEffect;

    public void Dead()
    {
        Instantiate(deadEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyDead();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.TryGetComponent<Coin>(out Coin coin);
            coin.OnDestroy.Invoke();
        }
    }

    public void Move()
    {
        //_rigibody2D.velocity = Vector2.down * moveSpeed;
    }

    private void Start()
    {
        base.Start();
        SetInterfaces(this, this);
    }
}
