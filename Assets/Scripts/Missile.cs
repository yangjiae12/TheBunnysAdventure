using UnityEngine;
using System;
using System.Diagnostics;

public class Missile : MonoBehaviour
{
    public event Action<GameObject> OnDestroyed; // 미사일이 파괴될 때 호출

    private void OnTriggerEnter2D(Collider2D other) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (other.gameObject.CompareTag("Obstacle")) // 장애물과 충돌할 경우
        {
            Destroy(other.gameObject); // 장애물 제거
            Destroy(gameObject); // 미사일 제거
        }
    }

    private void OnDestroy() // 미사일이 파괴될 때 호출
    {
        if (OnDestroyed != null) // OnDestroyed 이벤트에 구독자가 있는지 확인 
        {
            OnDestroyed(gameObject); // 파괴될 때 이벤트 호출
        }
    }
}
