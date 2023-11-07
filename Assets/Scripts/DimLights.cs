using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DimLights : MonoBehaviour
{
    public TriggerLights trigger;
    public Transform lightGroup;
    private Light[] lights;

    private bool playerInZone = false;
    public bool isOn = false;

    void Start()
    {
        if (lightGroup == null)
        {
            GameObject addedLightGroup = GameObject.FindWithTag("Lights");
            if (addedLightGroup != null)
            {
                Debug.Log("Found light group object with tag: " + addedLightGroup.name);
                lightGroup = addedLightGroup.transform;
                lights = lightGroup.GetComponentsInChildren<Light>();
                Debug.Log("Number of lights found: " + lights.Length);
            }
            // There seems to be an issue with this but I don't know how to fix it
        }
        else
        {
            lights = lightGroup.GetComponentsInChildren<Light>();
        }
        trigger.SetLights(lights);
    }
    /* If the lightGroup isn't manually set in the inspector,
     * it'll search for the group of lights.
     * In this case, we're searching for the parent of the group
     * using tags. You only need to set the parent's tags, don't
     * worry about the children's.
     * It'll find all the children of the parent so that we end up
     * with an array of lights that will later be iterated through
     * in TriggerLights.
     */

    void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E) && lightGroup != null)
            {
                Debug.Log("Beginning to dim lights.");
                trigger.StartDimming();
            }
        }
    }
    /* If the player is within the zone of the light switch's
     * Box Collider and presses "E", the process for the lights
     * will begin.
     */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Within light switch zone.");
            playerInZone = true;
        }
    }
    // Checks when the player enters the zone.

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exiting light switch zone.");
            playerInZone = false;
        }
    }
    // Checks when the player exits the zone.
}
