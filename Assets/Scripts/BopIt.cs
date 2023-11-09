using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopIt : MonoBehaviour
{
    public Collider playercol;
    public GameObject bopitbed;
    public GameObject bopitplayer;
    public bool close;

    private void OnTriggerEnter(Collider playercol)
    {
        close = true;
    }
    private void OnTriggerExit(Collider playercol)
    {
        close = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && close == true)
        {
            bopitplayer.SetActive(true);
            bopitbed.SetActive(false);
        }
    }
}
