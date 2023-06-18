using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameInput gameInput;

    public IShoot currentShootingPattern;
    public Bullet currentBullets;

    private Vector2 aimDirection;

    public static PlayerShooting Instance { get; private set; }

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


    private void OnEnable()
    {
        gameInput.OnShoot += Shoot;
    }


    private void OnDisable()
    {
        gameInput.OnShoot -= Shoot;
    }


    private void Shoot()
    {
        currentShootingPattern.Shoot(aimDirection, currentBullets, this.transform.position);
    }

    private void UpdateAimDirection()
    {
        aimDirection = GetWorldMousePosition() - (Vector2)transform.position;
    }

    private Vector2 GetWorldMousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldMousePos;
    }

}
