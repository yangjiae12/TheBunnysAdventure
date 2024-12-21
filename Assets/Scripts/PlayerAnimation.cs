using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator; // �ִϸ����͸� �����ϱ� ���� ����

    void Start()
    {
        this.animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ�� ������ ������ �Ҵ�
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� ������
        {
            this.animator.SetTrigger("MoveTrigger"); // animator�� MoveTrigger Ȱ��ȭ
        }

        if (Input.GetKeyDown(KeyCode.Space)) // �����̽�Ű�� ������
        {
            this.animator.SetTrigger("JumpTrigger"); // animator�� JumpTrigger Ȱ��ȭ
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.CompareTag("Obstacle")) // obstacle�� �浹�� ���
        {
            this.animator.SetTrigger("DamageTrigger"); // animator�� DamageTrigger Ȱ��ȭ

        }
    }
}
