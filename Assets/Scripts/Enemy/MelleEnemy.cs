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



    public void Move()
    {
        if (Player.Instance == null) return;

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
        if (Player.Instance)
        {
            _aIDestinationSetter.target = Player.Instance.transform;
        }
    }


}
