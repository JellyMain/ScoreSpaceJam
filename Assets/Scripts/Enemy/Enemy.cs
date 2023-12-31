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

    private Vector2 randomCoinPosition;

    public int score;

    public int meleeDamage;

    public float endReachedDistance;

    public List<GameObject> _coins = new List<GameObject>();

    public void Start()
    {

    }

    public void OnEnable()
    {
        OnDead += () => SoundManager.Instance.PlayEnemyKillSound(this.transform.position);
    }

    public void OnDisable()
    {
        OnDead -= () => SoundManager.Instance.PlayEnemyKillSound(this.transform.position);
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
        foreach (var coin in _coins)
        {
            randomCoinPosition = Camera.main.ScreenToWorldPoint(new Vector2(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height)));
            Instantiate(coin, randomCoinPosition, Quaternion.identity);
        }

        EventAgregator.WaveEnemyManager.Invoke(this);
        Player.Instance.AddScore(score);
        SoundManager.Instance.PlayEnemyKillSound(transform.position);

        OnDead?.Invoke();
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
