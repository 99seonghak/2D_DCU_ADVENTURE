using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 inputVec; // 공개
    public float speed; // 속도 관리


    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // 1. 힘을 준다
        // rigid.AddForce(inputVec);

        // 2. 속도 제어
        // rigid.velocity = inputVec;

        // 3. 위치 이동
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime; // 물리 프레임 하나가 소비한 시간
        // 벡터 값의 크기가 1이 되도록 좌표가 수정된 값
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
            if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
