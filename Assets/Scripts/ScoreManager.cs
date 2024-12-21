using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;  // ������ ǥ���� �ؽ���
    public UnityEngine.UI.Text doubleScoreText;  // ���� ���� Ȱ��ȭ�� ǥ���� �ؽ�Ʈ
    private int score = 0;  // ���� ����
    private int highestScore = 0;  // �ְ� ����
    private bool isDoubleScoreActive = false;  // ���� ���� Ȱ��ȭ ����
    private Coroutine doubleScoreCoroutine;  // ���� ���� �ڷ�ƾ

    private void Start()
    {
        LoadScore();  // ����� ���� �ҷ�����
        UpdateScoreUI();  // ���� UI ������Ʈ
        doubleScoreText.gameObject.SetActive(false);  // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
    }

    public void UpdateScoreUI() // ���� ���� ǥ�� �Լ�
    {
        scoreText.text = "Score: " + score.ToString();  // ���� ������ UI�� ǥ��
    }

    private void OnTriggerEnter2D(Collider2D other) // �ٸ� ��ü�� �浹�ϸ� ȣ��Ǵ� �Լ�
    {
        if (other.gameObject.CompareTag("Score1")) // ���ھ�1�� �浹�ϸ�
        {
            Destroy(other.gameObject); // ���ھ�1 ����
            score += isDoubleScoreActive ? 2 : 1;  // ���� ���� Ȱ��ȭ ���ο� ���� ���� �߰�
            UpdateScoreUI(); // UI ������Ʈ
        }

        if (other.gameObject.CompareTag("Score2"))
        {
            Destroy(other.gameObject); // ���ھ�2 ����
            score += isDoubleScoreActive ? 4 : 2;  // ���� ���� Ȱ��ȭ ���ο� ���� ���� �߰�
            UpdateScoreUI();  // UI ������Ʈ
        }

        if (other.gameObject.CompareTag("Item2")) // ������2�� �浹�ϸ� 
        {
            Destroy(other.gameObject); // ������2 ����
            if (doubleScoreCoroutine != null) // ������ ���� ������ ����ǰ� ������
            {
                StopCoroutine(doubleScoreCoroutine); // ���� ��Ű��
            }
            doubleScoreCoroutine = StartCoroutine(DoubleScoreForDuration(5f));  // 5�ʰ� ���� ���� Ȱ��ȭ
        }
    }

    private IEnumerator DoubleScoreForDuration(float duration) // ���� �ð����� ���� ���� Ȱ��ȭ �Լ�
    {
        isDoubleScoreActive = true;
        doubleScoreText.gameObject.SetActive(true); // ���� ���� UI Ȱ��ȭ
        yield return new WaitForSeconds(duration); // ������ �ð���ŭ ���
        isDoubleScoreActive = false; // ���� ���� ��Ȱ��ȭ
        doubleScoreText.gameObject.SetActive(false); // ���� ���� UI ��Ȱ��ȭ
    }

    private void OnDestroy()
    {
        SaveScore();  // ��ü�� �ı��� �� ���� ����
    }

    private void OnApplicationQuit()
    {
        ResetScore();  // ���ø����̼� ���� �� ���� �ʱ�ȭ
    }

    public int GetScore()
    {
        return score;  // ���� ���� ��ȯ
    }

    public int GetHighestScore()
    {
        return highestScore;  // �ְ� ���� ��ȯ
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score); // ���� ���� ����
        PlayerPrefs.SetInt("HighestScore", highestScore);  // �ְ� ���� ����
        PlayerPrefs.Save(); // PlayerPrefs�� ���� ���� ����
    }

    private void LoadScore() // ����� ���� �ҷ����� �Լ�
    {
        if (PlayerPrefs.HasKey("Score")) // PlayerPrefs�� "Score" Ű�� ����Ǿ� ������
        {
            score = PlayerPrefs.GetInt("Score");  // ����� ���� ���� �ҷ�����
        }
        if (PlayerPrefs.HasKey("HighestScore")) // PlayerPrefs�� "HighestScore" Ű�� ����Ǿ� ������
        {
            highestScore = PlayerPrefs.GetInt("HighestScore");  // ����� �ְ� ���� �ҷ�����
        }
    }

    public void ResetScore() // ���� ���� �ʱ�ȭ �Լ�
    {
        score = 0; // ���� ���� �ʱ�ȭ
        UpdateScoreUI();  // UI ������Ʈ
        SaveScore();  // ���� �ʱ�ȭ �� ����
    }

    public void UpdateHighestScore() // �ְ� ���� �ʱ�ȭ �Լ�
    {
        if (score > highestScore) // ���� ������ �ְ� �������� ������
        {
            highestScore = score; // �ְ� ������ ���� ������ ����
            SaveScore(); // ����� �ְ� ���� ����
        }
    }
}
