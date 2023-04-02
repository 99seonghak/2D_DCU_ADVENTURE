using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 속도, 목표, 생존여부를 위한 변수 선언
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    // 물리적인 이동이기 때문에 업데이트 안 씀

    void FixedUpdate()
    {
        if (!isLive)
            return;

        // 위치 차이 = 타겟 위치 - 나의 위치
        Vector2 dirVec = target.position - rigid.position;

        // 플레이어의 키입력 값을 더한 이동 = 몬스터 방향 값을 더한 이동
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return;
        // 방향 반전
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
