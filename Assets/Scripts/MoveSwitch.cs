using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    public Transform[] SwitchPositions;
    public GameObject LightSwitchOBJ;
    private Transform CurrentSwitchPosition;

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
}

/*
public void RandomMoveSwitch()
{
    if (SwitchPositions.Length > 0)
    {
        int randomIndex = Random.Range(0, SwitchPositions.Length);
        Transform newPosition = SwitchPositions[randomIndex];

        LightSwitchOBJ.transform.position = newPosition.position;
        LightSwitchOBJ.transform.rotation = newPosition.rotation;

        Debug.Log("Light has been moved to a random position.");
    }
    else
    {
        Debug.LogError("No switch positions defined.");
    }
}
*/