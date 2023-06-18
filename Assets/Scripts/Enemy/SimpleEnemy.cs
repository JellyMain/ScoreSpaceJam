using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy, IMove, IShot, IDead
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem deadEffect;

    private EnemyShoting _enemyShoting;
    private AIDestinationSetter _aIDestinationSetter;
    private AIPath _aIPath;
    private bool _canAttack;

    public float coldownAttack = 1f;
    private Coroutine _enemyStartShoting;
    private bool _isStartShoting = false;
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
            if (_enemyStartShoting != null)
            {
                _isStartShoting = false;
                StopCoroutine(_enemyStartShoting);
                _enemyStartShoting = null;
            }
        }
        else
        {
            //_aIPath.canMove = false;
            _canAttack = true;
            if (_isStartShoting == false)
            {
                _enemyStartShoting = StartCoroutine(ShotCoroutine());
            }
        }
    }

    public void Shot()
    {
        _enemyShoting.Shoot();
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
        SetInterfaces(this, this, this);
        _aIDestinationSetter.target = Player.Instance.transform;
    }

    private IEnumerator ShotCoroutine()
    {
        while (_canAttack == true)
        {
            _canAttack = false;
            _isStartShoting = true;
            EnemyShot();
            SoundManager.Instance.PlayEnemyShotEffect(this.transform.position);
            yield return new WaitForSeconds(coldownAttack);
        }
    }
}
