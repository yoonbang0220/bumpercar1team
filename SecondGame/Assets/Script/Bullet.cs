using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag = "Enemy"; // �� �±׸� ���� ������Ʈ�� �浹 �� �ı��˴ϴ�.

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // �Ѿ� �ڽ��� �ı�
    }
}
