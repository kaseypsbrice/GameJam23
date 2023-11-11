using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicAmbi : MonoBehaviour
{
    public AudioSource start;
    public AudioSource loop;
    //public AudioClip[] growlSounds; // for single array code
    public AudioClip[] closeGrowlSounds;
    public AudioClip[] farGrowlSounds;
    public AudioSource closeGrowl;
    public AudioSource farGrowl;
    public float monsterDistance;
    //private AudioClip lastGrowl; // for single array code
    private AudioClip lastCloseGrowl;
    private AudioClip lastFarGrowl;
    public GameObject player;
    public GameObject monster;
    public int minInterval = 10;
    public int maxInterval = 20;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        monster = GameObject.FindWithTag("Monster");
        start.Play();
        loop.PlayDelayed(start.clip.length);
        Invoke(nameof(PlayRandomGrowl), Random.Range(minInterval, maxInterval));
        /* Plays the growls at random intervals between min and max.
         */
    }
    void PlayRandomGrowl()
    {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, monster.transform.position);
        AudioClip randomGrowl;
        AudioSource growlAudioSource;
        if (distanceFromPlayer < monsterDistance)
        {
            Debug.Log("Distance from player: " + distanceFromPlayer);
            randomGrowl = GetRandomGrowl(closeGrowlSounds, lastCloseGrowl);
            lastCloseGrowl = randomGrowl;
            growlAudioSource = closeGrowl;
        }
        else
        {
            Debug.Log("Distance from player: " + distanceFromPlayer);
            randomGrowl = GetRandomGrowl(farGrowlSounds, lastFarGrowl);
            lastFarGrowl = randomGrowl;
            growlAudioSource = farGrowl;
        }

        growlAudioSource.clip = randomGrowl;
        growlAudioSource.Play();
        Debug.Log("Playing monster growl: " + randomGrowl.name);
        int nextInterval = Random.Range(minInterval, maxInterval + 1);
        Invoke(nameof(PlayRandomGrowl), nextInterval);
        Debug.Log($"Next growl scheduled in {nextInterval} seconds");
    }
    /* A different set of growl sounds will be played depending
     * on the monster's distance from the player.
     * It will play the selected growl sound then destroy the
     * AudioSource component.
     * This process will repeat because of the InvokeRepeating
     * call that's made in the void Start.
     */
    AudioClip GetRandomGrowl(AudioClip[] growlArray, AudioClip lastGrowl)
    {
        if (growlArray.Length > 0)
        {
            AudioClip randomGrowl;
            randomGrowl = growlArray[Random.Range(0, growlArray.Length)];
            while (randomGrowl == lastGrowl)
            {
                randomGrowl = growlArray[Random.Range(0, growlArray.Length)];
            }
            return (randomGrowl);
        }
        else
        {
            Debug.LogError("No growl sounds available.");
            return (null);
        }
    }
    /* Selects a random growl sound from an array
     * and checks whether it's the same as the previous
     * sound played before returning the AudioClip.
     */
}

/*
 * This function takes only one array of AudioClips.
    void PlayRandomGrowl()
    {
        if (growlSounds.Length > 1)
        {
            AudioClip randomGrowl = GetRandomGrowl();
            while (randomGrowl == lastGrowl)
            {
                randomGrowl = GetRandomGrowl();
            }
            AudioSource growlAudioSource = gameObject.AddComponent<AudioSource>();
            growlAudioSource.clip = randomGrowl;
            growlAudioSource.Play();
            Destroy(growlAudioSource, randomGrowl.length);
            lastGrowl = randomGrowl;
            Debug.Log("Playing monster growl: " + randomGrowl.name);
        }
        else
        {
            Debug.LogError("No growl sounds are available.");
        }
    }
    AudioClip GetRandomGrowl()
    {
        AudioClip randomGrowl = growlSounds[Random.Range(0, growlSounds.Length)];
        return (randomGrowl);
    }
*/