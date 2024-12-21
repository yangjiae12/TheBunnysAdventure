using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public UnityEngine.UI.Text methodText; // �⺻���� ���� ��� �ȳ� �ؽ�Ʈ

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ���� Ŭ�� ��
        {
            methodText.enabled = false;  // Ʃ�丮�� Ȱ��ȭ�� ���� ��� �˷��ִ� �ؽ�Ʈ ���ֱ�
        }

        if (transform.position.y < -7) // �÷��̾ -7 ���ϰ� �Ǹ� (���ӿ��� ������ ��������)
        {
            SceneManager.LoadScene("Tutorial"); // �ٽ� Ʃ�丮�� ������ ��
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.CompareTag("Obstacle")) // ��ֹ��� �浹�ϸ�
        {
            SceneManager.LoadScene("Tutorial"); // �ٽ� Ʃ�丮�� ������ �̵�
        }
    }
}
