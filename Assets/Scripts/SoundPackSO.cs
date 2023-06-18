using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Pack", menuName = "Create Sound Pack")]
public class SoundPackSO : ScriptableObject
{
    public AudioClip exampleSound;
    public AudioClip explosionSound;
    public AudioClip coinAddSound;
    public AudioClip coinDestroySound;
    public AudioClip enemyDestroySound;
    public AudioClip enemyShootSound;
    public AudioClip bulletDestroySound;
}
