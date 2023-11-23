using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform target; // Ÿ���� Transform.
    public GameObject bulletPrefab; // �߻��� �Ѿ� ������.
    public Transform bulletSpawnPoint; // �Ѿ��� �߻�� ��ġ.
    public float fireRate = 5f; // �߻� ����(��).
    public float bulletSpeed = 1000f; // �Ѿ��� �ӵ�.

    private float nextFireTime; // ���� �߻� �ð�.

    void Start()
    {
        nextFireTime = Time.time + fireRate; // ���� �߻� �ð� �ʱ�ȭ.
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate; // ���� �߻� �ð� ����.
        }
    }

    void FireBullet()
    {
        if (bulletPrefab && bulletSpawnPoint && target)
        {
            // �Ѿ� �������� �߻� ��ġ���� �����մϴ�.
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // �Ѿ��� Rigidbody ������Ʈ�� ������ ���� ���մϴ�.
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb)
            {
                // �Ѿ��� Ÿ�� �������� �߻��մϴ�.
                Vector3 direction = (target.position - bulletSpawnPoint.position).normalized;
                rb.AddForce(direction * bulletSpeed);
            }

            // �Ѿ��� ���� �ð� �Ŀ� ��������� �����մϴ�.
            Destroy(bullet, 5f); // ���� ��� 5�� �Ŀ� �Ѿ��� �ı��մϴ�.
        }
    }
}
