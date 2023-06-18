using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : Enemy, IMove, IDead
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem deadEffect;
    private AIDestinationSetter _aIDestinationSetter;
    private AIPath _aIPath;
    private bool _isPlayerGetDamage;

    public float coldownAttack = 1f;
    private Coroutine _playerGetDamageCoroutine;
    public void Dead()
    {
        Instantiate(deadEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.TryGetComponent<Coin>(out Coin coin);
            coin.OnDestroy.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet);
            UpdateEnemyHP(bullet.damage);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (_isPlayerGetDamage == false)
            {
                _playerGetDamageCoroutine = StartCoroutine(PlayerGetDamage());
            }
        }
    }

    public void Move()
    {
        if (Vector2.Distance(Player.Instance.transform.position, this.transform.position) >= endReachedDistance & _isPlayerGetDamage == false)
        {
            _aIPath.canMove = true;
        }
        else
        {
            _aIPath.canMove = false;
        }
    }

    private void Awake()
    {
        _aIDestinationSetter = GetComponent<AIDestinationSetter>();
        _aIPath = GetComponent<AIPath>();

        _aIPath.endReachedDistance = endReachedDistance;
        _aIPath.maxSpeed = moveSpeed;
    }

    private void Start()
    {
        base.Start();
        SetInterfaces(this, this);
        _aIDestinationSetter.target = Player.Instance.transform;
    }

    private IEnumerator PlayerGetDamage()
    {
        _isPlayerGetDamage = true;
        Player.Instance.UpdatePlayerHP(strength);
        yield return new WaitForSeconds(coldownAttack);
        _isPlayerGetDamage = false;
        StopCoroutine(_playerGetDamageCoroutine);
    }
}
