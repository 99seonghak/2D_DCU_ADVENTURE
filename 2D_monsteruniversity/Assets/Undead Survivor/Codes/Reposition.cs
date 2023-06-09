using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x); // 플레이어 위치 - 타일맵 위치 계산으로 거리 구하기 [절대값]
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40); // 지정된 값 만큼 현재 위치에서 이동
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40); // 지정된 값 만큼 현재 위치에서 이동
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    // 플레이어의 이동 방향에 따라 맞은 편에서 등장하도록 이동
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}
