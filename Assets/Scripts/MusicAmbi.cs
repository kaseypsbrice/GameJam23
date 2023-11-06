using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAmbi : MonoBehaviour
{
    public AudioSource start;
    public AudioSource loop;

    void Start()
    {
        start.Play();
        loop.PlayDelayed(start.clip.length);
    }
}