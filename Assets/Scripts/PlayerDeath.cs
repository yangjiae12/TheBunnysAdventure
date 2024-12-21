using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ScoreManager scoreManager;  // ScoreManager를 참조할 변수

    void Update()
    {
        if (transform.position.y < -7) // 플레이어의 높이가 -7 이하면 (게임 내에서 밑으로 떨어지면)
        {
            Die(); // die 함수 호출
        }
    }

    void Die() // 플레이어 사망 시 호출
    {
        if (scoreManager != null) // scoreManager가 할당 되어 있으면
        {
            scoreManager.ResetScore(); // scoreManager의 resetscore 호출해 점수 리셋
        }
            
        SceneManager.LoadScene("GameOver"); // GameOver 씬으로 전환
    }
}
