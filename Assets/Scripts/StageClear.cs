using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 네임스페이스 추가

public class StageClear : MonoBehaviour
{
    public ScoreManager scoreManager;  // ScoreManager 참조할 변수
    public UnityEngine.UI.Text scoreDisplayText;  // 점수를 표시할 UI Text 참조
    public UnityEngine.UI.Text highestScoreDisplayText;  // 최고 점수를 표시할 UI Text
    public UnityEngine.UI.Button endGameButton;  // 엔드 게임 버튼

    void OnCollisionEnter2D(Collision2D collision) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (collision.gameObject.CompareTag("Door")) // door와 충돌하면
        {
            string sceneName = SceneManager.GetActiveScene().name; // 현재 씬의 이름을 가져오기

            switch (sceneName)
            {
                case "Tutorial":
                    SceneManager.LoadScene("1stStage"); // 튜토리얼 씬에서는 스테이지 1로 이동
                    break;
                case "1stStage":
                    SceneManager.LoadScene("2ndStage"); // 스테이지1에서는 스테이지 2로 이동
                    break;
                case "2ndStage":
                    SceneManager.LoadScene("3rdStage"); // 스테이지 2에서는 스테이지 3으로 이동
                    break;
                case "3rdStage":
                    // 현재 점수 저장 및 최고 점수 업데이트
                    if (scoreManager != null)
                    {
                        scoreManager.SaveScore(); // 현재 점수 저장
                        scoreManager.UpdateHighestScore(); // 최고 점수 업데이트
                    }
                    int currentScore = scoreManager.GetScore();  // 현재 점수 가져오기
                    int highestScore = scoreManager.GetHighestScore();  // 최고 점수 가져오기

                    // 현재 점수 표시
                    if (scoreDisplayText != null)
                    {
                        scoreDisplayText.text = "최종 점수: " + currentScore.ToString();
                    }

                    // 최고 점수 표시
                    if (highestScoreDisplayText != null)
                    {
                        highestScoreDisplayText.text = "최고 점수: " + highestScore.ToString();
                    }

                    // 엔드 게임 버튼 활성화
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
