using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Pack", menuName = "Create Sound Pack")]
public class SoundPackSO : ScriptableObject
{
    public AudioClip coinAddSound;//done
    public AudioClip[] enemyKillSounds;//done
    public AudioClip playerKillSound; //done
    public AudioClip[] enemyShootSounds;//done
    public AudioClip dashSound;//done
    public AudioClip powerUpSound;
}
