using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAssault : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float forceAmount = 10f;
    private Rigidbody rb;

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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            agent.isStopped = true; // NavMeshAgent�� �Ͻ� �����մϴ�.

            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = -hitDirection.normalized;

            rb.AddForce(hitDirection * forceAmount, ForceMode.Impulse);

            // ���� ������ �� 1�ʰ� ������ NavMeshAgent�� �ٽ� Ȱ��ȭ�մϴ�.
            StartCoroutine(EnableAgentAfterDelay(1f));
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
