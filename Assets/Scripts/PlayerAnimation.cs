using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator; // 애니메이터를 참조하기 위한 변수

    void Start()
    {
        this.animator = GetComponent<Animator>(); // 애니메이터 컴포넌트를 가져와 변수에 할당
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 누르면
        {
            this.animator.SetTrigger("MoveTrigger"); // animator의 MoveTrigger 활성화
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스키를 누르면
        {
            this.animator.SetTrigger("JumpTrigger"); // animator의 JumpTrigger 활성화
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // 다른 물체와 충돌하면 호출되는 함수
    {
        if (collision.gameObject.CompareTag("Obstacle")) // obstacle과 충돌할 경우
        {
            this.animator.SetTrigger("DamageTrigger"); // animator의 DamageTrigger 활성화

        }
    }
}
