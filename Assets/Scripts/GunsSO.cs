using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "ScriptableObjects/Gun", order = 1)]
public class Gun : ScriptableObject
{
    public string gunName;
    public IShoot shootingPattern;
    public float fireRate;
    public int bulletsPerShot;
    [Range(0, 1)] public float gunAccuracy;
    public float spreadAngle;
}

