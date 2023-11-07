using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerLights : MonoBehaviour
{
    public float dimmingDuration = 30f; // Duration for the light to dim in seconds
    private Light[] lights;
    private float[] initialIntensities;
    private Coroutine dimmingCoroutine;
    public void SetLights(Light[] lightsarray)
    {
        lights = lightsarray;
        initialIntensities = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            initialIntensities[i] = lights[i].intensity;
        }
    }
    public void StartDimming()
    {
        if (dimmingCoroutine != null)
        {
            StopCoroutine(dimmingCoroutine);
        }
        dimmingCoroutine = StartCoroutine(DimLights());
    }
    IEnumerator DimLights()
    {
        float elapsedTime = 0f;

        while (elapsedTime < dimmingDuration)
        {
            // Calculate the new intensity for the light based on the current time and duration
            float t = elapsedTime / dimmingDuration;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = Mathf.Lerp(initialIntensities[i], 0f, t);
            }
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = 0f;
        }
    }
}

/*
 * Affects every light within a group.
 * Turns lights on and off.
public class ToggleLights : MonoBehaviour
{
    public Transform lightsGroup;
    private Light[] lights;

    void Start()
    {
        lights = lightsGroup.GetComponentsInChildren<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lightsGroup != null)
        {
            foreach (Light light in lights)
            {
                if (light != null)
                {
                    light.enabled = !light.enabled;
                }
                else
                    Debug.LogError("Null light component found within the group.");
            }
        }
    }
}
*/

/*
 * Affects a single light object.
 * Turns lights on and off.
public class ToggleLight : MonoBehaviour
{
    public GameObject lightObject;
    private Light lightComponent;

    void Start()
    {
        lightComponent = lightObject.GetComponent<Light>();

        if (lightComponent == null)
        {
            Debug.LogError("Light component not found on the specified lightObject.");
        }
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the light
            if (lightComponent != null)
            {
                lightComponent.enabled = !lightComponent.enabled;
            }
        }
    }
}
*/