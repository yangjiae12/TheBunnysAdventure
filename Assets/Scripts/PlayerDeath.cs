using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ScoreManager scoreManager;  // ScoreManager�� ������ ����

    void Update()
    {
        if (transform.position.y < -7) // �÷��̾��� ���̰� -7 ���ϸ� (���� ������ ������ ��������)
        {
            Die(); // die �Լ� ȣ��
        }
    }

    void Die() // �÷��̾� ��� �� ȣ��
    {
        if (scoreManager != null) // scoreManager�� �Ҵ� �Ǿ� ������
        {
            scoreManager.ResetScore(); // scoreManager�� resetscore ȣ���� ���� ����
        }
            
        SceneManager.LoadScene("GameOver"); // GameOver ������ ��ȯ
    }
}
