using System;
using TMPro;
using UnityEngine;

public class Date : MonoBehaviour
{
    public TextMeshPro largeText;

    void Start()
    {
        // 确保 largeText 已经在 Unity 编辑器中关联了 TextMeshPro 组件
        if (largeText == null)
        {
            Debug.LogError("Please assign a TextMeshPro component to largeText in the inspector.");
        }

        // 初始化时间显示
        UpdateTimeDisplay();
    }

    void Update()
    {
        // 每帧更新时间
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        // 获取当前本地时间
        DateTime currentTime = DateTime.Now;

        // 获取星期几（完整的星期几名称）
        string dayOfWeek = currentTime.ToString("dddd");

        // 获取格式化的日期字符串，包括星期几
        string formattedDate = currentTime.ToString("dd-MM-yyyy   hh:mm tt");

        // 在 TextMeshPro 中显示日期和星期几
        if (largeText != null)
        {
            largeText.text = $"{dayOfWeek}\n{formattedDate}";
        }
    }
}