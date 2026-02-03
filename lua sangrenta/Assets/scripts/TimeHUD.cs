using UnityEngine;
using TMPro;

public class TimeHUD : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private TimeManager timeManager;

    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        if (timeManager == null) return;

        float t = timeManager.levelTime;

        int minutes = Mathf.FloorToInt(t / 60);
        int seconds = Mathf.FloorToInt(t % 60);

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
