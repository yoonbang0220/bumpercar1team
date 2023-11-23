using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100.0f;
    public GameObject bulletPrefab; // �Ѿ� ������
    public Transform bulletSpawn; // �Ѿ��� ������ ��ġ
    public float bulletSpeed = 20f; // �Ѿ��� �ӵ�
    private int hitCount = 0; // �浹 Ƚ���� ���
    private const int MaxHits = 10; // ���Ǵ� �ִ� �浹 Ƚ��
    private NavMeshAgent agent; // NavMeshAgent ����
    private bool canMove = true; //�� ������ ��

    void Start()
    {
        // ������Ʈ�� NavMeshAgent ������Ʈ�� �ִٰ� �����ϰ� ������ �����ɴϴ�.
        agent = GetComponent<NavMeshAgent>();
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
        if (collision.gameObject.tag == "EnemyBullet")
        {
            hitCount++;
            if (hitCount >= MaxHits)
            {
                Destroy(gameObject);
            }
            else
            {
                if (agent != null)
                {
                    // NavMeshAgent�� �̵��� 1�� ���� �����մϴ�.
                    agent.isStopped = true;
                    // 1�� �Ŀ� NavMeshAgent�� �̵��� �ٽ� Ȱ��ȭ�մϴ�.
                    StartCoroutine(ResumeAfterDelay(1f));
                }
            }
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // 1�� �� ����� �ڵ�
        if (agent != null)
        {
            // NavMeshAgent�� �̵��� �ٽ� Ȱ��ȭ�մϴ�.
            agent.isStopped = false;
        }
    }
}
