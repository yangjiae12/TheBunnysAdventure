using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdStage : MonoBehaviour
{
    public UnityEngine.UI.Text thirdStageMethodText; // �߰����� ���� ��� �ȳ� �ؽ�Ʈ

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ���ϸ�
        {
            thirdStageMethodText.enabled = false;  // Ȱ��ȭ�� ���� ��� �˷��ִ� �ؽ�Ʈ ���ֱ�
        }
    }
}
