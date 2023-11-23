using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    public float forceAmount = 10f; // �з����� ���� ũ�⸦ �����մϴ�.

    void OnCollisionEnter(Collision collision)
    {
        // �Ѿ˰��� �浹�� �����մϴ�.
        if (collision.gameObject.tag == "Bullet") // 'Bullet'�� �Ѿ��� �±��Դϴ�.
        {
            Vector3 hitDirection = collision.contacts[0].point - transform.position; // �浹 ������ ���� ��ġ ���̸� ����մϴ�.
            hitDirection = -hitDirection.normalized; // �ݴ� �������� ����ȭ�մϴ�.

            GetComponent<Rigidbody>().AddForce(hitDirection * forceAmount, ForceMode.Impulse); // ���� �߰��մϴ�.
        }
    }
}
