using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : MonoBehaviour
{
    // GameObject ����Ʈ�� �����մϴ�.
    public List<GameObject> gameObjects;

    void Start()
    {
        // Cube�� �ε����� ã���ϴ�.
        int cubeIndex = FindIndexOfCube();
        if (cubeIndex != -1)
        {
            Debug.Log("Cube�� �ε���: " + cubeIndex);
        }
        else
        {
            Debug.Log("Cube�� ã�� �� �����ϴ�.");
        }
    }

    // Cube�� �ε����� ã�� �Լ��Դϴ�.
    int FindIndexOfCube()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i].name == "Cube")
            {
                return i; // Cube�� �ε����� ��ȯ�մϴ�.
            }
        }
        return -1; // Cube�� ã�� ���� ��� -1�� ��ȯ�մϴ�.
    }
}
