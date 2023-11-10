using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerLights : MonoBehaviour
{
    public float dimmingDuration = 30f; // Duration for the light to dim in seconds
    private Light[] lights;
    private Coroutine dimmingCoroutine;
    public float presetLightIntensity;
    public void TurnOnLights(Light[] lightsarray)
    {
        lights = lightsarray;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = presetLightIntensity;
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
                lights[i].intensity = Mathf.Lerp(presetLightIntensity, 0f, t);
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