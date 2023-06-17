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
            //collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet);
            //UpdateEnemyHP(bullet.strength);
            // To do for bullet
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.TryGetComponent<Coin>(out Coin coin);
            coin.OnDestroy.Invoke();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.UpdatePlayerHP(strength);
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

    public void UpdateEnemyHP(int amount)
    {
        if (HP > amount)
        {
            HP -= amount;
        }
        else
        {
            EnemyDead();
        }

        EventAgregator.updatePlayerUI.Invoke();
    }
}
