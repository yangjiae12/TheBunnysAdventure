using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStage : MonoBehaviour
{
    public UnityEngine.UI.Text firstStageText; // ���� ���� �� �ؽ�Ʈ

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ���ϸ�
        {
            firstStageText.enabled = false;  // �ؽ�Ʈ ���ֱ�
        }
    }
}
