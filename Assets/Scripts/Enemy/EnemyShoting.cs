using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    public IShoot currentShootingPattern;
    public Bullet currentBullets;

    private Vector2 aimDirection;

    public Gun gun;
    public GameObject startShot;
    public static EnemyShoting Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentShootingPattern = new Pistol();
    }

    private void Update()
    {
        UpdateAimDirection();
        Debug.Log(currentShootingPattern);
        Debug.Log(currentBullets);
    }

    public void Shoot()
    {
        currentShootingPattern.Shoot(aimDirection, currentBullets, gun);
    }

    private void UpdateAimDirection()
    {
        aimDirection = GetWorldPlayerPosition() - (Vector2)transform.position;
    }

    private Vector2 GetWorldPlayerPosition()
    {
        Vector2 playerPos = Player.Instance.transform.position;
        Vector2 worldPlayerPos = Camera.main.ScreenToWorldPoint(playerPos);
        return worldPlayerPos;
    }
}
