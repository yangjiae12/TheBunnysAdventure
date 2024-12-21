using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�

public class StageClear : MonoBehaviour
{
    public ScoreManager scoreManager;  // ScoreManager ������ ����
    public UnityEngine.UI.Text scoreDisplayText;  // ������ ǥ���� UI Text ����
    public UnityEngine.UI.Text highestScoreDisplayText;  // �ְ� ������ ǥ���� UI Text
    public UnityEngine.UI.Button endGameButton;  // ���� ���� ��ư

    void OnCollisionEnter2D(Collision2D collision) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.CompareTag("Door")) // door�� �浹�ϸ�
        {
            string sceneName = SceneManager.GetActiveScene().name; // ���� ���� �̸��� ��������

            switch (sceneName)
            {
                case "Tutorial":
                    SceneManager.LoadScene("1stStage"); // Ʃ�丮�� �������� �������� 1�� �̵�
                    break;
                case "1stStage":
                    SceneManager.LoadScene("2ndStage"); // ��������1������ �������� 2�� �̵�
                    break;
                case "2ndStage":
                    SceneManager.LoadScene("3rdStage"); // �������� 2������ �������� 3���� �̵�
                    break;
                case "3rdStage":
                    // ���� ���� ���� �� �ְ� ���� ������Ʈ
                    if (scoreManager != null)
                    {
                        scoreManager.SaveScore(); // ���� ���� ����
                        scoreManager.UpdateHighestScore(); // �ְ� ���� ������Ʈ
                    }
                    int currentScore = scoreManager.GetScore();  // ���� ���� ��������
                    int highestScore = scoreManager.GetHighestScore();  // �ְ� ���� ��������

                    // ���� ���� ǥ��
                    if (scoreDisplayText != null)
                    {
                        scoreDisplayText.text = "���� ����: " + currentScore.ToString();
                    }

                    // �ְ� ���� ǥ��
                    if (highestScoreDisplayText != null)
                    {
                        highestScoreDisplayText.text = "�ְ� ����: " + highestScore.ToString();
                    }

                    // ���� ���� ��ư Ȱ��ȭ
                    if (endGameButton != null)
                    {
                        endGameButton.gameObject.SetActive(true);
                    }

                    scoreManager.ResetScore();

                    break;
            }
        }
    }
}
