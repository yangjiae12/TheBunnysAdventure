using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;  // �ִ� ����
    public int currentHealth;  // ���� ����
    public UnityEngine.UI.Text healthText;  // ���� �ؽ�Ʈ
    public UnityEngine.UI.Text damageText;  // ������ �ؽ�Ʈ
    public float displayTime = 3f;  // ������ �ؽ�Ʈ�� �������� �ð�
    public ScoreManager scoreManager;  // ScoreManager ������ ������ ����

    private void Start()
    {
        currentHealth = maxHealth;  // ������ ������ ���� �ִ� �������� ����
        UpdateHealthUI(); // UI ������Ʈ
        damageText.enabled = false;  // ������ �� ������ �ؽ�Ʈ �� ���̰�
    }

    private void UpdateHealthUI()  // ���� ������ UI�� ���̴� �Լ�
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString(); // Health : ���� ���� �ؽ�Ʈ ����
        }
    }

    public void TakeDamage(int damage)  // ���� ���ҽ�Ű�� �Լ�
    {
        currentHealth -= damage;  // ��������ŭ ���� ����
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // ������ ������ ���� �ʵ��� ��
        UpdateHealthUI(); // UI ������Ʈ

        if (currentHealth <= 0)  // ������ 0�� �Ǹ�
        {
            Die(); // ���ó��
        }
    }

    public void IncreaseHealth(int amount)  // ���� ����
    {
        currentHealth += amount;  // ���� ����
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // �ִ� ���� �̻����� ������ �������� �ʵ��� ���� ����
        UpdateHealthUI();  // UI ������Ʈ
    }

    private void OnCollisionEnter2D(Collision2D collision) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ��ֹ��� �浹�� ��� �÷��̾��� ���� ����
            TakeDamage(1);  // �������� 1�� ����
            StartCoroutine(ShowAndHideText());

            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private IEnumerator ShowAndHideText()  // ������ �ؽ�Ʈ�� ���� ����ڿ��� �浹 �˸���
    {
        damageText.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageText.enabled = false;
    }

    private void Die() // �÷��̾ ������� �� ȣ��Ǵ� �Լ�
    {
        if (scoreManager != null)
        {
            scoreManager.ResetScore(); // ScoreManager�� ����Ͽ� ���� �ʱ�ȭ
        }

        SceneManager.LoadScene("GameOver"); // GameOver ������ ��ȯ
    }
}
