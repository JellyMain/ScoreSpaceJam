using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "ScriptableObjects/Gun", order = 1)]
public class Gun : ScriptableObject
{
    public string gunName;
    public IShoot shootingPattern;
    public float fireRate;
    [Header("BurstMode")]
    public bool burstMode;
    public int bulletsPerBurst;
    public float timeBetweenBursts;
}

