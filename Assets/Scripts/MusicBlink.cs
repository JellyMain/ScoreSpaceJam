using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBlink : MonoBehaviour
{
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;

    public SpriteRenderer spriteRenderer;
    public Transform circleTransform; // The Transform of your circle
    public AudioSource audioSource;
    public float minScale = 15f; // minimum scale of the circle
    public float maxScale = 20f; // maximum scale of the circle
    public Color fromColor;
    public Color toColor;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness = Mathf.Max(clipLoudness, Mathf.Abs(sample));
            }

            float scale = Mathf.Lerp(minScale, maxScale, clipLoudness);
            circleTransform.localScale = new Vector3(scale, scale, scale);
            spriteRenderer.color = Color.Lerp(fromColor, toColor, clipLoudness);
        }
    }
}
