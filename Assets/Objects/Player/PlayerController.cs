using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを操作する
public class PlayerController : MonoBehaviour
{
    // 物理
    private Rigidbody2D _rigid;
    // 前のクリック座標
    private Vector2 _prevMousePos;
    // 加速するスピード (X軸とY軸それぞれ)
    public Vector2 speedMultiplier = new Vector2(.5f, 1f);
    // 加速すればするほど左右のブレが大きくなる値
    public float runout = 1f / 100f;
    // 加速すればするほど左右のブレが大きくなる乗数
    public float runoutPow = 1f;
    // 予想された最大速度
    public float expectedMaxSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
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
            var pos = (Vector2) Input.mousePosition;
            var vel = pos - _prevMousePos;
            // ドラッグ量にスピード定数を掛ける
            vel.Scale(speedMultiplier);
            // 加速すればするほど左右のブレが大きくなる
            vel.Scale(new Vector2(Mathf.Pow(1 + _rigid.velocity.y / expectedMaxSpeed * runout, runoutPow), 1f));
            // 加速
            _rigid.AddForce(vel);
        }
    }
}
