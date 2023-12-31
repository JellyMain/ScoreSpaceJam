using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameInput gameInput;

    public Gun currentGun;
    public Bullet currentBullets;
    private float fireRateTimer = float.MaxValue;
    private Vector2 aimDirection;

    public static PlayerShooting Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Update()
    {
        fireRateTimer += Time.deltaTime;
        UpdateAimDirection();
        Shoot();
    }



    private void Shoot()
    {
        if (gameInput.isShooting && fireRateTimer >= currentGun.fireRate)
        {
            CinemachineShake.Instance.ShakeCamera(5, 0.1f);
            currentGun.shootingPattern.Shoot(aimDirection, currentBullets, currentGun, this.transform.position);
            fireRateTimer = 0;
        }
    }

    private void UpdateAimDirection()
    {
        aimDirection = (GetWorldMousePosition() - (Vector2)transform.position).normalized;
    }

    private Vector2 GetWorldMousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldMousePos;
    }

    public void SetNewGun(Gun newGun)
    {
        currentGun = newGun;
    }


    public void SetNewBullets(Bullet newBullets)
    {
        currentBullets = newBullets;
    }

    public void IncreaseDamage(float percentage)
    {
        float damageToAdd = currentBullets.damage / 100 * percentage;
        currentBullets.damage += damageToAdd;
    }

}
