using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private ParticleSystem deadEffect;
    public int health;

    public void ReduceHealth(int damage)
    {
        health -= damage;

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
        EventAgregator.updatePlayerUI.Invoke();
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}
