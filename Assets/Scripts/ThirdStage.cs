using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdStage : MonoBehaviour
{
    public UnityEngine.UI.Text thirdStageMethodText; // 추가적인 게임 방법 안내 텍스트

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭하면
        {
            thirdStageMethodText.enabled = false;  // 활성화된 게임 방법 알려주는 텍스트 없애기
        }
    }
}
