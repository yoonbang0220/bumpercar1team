using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    // �����ڽ��� �浹 �� �÷��̾� ��ȯ
    public GameObject aObject; // ��
    public GameObject bObject; // ����
    public GameObject cObject; // �ӽŰ�
    public GameObject dObject; // ����

    void OnCollisionEnter(Collision collision)
    {
        // �±װ� "Gun"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        if (collision.gameObject.tag == "Gun")
        {
            SwitchToObject(aObject);
            Destroy(collision.gameObject); // �浹�� "Gun" �±� ������Ʈ �ı�
            Destroy(gameObject); // �� ������Ʈ �ı�
        }
        // �±װ� "ShotGun"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        else if (collision.gameObject.tag == "ShotGun")
        {
            SwitchToObject(bObject);
            Destroy(collision.gameObject); // �浹�� "ShotGun" �±� ������Ʈ �ı�
            Destroy(gameObject);
        }
        // �±װ� "MachineGun"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        else if (collision.gameObject.tag == "MachineGun")
        {
            SwitchToObject(cObject);
            Destroy(collision.gameObject); // �浹�� "MachineGun" �±� ������Ʈ �ı�
            Destroy(gameObject);
        }
        // �±װ� "Bumper"�� ������Ʈ�� �浹�ߴ��� Ȯ��
        else if (collision.gameObject.tag == "Bumper")
        {
            SwitchToObject(dObject);
            Destroy(collision.gameObject); // �浹�� "Bumper" �±� ������Ʈ �ı�
            Destroy(gameObject);
        }
    }

    void SwitchToObject(GameObject newObject)
    {
        aObject.SetActive(false); // aObject ��Ȱ��ȭ
        newObject.SetActive(true); // ��ȯ�� ������Ʈ Ȱ��ȭ
    }
}
