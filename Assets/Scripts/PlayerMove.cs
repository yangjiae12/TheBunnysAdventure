using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾��� �̵� �ӵ�
    public float jumpForce = 10f; // ������ ����
    public int maxJumps = 2; // �ִ� ���� Ƚ��
    private int remainingJumps; // ���� ���� Ƚ��
    private Rigidbody2D rb; // rigidbody ������Ʈ
    private bool isGrounded; // ���� ��Ҵ����� ����
    private bool isMovingRight; // ���������� �̵� �������� ����

    void Start()
    {
        // Rigidbody2D ������Ʈ �������� ������ �߰��ϱ�
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        remainingJumps = maxJumps; // �ʱ� ���� Ƚ�� ����
        isMovingRight = false; // �ʱ⿡�� �̵����� ����
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground")); // ���� ��Ҵ��� Ȯ��

        // �÷��̾� �̵� (���� �̵�)
        float horizontalInput = isMovingRight ? 1f : 0f; // �̵� ���̸� 1, �ƴϸ� 0

        Vector2 moveVector = new Vector2(horizontalInput, 0f) * moveSpeed * Time.deltaTime; // �̵� ���� ���

        transform.Translate(moveVector); // �̵� ���͸�ŭ �̵�

        // ���� �Է� ó��
        bool shouldJump = Input.GetKeyDown(KeyCode.Space) && (isGrounded || remainingJumps > 0) && isMovingRight; // �����̽��� Ŭ�� && ���� Ƚ�� ���� && �̵� ��
        // ���� ���� ���� ������ ���� �ʱ� ����

        if (shouldJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ���� �� ����
            if (!isGrounded) // ���� ��
            {
                remainingJumps--; // ���� Ƚ�� ����
            }
        }

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ�� ��
        {
            isMovingRight = true; // ���������� �̵�
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ���̶� �浹 �� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.CompareTag("Ground")) // ���� ������
        {
            remainingJumps = maxJumps; // ���� Ƚ�� �ʱ�ȭ
        }
    }
}
