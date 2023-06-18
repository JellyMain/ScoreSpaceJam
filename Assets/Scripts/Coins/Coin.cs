using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    public Action OnDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddCoin();
        }
        if (collision.CompareTag("Bullet"))
        {
            DestroyCoin();
        }
    }

    private void OnEnable()
    {
        OnDestroy += DestroyCoin;
    }

    private void OnDisable()
    {
        OnDestroy -= DestroyCoin;
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();

    }

    private void AddCoin()
    {
        SoundManager.Instance.PlayAddCoinSounds(this.transform.position);
        EventAgregator.playerAddCoin.Invoke();
        OnDestroy.Invoke();
    }

    private void DestroyCoin()
    {
        _spriteRenderer.color = new Color(0, 0, 0);
        _circleCollider2D.enabled = false;
        Instantiate(_destroyEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject, 2f);
    }
}
