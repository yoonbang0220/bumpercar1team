using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryChecker : MonoBehaviour
{
    public Image[] images; // ���� �� ��� �̹��� �迭
    public Image victoryImage; // �¸� �̹���
    public Button replayButton; // �ٽ� ���� ��ư

    void Start()
    {
        victoryImage.enabled = false; // ���� �� �¸� �̹��� �����
        replayButton.gameObject.SetActive(false); // ���� �� ���÷��� ��ư �����
    }

    void Update()
    {
        CheckVictoryCondition();
    }

    void CheckVictoryCondition()
    {
        foreach (Image img in images)
        {
            if (img.enabled) // Ȱ��ȭ�� �̹����� �ϳ��� �ִٸ�
            {
                return; // �Լ��� �����մϴ�
            }
        }

        // ��� �̹����� ��Ȱ��ȭ�Ǿ��ٸ�
        victoryImage.enabled = true; // �¸� �̹��� Ȱ��ȭ
        replayButton.gameObject.SetActive(true); // ���÷��� ��ư Ȱ��ȭ
    }
}
