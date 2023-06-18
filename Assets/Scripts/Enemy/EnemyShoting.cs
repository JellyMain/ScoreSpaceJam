using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    public Bullet currentBullets;
    public Gun gun;
    private Vector2 aimDirection;
    public bool canShoot = false;


    private void Start()
    {
        StartCoroutine(Shooting());
    }


    private void Update()
    {
        UpdateAimDirection();
    }


    public void Shoot()
    {
        gun.shootingPattern.Shoot(aimDirection, currentBullets, gun, transform.position);
    }


    IEnumerator Shooting()
    {
        while (true)
        {
            if (canShoot)
            {
                Shoot();
                yield return new WaitForSeconds(gun.fireRate);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void UpdateAimDirection()
    {
        aimDirection = (GetWorldPlayerPosition() - (Vector2)transform.position).normalized;
    }

    private Vector2 GetWorldPlayerPosition()
    {
        if (Player.Instance != null)
        {
            Vector2 playerPos = Player.Instance.transform.position;
            return playerPos;
        }
        return Vector2.zero;
    }
}
