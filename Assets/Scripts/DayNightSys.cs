using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSys : MonoBehaviour
{
    public Light directionalLight;

    public float dayDurationInSec = 24.0f; // this adjusts the duration of a full day in seconds
    public int curHour;
    float curTimeOfDay = 0.0f;

    public List<SkyboxTimeMapping> timeMapping;

    // Update is called once per frame
    void Update()
    {
        curTimeOfDay += Time.deltaTime / dayDurationInSec;
        curTimeOfDay %= 1;

        curHour = Mathf.FloorToInt(curTimeOfDay * 24);

        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((curTimeOfDay * 360) - 90, 170, 0));

        UpdateSkybox();
    }

    private void UpdateSkybox()
    {
        Material curSkybox = null;
        foreach(SkyboxTimeMapping mapping in timeMapping)
        {
            if(curHour == mapping.hour)
            {
                curSkybox = mapping.skyboxMaterial;
                break;
            }
        }

        if(curSkybox != null)
        {
            RenderSettings.skybox = curSkybox;
        }
    }
}

[System.Serializable]
public class SkyboxTimeMapping
{
    public string phaseName;
    public int hour; // hour of day (0-23)
    public Material skyboxMaterial; // the skybox material for the hour
}
