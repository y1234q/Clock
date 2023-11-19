using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

[Serializable]
public class WeatherData
{
    public WeatherInfo[] weather;
    public MainInfo main;
}

[Serializable]
public class WeatherInfo
{
    public string main; // 天气状态，例如 "Clouds"
}

[Serializable]
public class MainInfo
{
    public float temp; // 温度（单位：开尔文）
}

public class WeatherDisplay : MonoBehaviour
{
    public TextMeshPro weatherText;
    public string weatherApiKey = "9f4850bba4738578eb63354bedb44bcb"; // 替换为你的 OpenWeatherMap API 密钥
    private string initialText;

    void Awake()
    {
        // 保存初始文本
        initialText = weatherText.text;
    }

    void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    IEnumerator GetWeatherData()
    {
        // 替换为你的天气 API 请求地址和参数
        string weatherApiUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Hualien&appid={weatherApiKey}";

        using (UnityWebRequest request = UnityWebRequest.Get(weatherApiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                // 解析 JSON 数据，显示天气信息
                string jsonResult = request.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(jsonResult);

                // 在 TextMeshPro 中显示天气信息
                if (weatherText != null && weatherData != null)
                {
                    // 将开尔文温度转换为摄氏度并四舍五入为整数
                    int roundedTemp = Mathf.RoundToInt(weatherData.main.temp - 273.15f);
                    // 直接显示天气状况和整数温度
                    string weatherInfo = $"{weatherData.weather[0].main}\n{roundedTemp}°C";
                    weatherText.text = weatherInfo;
                }
            }
            else
            {
                Debug.LogError($"Failed to get weather data. Error: {request.error}");
            }
        }
    }
}
