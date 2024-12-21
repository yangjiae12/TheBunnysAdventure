using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;  // 최대 생명
    public int currentHealth;  // 현재 생명
    public UnityEngine.UI.Text healthText;  // 생명 텍스트
    public UnityEngine.UI.Text damageText;  // 데미지 텍스트
    public float displayTime = 3f;  // 데미지 텍스트가 보여지는 시간
    public ScoreManager scoreManager;  // ScoreManager 참조를 저장할 변스

    private void Start()
    {
        currentHealth = maxHealth;  // 게임을 시작할 때는 최대 생명으로 설정
        UpdateHealthUI(); // UI 업데이트
        damageText.enabled = false;  // 시작할 때 데미지 텍스트 안 보이게
    }

    private void UpdateHealthUI()  // 현재 생명을 UI에 보이는 함수
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString(); // Health : 현재 생명 텍스트 형식
        }
    }

    public void TakeDamage(int damage)  // 생명 감소시키는 함수
    {
        currentHealth -= damage;  // 데미지만큼 생명 감소
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // 생명이 음수가 되지 않도록 함
        UpdateHealthUI(); // UI 업데이트

        if (currentHealth <= 0)  // 생명이 0이 되면
        {
            Die(); // 사망처리
        }
    }

    public void IncreaseHealth(int amount)  // 생명 증가
    {
        currentHealth += amount;  // 생명 증가
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // 최대 생명 이상으로 생명이 증가하지 않도록 범위 설정
        UpdateHealthUI();  // UI 업데이트
    }

    private void OnCollisionEnter2D(Collision2D collision) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 장애물과 충돌할 경우 플레이어의 생명 감소
            TakeDamage(1);  // 데미지를 1로 설정
            StartCoroutine(ShowAndHideText());

            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator ShowAndHideText()  // 데미지 텍스트를 통해 사용자에게 충돌 알리기
    {
        damageText.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageText.enabled = false;
    }

    private void Die() // 플레이어가 사망했을 때 호출되눈 함수
    {
        if (scoreManager != null)
        {
            scoreManager.ResetScore(); // ScoreManager를 사용하여 점수 초기화
        }

        SceneManager.LoadScene("GameOver"); // GameOver 씬으로 전환
    }
}
