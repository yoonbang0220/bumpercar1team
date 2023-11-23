using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRandom : MonoBehaviour
{
    public GameObject[] transformObjects; // ��ȯ�� ���� ������Ʈ �迭

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ��
        if (collision.gameObject.tag == "Play")
        {
            TransformPlayer(collision.gameObject);
        }
    }

    void TransformPlayer(GameObject player)
    {
        int index = Random.Range(0, transformObjects.Length); // ���� �ε��� ����
        GameObject selectedObject = Instantiate(transformObjects[index], player.transform.position, player.transform.rotation); // ���õ� ������Ʈ �ν��Ͻ�ȭ
    }
}
