using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : ScriptableObject
{
    public string powerUpName;
    public string description;
    public abstract void Activate();
}
