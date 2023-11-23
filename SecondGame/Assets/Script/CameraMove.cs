using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public List<Transform> targets; // ī�޶� ���� ������ ���
    public Vector3 offset; // ���� ī�޶� ������ ������
    private int currentIndex = 0; // ���� ���� ���� ����� �ε���

    void LateUpdate()
    {
        if (targets.Count == 0) return; // ����� ������ �ƹ��͵� ���� ����

        // ���� �ε����� ����� ����ִ��� Ȯ��
        Transform currentTarget = targets[currentIndex];
        if (currentTarget != null && currentTarget.gameObject.activeSelf)
        {
            // ��������� ����
            transform.position = currentTarget.position + offset;
            transform.LookAt(currentTarget);
        }
        // �߰����� �������� �ε��� ���� ���� (��: Ű �Է¿� ���� ����)
    }

    // �ε����� �����ϴ� �޼��� (��: ���� ������� �̵�)
    public void NextTarget()
    {
        if (targets.Count > 0)
        {
            currentIndex = (currentIndex + 1) % targets.Count;
        }
    }
}
