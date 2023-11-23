using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NewEnemyAaD : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float forceAmount = 2f;
    private Rigidbody rb;
    private int hitCount = 0; // �浹 Ƚ�� ���� ����
    public Slider hpSlider; // HP �ٷ� ����� Slider ������Ʈ
    public Canvas canvas; // HP Canvas
    public Image controlledImage; // �ν����Ϳ��� �Ҵ��� Image ������Ʈ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        // Slider �ʱ� ����
        hpSlider.maxValue = 100; // HP ���� �ִ� ���� ����
        hpSlider.value = hpSlider.maxValue; // �ʱ� HP ����

        // Image Ȱ��ȭ
        controlledImage.enabled = true;
    }

    void Update()
    {
        if (target != null && !agent.isStopped)
        {
            agent.SetDestination(target.position);
        }

        if (canvas != null)
        {
            canvas.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            hitCount++; // �浹 Ƚ�� ����

            // HP �� ����
            hpSlider.value -= 20; // HP ���� (�� �浹�� 20�� ����)

            if (hitCount >= 5) // �ִ� �浹 Ƚ�� ���� ��
            {
                Destroy(gameObject); // ������Ʈ �ı�
                controlledImage.enabled = false; // Image ��Ȱ��ȭ
            }
            else
            {
                agent.isStopped = true; // NavMeshAgent �Ͻ� ����

                Vector3 hitDirection = collision.contacts[0].point - transform.position;
                hitDirection = -hitDirection.normalized;

                rb.AddForce(hitDirection * forceAmount, ForceMode.Impulse);

                StartCoroutine(EnableAgentAfterDelay(1f)); // 1�� �� NavMeshAgent Ȱ��ȭ
            }
        }
    }

    IEnumerator EnableAgentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 1�� ���

        rb.velocity = Vector3.zero; // Rigidbody �ӵ� 0���� ����
        agent.isStopped = false; // NavMeshAgent Ȱ��ȭ
    }
}
