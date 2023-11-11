using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : MonoBehaviour
{
    public Collider player;

    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene("Death");
    }
}
