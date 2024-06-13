using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Light directionalLight; // Directional Light

    // pdate the speed on color change
    public float colorChangeSpeed = 1.0f;

    void Update()
    {
        // change the color when time change and loop
        float r = Mathf.Sin(Time.time * colorChangeSpeed) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time * colorChangeSpeed + 2) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time * colorChangeSpeed + 4) * 0.5f + 0.5f;

        // light color
        directionalLight.color = new Color(r, g, b);
    }
}
