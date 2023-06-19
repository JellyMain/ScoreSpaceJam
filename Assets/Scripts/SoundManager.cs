using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundPackSO soundPackSO;


    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    //plays needed sound
    private void PlaySound(AudioClip clip, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    //plays random sound from array
    private void PlaySound(AudioClip[] clipArray, Vector2 position, float volume)
    {
        AudioSource.PlayClipAtPoint(clipArray[Random.Range(0, clipArray.Length)], position, volume);
    }


    public void PlayAddCoinSounds(Vector2 transform)
    {
        PlaySound(soundPackSO.coinAddSound, transform, 1);
    }

    public void PlayEnemyKillSound(Vector2 transform)
    {
        PlaySound(soundPackSO.enemyKillSounds, transform, 1);
    }

    public void PlayPlayerKillSound(Vector2 transform)
    {
        PlaySound(soundPackSO.playerKillSound, transform, 1f);
    }


    public void PlayDashSound(Vector2 transform)
    {
        PlaySound(soundPackSO.dashSound, transform, 1f);
    }


    public void PlayPowerUpSound()
    {
        PlaySound(soundPackSO.powerUpSound, Camera.main.transform.position, 0.5f);
    }

    public void PlayerEnemyShootSound(Vector2 transform)
    {
        PlaySound(soundPackSO.enemyShootSounds, transform, 0.5f);
    }

}
