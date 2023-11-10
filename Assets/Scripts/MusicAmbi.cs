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
    //private AudioClip lastGrowl; // for single array code
    private AudioClip lastCloseGrowl;
    private AudioClip lastFarGrowl;
    public GameObject player;
    public GameObject monster;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        monster = GameObject.FindWithTag("Monster");
        start.Play();
        loop.PlayDelayed(start.clip.length);
        InvokeRepeating(nameof(PlayRandomGrowl), 10f, 15f);
        /* Plays a random growl sound after a 10 second
         * delay, then plays every 15 seconds.
         * This is just an example of how it works.
         */
    }
    void PlayRandomGrowl()
    {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, monster.transform.position);
        AudioClip randomGrowl;
        if (distanceFromPlayer < 10f)
        {
            Debug.Log("Distance from player: " + distanceFromPlayer);
            randomGrowl = GetRandomGrowl(closeGrowlSounds, lastCloseGrowl);
            lastCloseGrowl = randomGrowl;
        }
        else
        {
            Debug.Log("Distance from player: " + distanceFromPlayer);
            randomGrowl = GetRandomGrowl(farGrowlSounds, lastFarGrowl);
            lastFarGrowl = randomGrowl;
        }
        AudioSource growlAudioSource = gameObject.AddComponent<AudioSource>();
        growlAudioSource.clip = randomGrowl;
        growlAudioSource.Play();
        Destroy(growlAudioSource, randomGrowl.length);
        Debug.Log("Playing monster growl: " + randomGrowl.name);
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