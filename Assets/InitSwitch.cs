using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /* Takes an array of objects representing the position of the switches.
     * It then randomly chooses an index and gets the object's position 
     * and rotation. If the prefab doesn't have the the components required
     * to dim the lights, they'll be added after the prefab is instantiated.
     */

    void Start()
    {
        InstantiateRandomSwitch();
    }
    // Calls the function on start.
}