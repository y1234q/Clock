using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject second;
    public GameObject minute;
    public GameObject hour;
    string oldSeconds;

    void Update()
    {
        string seconds=System.DateTime.UtcNow.ToString("ss");
        print(seconds);

        if(seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }

    void UpdateTimer()
    {
       int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
    int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
    int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
    print(hoursInt + ":" + minutesInt + ":" + secondsInt);

    // 更新秒针
    iTween.RotateTo(second, iTween.Hash("z", secondsInt * 6 * -1, "time", 1, "easetype", "easeOutQuint"));

    // 更新分针
    float minuteDistance = (float)(secondsInt) / 60f; // 将秒数转换为分钟的偏移
    iTween.RotateTo(minute, iTween.Hash("z", (minutesInt + minuteDistance) * 6 * -1, "time", 1, "easetype", "easeOutQuint"));

    // 更新时针
    float hourDistance = (float)(minutesInt) / 60f; // 将分钟数转换为小时的偏移
    iTween.RotateTo(hour, iTween.Hash("z", (hoursInt + hourDistance) * 360 / 12 * -1, "time", 1, "easetype", "easeOutQuint"));
}
}
