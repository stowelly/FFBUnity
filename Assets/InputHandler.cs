﻿using Fumbbl;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public Camera Camera;

    public float mouseSensitivity = 1.0f;
    private Vector3 lastPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            Camera.transform.position = new Vector3(0, 0, -10);
        }
        if (Input.GetMouseButtonDown(2))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            Camera.transform.Translate(-delta.x * mouseSensitivity, -delta.y * mouseSensitivity, 0);
            lastPosition = Input.mousePosition;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToSettingsScene();
        }
    }

    public void SwitchToSettingsScene()
    {
        MainHandler.Instance.SetScene(MainHandler.SceneType.SettingsScene);
    }
}
