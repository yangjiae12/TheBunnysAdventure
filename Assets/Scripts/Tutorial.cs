using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public UnityEngine.UI.Text methodText; // 기본적인 게임 방법 안내 텍스트

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버툰 클릭 시
        {
            methodText.enabled = false;  // 튜토리얼에 활성화된 게임 방법 알려주는 텍스트 없애기
        }

        if (transform.position.y < -7) // 플레이어가 -7 이하가 되면 (게임에서 밑으로 떨어지면)
        {
            SceneManager.LoadScene("Tutorial"); // 다시 튜토리얼 씬으로 감
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (collision.gameObject.CompareTag("Obstacle")) // 장애물과 충돌하면
        {
            SceneManager.LoadScene("Tutorial"); // 다시 튜토리얼 씬으로 이동
        }
    }
}
