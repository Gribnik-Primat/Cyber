using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movie : MonoBehaviour {
    public MovieTexture texture;
    private bool isLoad = false;

    // Use this for initialization
    void Start()
    {
        texture.loop = false;
        texture.Play();
    }
    void OnGUI()
    {
        if (!isLoad)
        {
            if (texture.isPlaying) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            else
            {
                Application.LoadLevel(2);
                isLoad = true;
            }

        }
    }
}﻿

