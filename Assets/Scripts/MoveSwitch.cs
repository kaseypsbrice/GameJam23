using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    public Transform[] SwitchPositions;
    public GameObject LightSwitchOBJ;

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
}

/*
public class InitSwitch : MonoBehaviour
{
    public GameObject LightSwitchPrefab;
    public GameObject[] SwitchPositions;

    void InstantiateRandomSwitch()
    {
        if (SwitchPositions.Length > 0)
        {
            int RandomIndex = Random.Range(0, SwitchPositions.Length);
            Vector3 SpawnPosition = SwitchPositions[RandomIndex].transform.position;
            Quaternion SpawnRotation = SwitchPositions[RandomIndex].transform.rotation;

            Instantiate(LightSwitchPrefab, SpawnPosition, SpawnRotation);

            DimLights dimLightsComponent = LightSwitchPrefab.GetComponent<DimLights>();
            TriggerLights triggerLightsComponent = LightSwitchPrefab.GetComponent<TriggerLights>();
            if (dimLightsComponent == null)
                LightSwitchPrefab.AddComponent<DimLights>();
            if (triggerLightsComponent == null)
                LightSwitchPrefab.AddComponent<TriggerLights>();

            Debug.Log("Instantiated light switch based on random position.");
        }
        else
        {
            Debug.LogError("No switch positions defined.");
        }
    }

void Start()
{
    InstantiateRandomSwitch();
}
    // Calls the function on start.
}
*/