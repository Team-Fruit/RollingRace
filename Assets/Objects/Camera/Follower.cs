using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カメラをプレイヤーに追尾させる
[ExecuteInEditMode]
public class Follower : MonoBehaviour
{
    // プレイヤーのトランスフォーム
    public Transform target;

    void LateUpdate()
    {
        // ターゲットがあったら動作
        if (target != null)
            // 適用
            transform.position = target.position;
    }
}
