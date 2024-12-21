using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class ItemManager : MonoBehaviour
{
    public UnityEngine.UI.Text item1Text; // ������ 1 ȹ�� �� ǥ���� �ؽ�Ʈ
    public UnityEngine.UI.Text item3Text; // ������ 3 ȹ�� �� ǥ���� �ؽ�Ʈ
    public float displayDuration = 1f; // �ؽ�Ʈ ǥ�� �ð�
    public PlayerHealth playerHealth; // �÷��̾� �ｺ ��ũ��Ʈ ����
    public PlayerAttack playerAttack; // �÷��̾� ���� ��ũ��Ʈ ����

    public AudioSource audioSource; // ������� ����� AudioSource
    public AudioClip itemSound; // ������ �浹 �� ����� ����� Ŭ��

    private void Start()
    {
        if (item1Text != null) // ������ 1 �ؽ�Ʈ ���� �Ǿ� ������
        {
            item1Text.gameObject.SetActive(false);  // ��Ȱ��ȭ
        }
        if (item3Text != null) // ������ 3 �ؽ�Ʈ ���� �Ǿ� ������
        {
            item3Text.gameObject.SetActive(false); // ��Ȱ��ȭ
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (other.gameObject.CompareTag("Item1")) // ������ 1�� �浹�� ���
        {
            playerHealth.IncreaseHealth(1); // PlayerHealth ��ũ��Ʈ�� IncreaseHealth ȣ���Ͽ� ü�� ����
            Destroy(other.gameObject); // �浹�� ������ �ı�
            if (item1Text != null) // ������ 1 �ؽ�Ʈ�� ���� �������� 
            {
                StartCoroutine(DisplayItem1Text()); // �ؽ�Ʈ ǥ�� ����
            }
            PlayItemSound();
        }

        if (other.gameObject.CompareTag("Item2")) // ������ 2�� �浹�� ���
        {
            Destroy(other.gameObject); // �浹�� ������Ʈ (������2) �ı�
            PlayItemSound();
        }

        if (other.gameObject.CompareTag("Item3")) // ������ 3�� �浹�� ���
        {
            Destroy(other.gameObject); // �浹�� ������Ʈ (������3) �ı�
            playerAttack.EnableShooting(); // PlayerAttack ��ũ��Ʈ�� EnableShooting ȣ���� ���ݱ�� Ȱ��ȭ
            playerAttack.ResetMissileCount(); // PlayerAttack ��ũ��Ʈ�� ResetMissileCount ȣ���� �̻��� �߻� Ƚ�� �ʱ�ȭ
            if (item3Text != null) // ������ 3 �ؽ�Ʈ�� �����Ǿ� ������
            {
                StartCoroutine(DisplayItem3Text()); // �ؽ�Ʈ ǥ�� ����
            }
            PlayItemSound();
        }
    }

    private void PlayItemSound()
    {
        if (audioSource != null && itemSound != null)
        {
            audioSource.PlayOneShot(itemSound); // ����� ���
        }
    }

    private IEnumerator DisplayItem1Text() // ������ 1 �ؽ�Ʈ�� ���� �ð� ���� ǥ���ϴ� �ڷ�ƾ
    {
        item1Text.gameObject.SetActive(true); // ������ 1 �ؽ�Ʈ Ȱ��ȭ
        yield return new WaitForSeconds(displayDuration); // ������ �ð����� ����
        item1Text.gameObject.SetActive(false); // ������ 1 �ؽ�Ʈ ��Ȱ��ȭ
    }

    private IEnumerator DisplayItem3Text()
    {
        item3Text.gameObject.SetActive(true); // ������ 3 �ؽ�Ʈ Ȱ��ȭ
        yield return new WaitForSeconds(displayDuration); // ������ �ð����� ����
        item3Text.gameObject.SetActive(false); // ������ 3 �ؽ�Ʈ ��Ȱ��ȭ
    }
}
