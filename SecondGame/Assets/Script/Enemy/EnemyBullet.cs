using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public string targetTag = "Play"; // �� �±׸� ���� ������Ʈ�� �浹 �� �ı��˴ϴ�.

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // �Ѿ� �ڽ��� �ı�
    }
}
