using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject missilePrefab; // 미사일 프리팹
    public Transform missileSpawnPoint; // 미사일이 발사되는 위치
    public float missileSpeed = 10f; // 미사일 속도
    private bool canShoot = false; // 공격 가능 여부
    private int missileCount = 0; // 발사된 미사일 수를 카운트 하기 위함
    private List<GameObject> activeMissiles = new List<GameObject>(); // 활성화된 미사일 리스트

    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Z)) // 공격 가능 상태이고 z키를 눌렀을 때
        {
            ShootMissile(); // 미사일 발사
        }
    }

    public void EnableShooting() // 공격 기능 활성화 함수
    {
        canShoot = true; 
    }

    public void DisableShooting() // 공격 기능 비활성화 함수
    {
        canShoot = false;
    }

    public void ResetMissileCount() // 미사일 발사 횟수 초기화 함수
    {
        missileCount = 0;
    }

    private void ShootMissile() // 미사일 발사 함수
    {
        if (missileCount >= 3) // 미사일 발사 횟수가 3번 이상이면
        {
            return; // 이미 미사일을 3번 발사했으면 새로운 미사일을 생성하지 않음
        }

        // 미사일 생성 및 회전 설정
        Quaternion rotation = Quaternion.Euler(0, 0, 90); // Z축을 기준으로 90도 회전
        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation * rotation);
        // 미사일 프리팹을 미사일 발사 위치와 회전값을 기준으로 인스턴스화하여 missile 변수에 할당

        // 미사일 발사
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = missileSpawnPoint.right * missileSpeed; // 미사일에 속도 적용
        }

        activeMissiles.Add(missile); // 활성화된 미사일 리스트에 추가
        missileCount++; // 발사된 미사일 수 증가

        Missile missileScript = missile.GetComponent<Missile>(); // 미사일 스크립트 가져오기
        if (missileScript != null)
        {
            missileScript.OnDestroyed += HandleMissileDestroyed; // 미사일이 파괴되면 호출될 함수 등록
        }
    }

    private void HandleMissileDestroyed(GameObject missile) // 미사일이 파괴될 때 호출되는 함수
    {
        activeMissiles.Remove(missile); // 활성화된 미사일 리스트에서 제거
    }
}
