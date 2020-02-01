using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを画面の下に移動
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchY : MonoBehaviour
{
    // 画面下からのプレイヤーの距離の定数
    public float y;

    // カメラ
    Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // カメラがあったら動作
        if (_camera != null)
        {
            // orthographicSizeは画面の高さ
            var t = transform;
            var pos = t.localPosition;
            // よって(画面の高さ-定数)がプレイヤーの位置
            pos.y = _camera.orthographicSize - y;
            // 適用
            t.localPosition = pos;
        }
    }
}
