using Platformer.Mechanics;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class TimerUIController : MonoBehaviour
    {
        private TextMeshProUGUI displayTimer;

        // Start is called before the first frame update
        void Start()
        {
            // Find the TextMeshProUGUI component named "Timer" in the scene
            displayTimer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the displayTimer is null (not found in the scene)
            if (!displayTimer)
            {
                return;
            }

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
    }
}
