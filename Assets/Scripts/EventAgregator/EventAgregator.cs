using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAgregator
{
    public static UnityEvent playerAddCoin = new UnityEvent();
    public static UnityEvent updatePlayerUI = new UnityEvent();
    public static UnityEvent PlayerDestroyEnemy = new UnityEvent();
    public static UnityEvent<Enemy> WaveEnemyManager = new UnityEvent<Enemy>();
    public static UnityEvent PlayerWin = new UnityEvent();
    public static UnityEvent PlayerLoose = new UnityEvent();

}
