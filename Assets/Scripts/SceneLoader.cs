using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource click;

    public void PlayGame()
    {
        click.Play();
        StartCoroutine(AudioWait(click));
        SceneManager.LoadScene("Greybox");
        
    }

    public void QuitGame()
    {
        click.Play();
        StartCoroutine(AudioWait(click));
        Application.Quit();
    }

    public IEnumerator AudioWait(AudioSource click)
    {
        yield return new WaitForSeconds(click.clip.length);
    }
}
