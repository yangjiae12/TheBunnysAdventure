using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Story : MonoBehaviour
{
    public UnityEngine.UI.Text storyText; // 스토리 텍스트

    private int state = 0; // 스토리 진행 상태

    void Start()
    {
        ShowStoryText(); // 씬 시작 시 스토리 텍스트 표시
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 마우스 누르면 다음 텍스트 띄우기
        {
            if (state == 0)
            {
                state = 1; // 첫번째 상태에서 클릭 시 두번째로 이동
            }
            else if (state == 1)
            {
                state = 2; // 두번째 상태에서 클릭 시 세 번째로 이동
            }
            else if (state == 2)
            {
                state = 3; // 세 번째 상태에서 클릭 시 네 번째로 이동
            }
            else if (state == 3)
            {
                SceneManager.LoadScene("Tutorial"); // 네 번째 상태에서 클릭 시 튜토리얼로 이동
            }

            ShowStoryText(); // 상태에 따른 스토리 텍스트 업데이트
        }
    }

    void ShowStoryText() // 현재 상태에 따른 스토리 텍스트를 표시
    {
        if (state == 0) // 첫번째 상태
        {
            storyText.text = "미지의 세계로 모험을 떠나려는 토끼가 있네요!";
        }
        else if (state == 1) // 두번째 상태
        {
            storyText.text = "토끼와 여정을 떠나시지 않으시겠어요?";
        }
        else if (state == 2) // 세번쨰 상태
        {
            storyText.text = "모험을 떠나기 전에 먼저 연습을 해봅시다!";
        }
        else if (state == 3) // 네번째 상태
        {
            storyText.text = "Let's Go!";
        }
    }
}
