using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnInteract : MonoBehaviour
{
    private AudioSource aSource;
    [SerializeField] private AudioClip aClipHover;
    [SerializeField] private AudioClip aClipClick;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        aSource.clip = aClipHover;
        aSource.Play();
    }

    public void PlayClickSound()
    {
        aSource.clip = aClipClick;
        aSource.Play();
    }
}
