using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAaD : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float forceAmount = 2f;
    private Rigidbody rb;
    private int hitCount = 0; // �浹 Ƚ���� �����ϴ� �����Դϴ�.
    public Image[] hitImages; //HP
    public Canvas canvas; //HP Canvas

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (target != null && !agent.isStopped)
        {
            agent.SetDestination(target.position);
        }

        // ĵ������ �׻� Y������ 0�� ȸ���ǵ��� ����
        if (canvas != null)
        {
            canvas.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���� �°ų� �÷��̾�� �浹�ϸ� HP ����
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Play")
        {
            hitCount++; // �浹 Ƚ���� ������ŵ�ϴ�.

            if (hitCount - 1 < hitImages.Length) // �ε��� ���� Ȯ��
            {
                hitImages[hitImages.Length - hitCount].enabled = false; // �ش� HP �̹����� ����ϴ�.
            }

            if (hitCount >= 5) // 5�� �̻� �浹�ߴ��� Ȯ���մϴ�.
            {
                Destroy(gameObject); // ������Ʈ�� �ı��մϴ�.
            }
            else
            {
                agent.isStopped = true; // NavMeshAgent�� �Ͻ� �����մϴ�.

                Vector3 hitDirection = collision.contacts[0].point - transform.position;
                hitDirection = -hitDirection.normalized;

                rb.AddForce(hitDirection * forceAmount, ForceMode.Impulse);

                // ���� ������ �� 1�ʰ� ������ NavMeshAgent�� �ٽ� Ȱ��ȭ�մϴ�.
                StartCoroutine(EnableAgentAfterDelay(1f));
            }
        }
    }

    IEnumerator EnableAgentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 1�� ���� ���

        // 1�� �� ����� �ڵ�
        rb.velocity = Vector3.zero; // Rigidbody�� �ӵ��� 0���� �����Ͽ� ����ϴ�.
        agent.isStopped = false; // NavMeshAgent�� �ٽ� Ȱ��ȭ�Ͽ� ��ǥ ������ ����մϴ�.
    }
}
