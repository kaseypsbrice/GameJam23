using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DimLights : MonoBehaviour
{
    public MoveSwitch switchLocation;
    public TriggerLights trigger;
    public string lightsTag = "Dimmer";
    public Light[] lights;
    public Collider player;

    public bool playerInZone = false;
    public bool isOn = false;

    void Start()
    {
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag(lightsTag);

        if (lightObjects.Length > 0)
        {
            lights = new Light[lightObjects.Length];
            for (int i = 0; i < lightObjects.Length; i++)
            {
                lights[i] = lightObjects[i].GetComponent<Light>();
            }
            Debug.Log("Number of lights found with tag '" + lightsTag + "': " + lights.Length);
        }
        else
        {
            Debug.LogWarning("No lights found with tag '" + lightsTag + "'.");
        }
    }
    /* Creates an array of light objects that have been tagged
     * with "dimmer" and uses them to set the lights.
     */
    public void SwitchPress()
    {
        {
            Debug.Log("Beginning to dim lights.");
            trigger.TurnOnLights(lights);
            trigger.StartDimming();
            switchLocation.RandomMoveSwitch();
        }
    }
    void Update()
    {

    }
    /* If the player is within the zone of the light switch's
     * Box Collider and presses "E", the process for the lights
     * will begin.
     */

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("Within light switch zone.");
        playerInZone = true;
    }
    // Checks when the player enters the zone.

    private void OnTriggerExit(Collider player)
    {
        Debug.Log("Exiting light switch zone.");
        playerInZone = false;
    }
    // Checks when the player exits the zone.
}
