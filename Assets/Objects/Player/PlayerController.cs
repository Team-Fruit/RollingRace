using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// プレイヤーを操作する
public class PlayerController : MonoBehaviour
{
    // 物理
    private Rigidbody2D _rigid;
    // 前のクリック座標
    private Vector2 _prevMousePos;
    // 前の座標
    private Vector2 _prevPos;

    // 加速するスピード (X軸とY軸それぞれ)
    public Vector2 speedMultiplier = new Vector2(.5f, 1f);
    // 加速すればするほど左右のブレが大きくなる値
    public float runout = 1f / 100f;
    // 加速すればするほど左右のブレが大きくなる乗数
    public float runoutPow = 1f;
    // 予想された最大速度
    public float expectedMaxSpeed = 100f;
    // 減速
    public float hitSpeedDown = .02f;

    // サイズ
    private float _currentSizeProgress = 0f;
    // 最大サイズ
    public float maxSize = 0f;
    // サイズスピード
    public float sizeProgressSpeed = .01f;
    // サイズダウン
    public float hitSizeDown = .02f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        // 位置を保存
        _prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // クリック直後は無視
        if (Input.GetMouseButtonDown(0))
        {
            _prevMousePos = Input.mousePosition;
        }

        // ドラッグされたらドラッグされた移動量、加速する
        if (Input.GetMouseButton(0))
        {
            // ドラッグ量算出
            var pos = (Vector2)Input.mousePosition;
            var sub = pos - _prevMousePos;

            // 速度計算
            var vel = sub;
            // ドラッグ量にスピード定数を掛ける
            vel.Scale(speedMultiplier);
            // 加速すればするほど左右のブレが大きくなる
            vel.Scale(new Vector2(Mathf.Pow(1 + _rigid.velocity.y / expectedMaxSpeed * runout, runoutPow), 1f));
            // 加速
            _rigid.AddForce(vel);
        }

        // 移動量に応じてサイズを増やす
        {
            var pos = (Vector2)transform.position;
            var diff = pos - _prevPos;
            _prevPos = pos;

            // サイズ進捗を加算
            _currentSizeProgress += Mathf.Abs(diff.y) * sizeProgressSpeed * (Time.deltaTime * 60);
            // サイズ進捗を0～1へ丸める
            _currentSizeProgress = Mathf.Clamp01(_currentSizeProgress);
            // サイズ進捗をサイズ(1～maxSize)へ変換
            var currentSize = Mathf.Lerp(1, maxSize, _currentSizeProgress);
            // サイズを適用
            transform.localScale = Vector3.one * currentSize;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 速度0
        if (_rigid.velocity.magnitude > hitSpeedDown)
            _rigid.velocity *= 0;
        // _rigid.velocity *= Mathf.Clamp01(1 - hitSpeedDown / _rigid.velocity.magnitude);
        // サイズをもとに戻す
        _currentSizeProgress -= hitSizeDown;
    }
}
