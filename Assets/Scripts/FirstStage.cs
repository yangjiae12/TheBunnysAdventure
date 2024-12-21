using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStage : MonoBehaviour
{
    public UnityEngine.UI.Text firstStageText; // 게임 시작 전 텍스트

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭하면
        {
            firstStageText.enabled = false;  // 텍스트 없애기
        }
    }
}
