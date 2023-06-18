using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy, IMove, IDead
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem deadEffect;

    private EnemyShoting _enemyShoting;
    private AIDestinationSetter _aIDestinationSetter;
    private AIPath _aIPath;
    private bool _canAttack;



    public void Dead()
    {
        Instantiate(deadEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }

    public void Move()
    {
        if (Player.Instance == null) return;

        if (Vector2.Distance(Player.Instance.transform.position, this.transform.position) >= endReachedDistance)
        {
            _aIPath.canMove = true;
            _enemyShoting.canShoot = false;
        }
        else
        {
            _enemyShoting.canShoot = true;

        }
    }


    private void Awake()
    {
        _aIDestinationSetter = GetComponent<AIDestinationSetter>();
        _aIPath = GetComponent<AIPath>();
        _enemyShoting = GetComponent<EnemyShoting>();

        _aIPath.endReachedDistance = endReachedDistance;
        _aIPath.maxSpeed = moveSpeed;
    }

    void Start()
    {
        base.Start();
        SetInterfaces(this, this);
        if (Player.Instance != null)
        {
            _aIDestinationSetter.target = Player.Instance.transform;
        }
    }

}
