using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy, IMove, IShot, IDead
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float moveSpeed;

    public void Dead()
    {
        OnDead.Invoke();
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Shot()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SetInterfaces(this, this, this);
    }

    private void PlaySoundDead()
    {

    }

}
