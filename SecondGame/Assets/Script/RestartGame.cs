using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�
using UnityEngine.SceneManagement; // SceneManagement ���ӽ����̽� �߰�

public class RestartGame : MonoBehaviour
{
    public Button restartButton; // �����Ϳ��� �Ҵ��� ��ư ����
    public GameObject[] HealItems; // ���� �迭
    public int NumberOfObjectsToActivate = 5; // Ȱ��ȭ�� ������Ʈ�� ��

    void Start()
    {
        restartButton.onClick.AddListener(RePlayGame); // ��ư�� ������ �߰�
        ActivateRandomObjects(); // ���� ������ġ
    }

    void ActivateRandomObjects()
    {
        // ��� ���� ������Ʈ�� ��Ȱ��ȭ
        foreach (var obj in HealItems)
        {
            obj.SetActive(false);
        }

        // �������� ������Ʈ�� Ȱ��ȭ�ϱ� ���� ����Ʈ ����
        List<GameObject> objectsToActivate = new List<GameObject>(HealItems);

        // 5���� ������Ʈ�� �������� Ȱ��ȭ
        for (int i = 0; i < NumberOfObjectsToActivate; i++)
        {
            if (objectsToActivate.Count > 0)
            {
                int randomIndex = Random.Range(0, objectsToActivate.Count);
                objectsToActivate[randomIndex].SetActive(true);
                objectsToActivate.RemoveAt(randomIndex); // �ߺ� ������ ���� ����Ʈ���� ����
            }
        }
    }

    void RePlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ���� �� ��ε�
    }
}
