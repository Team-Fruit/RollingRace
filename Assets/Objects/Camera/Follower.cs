using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カメラをプレイヤーに追尾させる
[ExecuteInEditMode]
public class Follower : MonoBehaviour
{
    // プレイヤーのトランスフォーム
    public Transform target;
    // 軸ロック
    public Vector3 scale;

    void LateUpdate()
    {
        // ターゲットがあったら動作
        if (target != null)
        {
            // 適用
            var t = transform;
            var position = t.position;
            var diff = (target.position - position);
            diff.Scale(scale);
            position += diff;
            t.position = position;
        }
    }
}
