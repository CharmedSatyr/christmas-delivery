using Platformer.Mechanics;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class TimerUIController : MonoBehaviour
    {
        private TextMeshProUGUI displayTimer;

        private TextMeshProUGUI countdownTimer;

        // Start is called before the first frame update
        void Awake()
        {
            // Find the TextMeshProUGUI component named "Timer" in the scene
            displayTimer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();

            countdownTimer = GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!displayTimer || !countdownTimer)
            {
                Debug.Log("Stuck in here");
                return;
            }

            HandleCountdownTimer();

            // Change text color to red when Timer's SecondsRemaining is less than or equal to 10 seconds
            if (Timer.SecondsRemaining <= 10)
            {
                displayTimer.color = Color.red;
            }

            // Calculate minutes and seconds from the remaining time in Timer
            float minutes = Mathf.FloorToInt(Timer.SecondsRemaining / 60);
            float seconds = Mathf.FloorToInt(Timer.SecondsRemaining % 60);

            // Format the time as a string
            string formattedTime = string.Format("Time remaining: {0:00}:{1:00}", minutes, seconds);

            // Set the formatted time to the TextMeshProUGUI component
            displayTimer.SetText($"{formattedTime}");

        }

        private void HandleCountdownTimer()
        {
            countdownTimer.SetText("READY");

            if (!Timer.Counting)
            {
                return;
            }

            if (Timer.RaceCountDown > 0)
            {
                countdownTimer.SetText($"{Timer.RaceCountDown}");
            }
            else if (Timer.RaceCountDown >= -1)
            {
                countdownTimer.SetText("START");
            }
            else
            {
                countdownTimer.gameObject.SetActive(false);
            }
        }
    }
}
