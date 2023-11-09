using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySwitching : MonoBehaviour
{
    public DimLights lightscript;
    public string firstKey = "f";
    private string randomKey;
    public bool randomise;
    public AudioSource click;

    string[] keys;

    private void Start()
    {
        randomKey = firstKey;
        keys = new string[]
        {
            "q",
            "e",
            "r",
            "t",
            "y",
            "u",
            "i",
            "o",
            "p",
            "f",
            "g",
            "h",
            "j",
            "k",
            "l",
            "z",
            "x",
            "c",
            "v",
            "b",
            "n",
            "m"
        };
    }

    private void Update()
    {
        if (lightscript.playerInZone == true)
        {
            Press();
        }
    }

    void Press()
    {
        if (Input.GetKeyDown(randomKey) && lightscript.lights != null)
        {
            lightscript.SwitchPress();
            click.Play();
            if(randomise == true)
            {
                PickNewKey();
            }

        }
    }
    void PickNewKey()
    {
        randomKey = keys[Random.Range(0, keys.Length)];
        Debug.Log("New key is " + randomKey);
    }
}
