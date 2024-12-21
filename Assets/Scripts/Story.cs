using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Story : MonoBehaviour
{
    public UnityEngine.UI.Text storyText; // ���丮 �ؽ�Ʈ

    private int state = 0; // ���丮 ���� ����

    void Start()
    {
        ShowStoryText(); // �� ���� �� ���丮 �ؽ�Ʈ ǥ��
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���콺 ������ ���� �ؽ�Ʈ ����
        {
            if (state == 0)
            {
                state = 1; // ù��° ���¿��� Ŭ�� �� �ι�°�� �̵�
            }
            else if (state == 1)
            {
                state = 2; // �ι�° ���¿��� Ŭ�� �� �� ��°�� �̵�
            }
            else if (state == 2)
            {
                state = 3; // �� ��° ���¿��� Ŭ�� �� �� ��°�� �̵�
            }
            else if (state == 3)
            {
                SceneManager.LoadScene("Tutorial"); // �� ��° ���¿��� Ŭ�� �� Ʃ�丮��� �̵�
            }

            ShowStoryText(); // ���¿� ���� ���丮 �ؽ�Ʈ ������Ʈ
        }
    }

    void ShowStoryText() // ���� ���¿� ���� ���丮 �ؽ�Ʈ�� ǥ��
    {
        if (state == 0) // ù��° ����
        {
            storyText.text = "������ ����� ������ �������� �䳢�� �ֳ׿�!";
        }
        else if (state == 1) // �ι�° ����
        {
            storyText.text = "�䳢�� ������ �������� �����ðھ��?";
        }
        else if (state == 2) // ������ ����
        {
            storyText.text = "������ ������ ���� ���� ������ �غ��ô�!";
        }
        else if (state == 3) // �׹�° ����
        {
            storyText.text = "Let's Go!";
        }
    }
}
