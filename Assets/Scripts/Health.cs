using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string IS_HIT = "isHit";
    [SerializeField] ParticleSystem deadEffect;
    [SerializeField] Animator animator;
    public bool isPlayer;
    public float health;

    public void ReduceHealth(float damage)
    {
        health -= damage;
        animator.SetTrigger(IS_HIT);

        if (isPlayer)
        {
            CinemachineShake.Instance.ShakeCamera(15, 0.1f);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, Quaternion.identity);
        }

        if (isPlayer == true)
        {
            if (health<1)
            {
                EventAgregator.PlayerLoose.Invoke();
            }
        }
        if (TryGetComponent<Enemy>(out Enemy enemy))
        {
            Player.Instance.AddScore(enemy.score);
            enemy.EnemyDead();
        }
        EventAgregator.updatePlayerUI.Invoke();
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }
}
