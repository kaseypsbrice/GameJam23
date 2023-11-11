using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTransition : MonoBehaviour
{
    public AudioSource cutscene;
    
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == ("Death"))
        {
            StartCoroutine(DeathWait(cutscene));
        }
    }
    public IEnumerator DeathWait(AudioSource cutscene)
    {
        yield return new WaitForSeconds(cutscene.clip.length);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main Menu");
    }
}
