using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject missilePrefab; // �̻��� ������
    public Transform missileSpawnPoint; // �̻����� �߻�Ǵ� ��ġ
    public float missileSpeed = 10f; // �̻��� �ӵ�
    private bool canShoot = false; // ���� ���� ����
    private int missileCount = 0; // �߻�� �̻��� ���� ī��Ʈ �ϱ� ����
    private List<GameObject> activeMissiles = new List<GameObject>(); // Ȱ��ȭ�� �̻��� ����Ʈ

    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Z)) // ���� ���� �����̰� zŰ�� ������ ��
        {
            ShootMissile(); // �̻��� �߻�
        }
    }

    public void EnableShooting() // ���� ��� Ȱ��ȭ �Լ�
    {
        canShoot = true; 
    }

    public void DisableShooting() // ���� ��� ��Ȱ��ȭ �Լ�
    {
        canShoot = false;
    }

    public void ResetMissileCount() // �̻��� �߻� Ƚ�� �ʱ�ȭ �Լ�
    {
        missileCount = 0;
    }

    private void ShootMissile() // �̻��� �߻� �Լ�
    {
        if (missileCount >= 3) // �̻��� �߻� Ƚ���� 3�� �̻��̸�
        {
            return; // �̹� �̻����� 3�� �߻������� ���ο� �̻����� �������� ����
        }

        // �̻��� ���� �� ȸ�� ����
        Quaternion rotation = Quaternion.Euler(0, 0, 90); // Z���� �������� 90�� ȸ��
        GameObject missile = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation * rotation);
        // �̻��� �������� �̻��� �߻� ��ġ�� ȸ������ �������� �ν��Ͻ�ȭ�Ͽ� missile ������ �Ҵ�

        // �̻��� �߻�
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = missileSpawnPoint.right * missileSpeed; // �̻��Ͽ� �ӵ� ����
        }

        activeMissiles.Add(missile); // Ȱ��ȭ�� �̻��� ����Ʈ�� �߰�
        missileCount++; // �߻�� �̻��� �� ����

        Missile missileScript = missile.GetComponent<Missile>(); // �̻��� ��ũ��Ʈ ��������
        if (missileScript != null)
        {
            missileScript.OnDestroyed += HandleMissileDestroyed; // �̻����� �ı��Ǹ� ȣ��� �Լ� ���
        }
    }

    private void HandleMissileDestroyed(GameObject missile) // �̻����� �ı��� �� ȣ��Ǵ� �Լ�
    {
        activeMissiles.Remove(missile); // Ȱ��ȭ�� �̻��� ����Ʈ���� ����
    }
}
