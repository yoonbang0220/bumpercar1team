using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Play"))
        {

            // ������ �ڽ� ��Ȱ��ȭ �Ǵ� �ı�
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
