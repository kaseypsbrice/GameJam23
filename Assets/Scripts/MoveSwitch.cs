using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class MoveSwitch : MonoBehaviour
{
    public Transform first;
    private bool pressedFirst;
    private bool pressedSecond;
    public Transform[] SwitchPositions;
    public GameObject LightSwitchOBJ;
    private Transform CurrentSwitchPosition;
    public Monster monster;
    public TMP_Text prompt;
    public bool textTexted = false;



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
        if(pressedFirst == true)
        {
            if (pressedSecond == false && textTexted == false)
            {
                prompt.SetText("Press F?");
                pressedSecond = true;
            }
            if (pressedSecond == true && textTexted == false)
            {
                prompt.SetText("Press ???");
                textTexted = true;
            }

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
            pressedFirst = true;
            monster.enabled =  true;
            prompt.SetText("Press F?");
        }

    }
}