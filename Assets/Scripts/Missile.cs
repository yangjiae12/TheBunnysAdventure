using UnityEngine;
using System;
using System.Diagnostics;

public class Missile : MonoBehaviour
{
    public event Action<GameObject> OnDestroyed; // �̻����� �ı��� �� ȣ��

    private void OnTriggerEnter2D(Collider2D other) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (other.gameObject.CompareTag("Obstacle")) // ��ֹ��� �浹�� ���
        {
            Destroy(other.gameObject); // ��ֹ� ����
            Destroy(gameObject); // �̻��� ����
        }
    }

    private void OnDestroy() // �̻����� �ı��� �� ȣ��
    {
        if (OnDestroyed != null) // OnDestroyed �̺�Ʈ�� �����ڰ� �ִ��� Ȯ�� 
        {
            OnDestroyed(gameObject); // �ı��� �� �̺�Ʈ ȣ��
        }
    }
}
