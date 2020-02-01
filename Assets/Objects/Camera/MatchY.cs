using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchY : MonoBehaviour
{
    public float y;

    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_camera != null)
        {
            var t = transform;
            var pos = t.localPosition;
            pos.y = _camera.orthographicSize - y;
            t.localPosition = pos;
        }
    }
}
