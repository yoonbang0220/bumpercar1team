using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Number : MonoBehaviour
{
    public Image[] images; // Ȯ���� Image ������Ʈ��
    public TextMeshProUGUI countText; // ���ڸ� ǥ���� TextMeshProUGUI

    void Update()
    {
        UpdateImageCount();
    }

    void UpdateImageCount()
    {
        int activeImageCount = 0; // Ȱ��ȭ�� �̹����� ��
        foreach (var image in images)
        {
            if (image.enabled)
            {
                activeImageCount++;
            }
        }

        countText.text = activeImageCount.ToString(); // TextMeshPro �ؽ�Ʈ ������Ʈ
    }
}
