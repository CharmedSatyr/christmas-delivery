using TMPro;
using UnityEngine;

public class TimerUIController : MonoBehaviour
{
    private TextMeshProUGUI displayTimer;

    // Start is called before the first frame update
    void Start()
    {
        displayTimer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!displayTimer)
        {
            return;
        }

        if (TimerController.secondsRemaining <= 10)
        {
            displayTimer.color = Color.red;
        }

        float minutes = Mathf.FloorToInt(TimerController.secondsRemaining / 60);
        float seconds = Mathf.FloorToInt(TimerController.secondsRemaining % 60);

        string formattedTime = string.Format("Time remaining: {0:00}:{1:00}", minutes, seconds);

        displayTimer.SetText($"{formattedTime}");
    }
}