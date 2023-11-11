using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    public Transform first;
    private bool hasbeen;
    public Transform[] SwitchPositions;
    public GameObject LightSwitchOBJ;
    private Transform CurrentSwitchPosition;
    public Monster monster;

    void Start()
    {
        SetCurrentPosition();
    }
    private void SetCurrentPosition()
    {
        CurrentSwitchPosition = LightSwitchOBJ.transform;
    }
    private Transform GetRandomPosition()
    {
        int randomIndex = Random.Range(0, SwitchPositions.Length);
        return (SwitchPositions[randomIndex]);
    }
    public void RandomMoveSwitch()
    {
        if(hasbeen == true)
        {
            if (SwitchPositions.Length > 1)
            {
                Transform NewPosition = GetRandomPosition();
                while (NewPosition == CurrentSwitchPosition)
                {
                    NewPosition = GetRandomPosition();
                }
                LightSwitchOBJ.transform.SetPositionAndRotation(NewPosition.position, NewPosition.rotation);
                CurrentSwitchPosition = NewPosition;
                Debug.Log("Light has been moved to a random position.");
            }
            else
            {
                Debug.LogError("No switch positions defined.");
            }
        }
        else
        {
            Transform NewPosition= first;
            LightSwitchOBJ.transform.SetPositionAndRotation(NewPosition.position, NewPosition.rotation);
            CurrentSwitchPosition = NewPosition;
            Debug.Log("Light at first position");
            hasbeen = true;
            monster.enabled =  true;
        }

    }
}