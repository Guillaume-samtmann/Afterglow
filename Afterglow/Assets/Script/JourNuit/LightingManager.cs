using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Presets;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPresset Preset;
    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;
    public float daySpeed = 1f;
    public float nightSpeed = 5f;

    private void Update()
    {
        if (Preset == null) return;

        if (Application.isPlaying)
        {
            float speedMultiplier = IsDayTime(TimeOfDay) ? daySpeed : nightSpeed;

            TimeOfDay += Time.deltaTime * speedMultiplier;
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay / 24f);
        } else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        } 
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    private bool IsDayTime(float Time)
    {
        return Time >= 6f && Time < 18f;
    }
}
