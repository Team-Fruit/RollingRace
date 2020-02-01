using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ステージの幅を画面の幅に合わせる
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchWidth : MonoBehaviour
{
    // ステージの幅の定数
    public float width;

    // カメラ
    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void LateUpdate()
    {
        // カメラがあったら動作
        if (_camera != null)
            // 画面の高さを(定数*幅/高さ)すれば画面の幅になる
            _camera.orthographicSize = width * Screen.height / Screen.width;
    }
}