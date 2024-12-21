using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class ItemManager : MonoBehaviour
{
    public UnityEngine.UI.Text item1Text; // 아이템 1 획득 시 표시할 텍스트
    public UnityEngine.UI.Text item3Text; // 아이템 3 획득 시 표시할 텍스트
    public float displayDuration = 1f; // 텍스트 표시 시간
    public PlayerHealth playerHealth; // 플레이어 헬스 스크립트 참조
    public PlayerAttack playerAttack; // 플레이어 어택 스크립트 참조

    public AudioSource audioSource; // 오디오를 재생할 AudioSource
    public AudioClip itemSound; // 아이템 충돌 시 재생할 오디오 클립

    private void Start()
    {
        if (item1Text != null) // 아이템 1 텍스트 설정 되어 있으면
        {
            item1Text.gameObject.SetActive(false);  // 비활성화
        }
        if (item3Text != null) // 아이템 3 텍스트 설정 되어 있으면
        {
            item3Text.gameObject.SetActive(false); // 비활성화
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (other.gameObject.CompareTag("Item1")) // 아이템 1과 충돌할 경우
        {
            playerHealth.IncreaseHealth(1); // PlayerHealth 스크립트의 IncreaseHealth 호출하여 체력 증가
            Destroy(other.gameObject); // 충돌한 아이템 파괴
            if (item1Text != null) // 아이템 1 텍스트가 설정 돼있으면 
            {
                StartCoroutine(DisplayItem1Text()); // 텍스트 표시 시작
            }
            PlayItemSound();
        }

        if (other.gameObject.CompareTag("Item2")) // 아이템 2과 충돌할 경우
        {
            Destroy(other.gameObject); // 충돌한 오브젝트 (아이템2) 파괴
            PlayItemSound();
        }

        if (other.gameObject.CompareTag("Item3")) // 아이템 3과 충돌할 경우
        {
            Destroy(other.gameObject); // 충돌한 오브젝트 (아이템3) 파괴
            playerAttack.EnableShooting(); // PlayerAttack 스크립트의 EnableShooting 호출해 공격기능 활성화
            playerAttack.ResetMissileCount(); // PlayerAttack 스크립트의 ResetMissileCount 호출해 미사일 발사 횟수 초기화
            if (item3Text != null) // 아이템 3 텍스트가 설정되어 있으면
            {
                StartCoroutine(DisplayItem3Text()); // 텍스트 표시 시작
            }
            PlayItemSound();
        }
    }

    private void PlayItemSound()
    {
        if (audioSource != null && itemSound != null)
        {
            audioSource.PlayOneShot(itemSound); // 오디오 출력
        }
    }

    private IEnumerator DisplayItem1Text() // 아이템 1 텍스트를 일정 시간 동안 표시하는 코루틴
    {
        item1Text.gameObject.SetActive(true); // 아이템 1 텍스트 활성화
        yield return new WaitForSeconds(displayDuration); // 설정한 시간동안 유지
        item1Text.gameObject.SetActive(false); // 아이템 1 텍스트 비활성화
    }

    private IEnumerator DisplayItem3Text()
    {
        item3Text.gameObject.SetActive(true); // 아이템 3 텍스트 활성화
        yield return new WaitForSeconds(displayDuration); // 설정한 시간동안 유지
        item3Text.gameObject.SetActive(false); // 아이템 3 텍스트 비활성화
    }
}
