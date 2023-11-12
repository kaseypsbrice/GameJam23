using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HighScoreTracker : MonoBehaviour
{
    private float startTime;
    private float totalTime;
    public Monster monster;
    public void Start()
    {
        StartCoroutine(WaitForMonster());
    }
    private IEnumerator WaitForMonster()
    {
        while (monster == null || !monster.enabled)
        {
            yield return null;
        }
        Debug.Log("Monster enabled.");
        startTime = Time.time;
        while (true)
        {
            {
                SetScore();
            }
            yield return null;
        }
    }
    /* In the console, it'll just print out the highscore
     * constantly. That's all I've come up with for now.
     * It stops counting the highscore when the death
     * scene appears, so I don't know how to save the score once
     * before then, might have to edit the death transition script
     * or mess around with how this works.
     */
    public void SetScore()
    {
        totalTime = Time.time - startTime;
        Debug.Log("<color=blue>About to check highscore</color>");
        if (totalTime > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            Debug.Log("Setting new score");
            PlayerPrefs.SetFloat("HighScore", totalTime);
            PlayerPrefs.Save();
        }
        Debug.Log("HighScore: " + PlayerPrefs.GetFloat("HighScore", 0f));
    }
}