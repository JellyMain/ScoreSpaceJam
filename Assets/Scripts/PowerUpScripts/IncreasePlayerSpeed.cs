using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreasePlayerSpeedPowerUp", menuName = "PowerUps/IncreasePlayerSpeedPowerUp")]
public class IncreasePlayerSpeed : PowerUps
{
    public float percentage;

    public override void Activate()
    {
        Player.Instance.IncreasePlayerSpeed(percentage);
    }

}
