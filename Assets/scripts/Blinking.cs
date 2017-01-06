using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Blinking : MonoBehaviour
{
    private bool isRunning;
    private Material m_Material;
    private Color startColor;
    private float curTime;
    private float blinkingSpeed = 8.0f; // count in sec

    void Start()
    {
        isRunning = false;
        
        m_Material = this.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (!isRunning)
            return;

        Color c = Color.Lerp(startColor, Color.white, curTime * blinkingSpeed);
        m_Material.color = c;
        curTime += Time.deltaTime;

        if (curTime * blinkingSpeed > 1.0f)
            curTime = 0.0f;
    }

    public void setRunning(bool v)
    {
        if (isRunning == v)
            return;

        isRunning = v;

        if (isRunning)
        {
            startColor = m_Material.color;
            curTime = 0.0f;
        }
    }
}