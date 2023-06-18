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
  //  public static EnemyShoting Instance { get; private set; }

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        currentShootingPattern = new Pistol();
    }

    private void Update()
    {
        UpdateAimDirection();
    }

    public void Shoot()
    {
        currentShootingPattern.Shoot(aimDirection, currentBullets, gun, startShot.transform.position);
    }

    private void UpdateAimDirection()
    {
        aimDirection = (GetWorldPlayerPosition() - (Vector2)startShot.transform.position).normalized;
    }

    private Vector2 GetWorldPlayerPosition()
    {
        Debug.Log(Player.Instance.transform.position);
        Vector2 playerPos = Player.Instance.transform.position;
        Vector2 worldPlayerPos = Camera.main.ScreenToWorldPoint(playerPos);
        Debug.Log(worldPlayerPos + "worldPlayerPos");
        return worldPlayerPos;
    }
}
