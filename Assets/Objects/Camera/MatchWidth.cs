using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchWidth : MonoBehaviour
{
    public float width;

    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void LateUpdate()
    {
        if (_camera != null)
            _camera.orthographicSize = width * Screen.height / Screen.width * 0.5f;
    }
}