using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton; // �����Ϳ��� �Ҵ��� ��ư ����

    void Start()
    {
        quitButton.onClick.AddListener(QuitPlayGame); // ��ư�� ������ �߰�
    }

    void QuitPlayGame()
    {
        Application.Quit(); // ���� ����
    }
}
