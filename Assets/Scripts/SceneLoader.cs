using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource click;

    public Collider monster;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        //if(SceneManager.Equals("")) check current scene, if death, start coroutine, wait for length of death cutscene clip then transition to main menu
    }

    private void OnCollisionEnter(Collision monster)
    {
        SceneManager.LoadScene("Death");
    }

    public void PlayGame()
    {
        click.Play();
        StartCoroutine(AudioWait(click));
        SceneManager.LoadScene("Greybox");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
