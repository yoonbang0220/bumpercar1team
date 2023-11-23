using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAaDbefore : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100.0f;
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform bulletSpawn; // �Ѿ��� ������ ��ġ
    public float bulletSpeed = 20f; // �Ѿ��� �ӵ�
    public float forceAmount = 2f; // ������ ���
    private Rigidbody rb;
    private int hitCount = 0; // �浹 Ƚ���� ���
    private const int MaxHits = 10; // ���Ǵ� �ִ� �浹 Ƚ��
    private NavMeshAgent agent; // NavMeshAgent ����


    void Start()
    {
        // ������Ʈ�� NavMeshAgent ������Ʈ�� �ִٰ� �����ϰ� ������ �����ɴϴ�.
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ������Ʈ �̵�
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // �̵��ÿ��� ������Ʈ ȸ��
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // ���콺 ��ư(�Ϲ������� ���� ��ư) Ŭ�� �� �Ѿ� �߻�
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // �Ѿ� �ν��Ͻ� ����
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // �Ѿ˿� �ӵ� �ο�
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = bulletSpawn.forward * bulletSpeed;
        }

        // �Ѿ��� �� �� �Ŀ� �ڵ����� �ı�(�ɼ�)
        Destroy(bullet, 2f); // 2�� �Ŀ� �Ѿ� �ν��Ͻ� �ı�
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitCount++; // Increase the collision count
            Debug.Log("Hit count: " + hitCount);
            if (hitCount >= MaxHits) // Check if maximum collisions are reached
            {
                Destroy(gameObject); // Destroy the object
            }
            else
            {
                // Get the direction from which the hit was received
                Vector3 hitDirection = collision.contacts[0].point - transform.position;
                hitDirection = -hitDirection.normalized;

                // Apply the impulse force
                rb.AddForce(hitDirection * forceAmount, ForceMode.Impulse);

                // Disable further physics interactions for 1 second
                rb.isKinematic = true;

                // After 1 second, reset the velocity and resume physics simulation
                StartCoroutine(ResetVelocityAfterDelay(1f));
            }
        }
    }

    IEnumerator ResetVelocityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the delay

        // After the delay, reset the velocity and re-enable physics interactions
        rb.isKinematic = false; // Re-enable physics simulation
        rb.velocity = Vector3.zero; // Reset the velocity
    }
}
