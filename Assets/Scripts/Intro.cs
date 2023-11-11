using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Image black;

    public float fadeCount = 0.0f;
    private Color desiredalpha;

    // Start is called before the first frame update
    void Start()
    {
        desiredalpha = black.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Greybox");
        }
        fadeCount += 0.1f * Time.deltaTime;
        desiredalpha.a = fadeCount;
        black.color = desiredalpha;
        if (black.color.a >= 1f)
        {
            SceneManager.LoadScene("Greybox");
        }
    }
}
