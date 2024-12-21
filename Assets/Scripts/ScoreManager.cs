using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;  // 점수를 표시할 텍스으
    public UnityEngine.UI.Text doubleScoreText;  // 더블 점수 활성화를 표시할 텍스트
    private int score = 0;  // 현재 점수
    private int highestScore = 0;  // 최고 점수
    private bool isDoubleScoreActive = false;  // 더블 점수 활성화 여부
    private Coroutine doubleScoreCoroutine;  // 더블 점수 코루틴

    private void Start()
    {
        LoadScore();  // 저장된 점수 불러오기
        UpdateScoreUI();  // 점수 UI 업데이트
        doubleScoreText.gameObject.SetActive(false);  // 더블 점수 텍스트 비활성화
    }

    public void UpdateScoreUI() // 현재 점수 표시 함수
    {
        scoreText.text = "Score: " + score.ToString();  // 현재 점수를 UI에 표시
    }

    private void OnTriggerEnter2D(Collider2D other) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (other.gameObject.CompareTag("Score1")) // 스코어1과 충돌하면
        {
            Destroy(other.gameObject); // 스코어1 제거
            score += isDoubleScoreActive ? 2 : 1;  // 더블 점수 활성화 여부에 따라 점수 추가
            UpdateScoreUI(); // UI 업데이트
        }

        if (other.gameObject.CompareTag("Score2"))
        {
            Destroy(other.gameObject); // 스코어2 제거
            score += isDoubleScoreActive ? 4 : 2;  // 더블 점수 활성화 여부에 따라 점수 추가
            UpdateScoreUI();  // UI 업데이트
        }

        if (other.gameObject.CompareTag("Item2")) // 아이템2와 충돌하면 
        {
            Destroy(other.gameObject); // 아이템2 제겨
            if (doubleScoreCoroutine != null) // 기존에 점수 더블이 실행되고 있으면
            {
                StopCoroutine(doubleScoreCoroutine); // 중지 시키기
            }
            doubleScoreCoroutine = StartCoroutine(DoubleScoreForDuration(5f));  // 5초간 더블 점수 활성화
        }
    }

    private IEnumerator DoubleScoreForDuration(float duration) // 일정 시간동안 더블 점수 활성화 함수
    {
        isDoubleScoreActive = true;
        doubleScoreText.gameObject.SetActive(true); // 더블 점수 UI 활성화
        yield return new WaitForSeconds(duration); // 설정한 시간만큼 대기
        isDoubleScoreActive = false; // 점수 더블 비활성화
        doubleScoreText.gameObject.SetActive(false); // 더블 점수 UI 비활성화
    }

    private void OnDestroy()
    {
        SaveScore();  // 객체가 파괴될 때 점수 저장
    }

    private void OnApplicationQuit()
    {
        ResetScore();  // 애플리케이션 종료 시 점수 초기화
    }

    public int GetScore()
    {
        return score;  // 현재 점수 반환
    }

    public int GetHighestScore()
    {
        return highestScore;  // 최고 점수 반환
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score); // 현재 점수 저장
        PlayerPrefs.SetInt("HighestScore", highestScore);  // 최고 점수 저장
        PlayerPrefs.Save(); // PlayerPrefs에 변경 사항 저장
    }

    private void LoadScore() // 저장된 점수 불러오는 함수
    {
        if (PlayerPrefs.HasKey("Score")) // PlayerPrefs에 "Score" 키가 저장되어 있으면
        {
            score = PlayerPrefs.GetInt("Score");  // 저장된 현재 점수 불러오기
        }
        if (PlayerPrefs.HasKey("HighestScore")) // PlayerPrefs에 "HighestScore" 키가 저장되어 있으면
        {
            highestScore = PlayerPrefs.GetInt("HighestScore");  // 저장된 최고 점수 불러오기
        }
    }

    public void ResetScore() // 현재 점수 초기화 함수
    {
        score = 0; // 현재 점수 초기화
        UpdateScoreUI();  // UI 업데이트
        SaveScore();  // 점수 초기화 후 저장
    }

    public void UpdateHighestScore() // 최고 점수 초기화 함수
    {
        if (score > highestScore) // 현재 점수가 최고 점수보다 높으면
        {
            highestScore = score; // 최고 점수를 현재 점수로 저장
            SaveScore(); // 변경된 최고 점수 저장
        }
    }
}
