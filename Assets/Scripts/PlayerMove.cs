using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어의 이동 속도
    public float jumpForce = 10f; // 점프의 세기
    public int maxJumps = 2; // 최대 점프 횟수
    private int remainingJumps; // 남은 점프 횟수
    private Rigidbody2D rb; // rigidbody 컴포넌트
    private bool isGrounded; // 땅에 닿았는지의 여부
    private bool isMovingRight; // 오른쪽으로 이동 중인지의 여부

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오고 없으면 추가하기
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        remainingJumps = maxJumps; // 초기 점프 횟수 설정
        isMovingRight = false; // 초기에는 이동하지 않음
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground")); // 땅에 닿았는지 확인

        // 플레이어 이동 (수평 이동)
        float horizontalInput = isMovingRight ? 1f : 0f; // 이동 중이면 1, 아니면 0

        Vector2 moveVector = new Vector2(horizontalInput, 0f) * moveSpeed * Time.deltaTime; // 이동 벡터 계산

        transform.Translate(moveVector); // 이동 벡터만큼 이동

        // 점프 입력 처리
        bool shouldJump = Input.GetKeyDown(KeyCode.Space) && (isGrounded || remainingJumps > 0) && isMovingRight; // 스페이스바 클릭 && 점프 횟수 남음 && 이동 중
        // 게임 시작 전에 점프가 되지 않기 위함

        if (shouldJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // 점프 힘 적용
            if (!isGrounded) // 점프 시
            {
                remainingJumps--; // 점프 횟수 감소
            }
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭 시
        {
            isMovingRight = true; // 오른쪽으로 이동
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 땅이랑 충돌 시 호출되는 함수
    {
        if (collision.gameObject.CompareTag("Ground")) // 땅에 닿으면
        {
            remainingJumps = maxJumps; // 점프 횟수 초기화
        }
    }
}
