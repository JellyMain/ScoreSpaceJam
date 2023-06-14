using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundPackSO soundPackSO;


    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
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


    //example of playing sound
    public void PlaySomeSound()
    {
        PlaySound(soundPackSO.exampleSound, new Vector2(0, 0), 1);
    }
}
