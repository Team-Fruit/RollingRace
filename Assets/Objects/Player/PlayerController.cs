using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 prevPos;
    public Vector2 speedMultiplier = new Vector2(.5f, 1f);
    public float runout = 1f / 100f;
    public float runoutPow = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prevPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var pos = (Vector2) Input.mousePosition;
            var vel = pos - prevPos;
            vel.Scale(speedMultiplier);
            vel.Scale(new Vector2(Mathf.Pow(1 + rigid.velocity.y * runout, runoutPow), 1f));
            rigid.AddForce(vel);
        }
    }
}
