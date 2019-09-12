using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeManager : MonoBehaviour
{
    public bool dothing;
    private PostProcessVolume pp;

    public float DesiredTimescale { get; private set; } = 1f;

    private float previousTimescale = 1f;

    private float progress = 0.0f;

    public void Start()
    {
        pp = GetComponent<PostProcessVolume>();
    }

    void Update()
    {
        if (progress < 1)
        {
            progress += 0.8f * Time.unscaledDeltaTime;
            
            SetTimescale(Mathf.Lerp(previousTimescale, DesiredTimescale, progress));
            pp.weight = Mathf.Lerp(1 - previousTimescale, 1 - DesiredTimescale, progress);
        }

    }

    public void SetDesiredTimescale(float timeScale)
    {
        progress = 0f;
        DesiredTimescale = timeScale;
        previousTimescale = Time.timeScale;
    }

    private void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
        
        var aSources = FindObjectsOfType<AudioSource>();
        foreach (var aSource in aSources)
        {
            if (!aSource.CompareTag("donotscale"))
            {
                aSource.pitch = Time.timeScale;
            }
        }
    }
}
