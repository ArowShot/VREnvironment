using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeRandomizer : MonoBehaviour
{
    private Vector2 _dir;
    private AudioSource audsrc;

    void Start()
    {
        audsrc = GetComponent<AudioSource>();

        var a = Random.value * Mathf.PI * 2f;
        _dir = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }

    void Update()
    {
        var v = _dir * Time.time / 10f;
        float turb = Mathf.PerlinNoise(v.x, v.y);

        audsrc.volume = (turb - 0.3f) / 1.5f;
    }

}
