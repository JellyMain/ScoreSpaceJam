using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy, IMove, IShot, IDead
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem deadEffect;

    private AIDestinationSetter _aIDestinationSetter;
    private AIPath _aIPath;
    private bool _canAttack;

    public float coldownAttack = 1f;
    private Coroutine _playerGetDamageCoroutine;
    public void Dead()
    {
        Instantiate(deadEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
    }

    public void Move()
    {
        if (Vector2.Distance(Player.Instance.transform.position, this.transform.position) >= endReachedDistance & _canAttack == false)
        {
            _aIPath.canMove = true;
        }
        else
        {
            EnemyShot();
            _canAttack = true;
            _aIPath.canMove = false;
        }
    }

    public void Shot()
    {
        EnemyShoting.Instance.Shoot();
    }

    private void Awake()
    {
        _aIDestinationSetter = GetComponent<AIDestinationSetter>();
        _aIPath = GetComponent<AIPath>();

        _aIPath.endReachedDistance = endReachedDistance;
        _aIPath.maxSpeed = moveSpeed;
    }

    void Start()
    {
        base.Start();
        SetInterfaces(this, this, this);
        _aIDestinationSetter.target = Player.Instance.transform;
    }
}
