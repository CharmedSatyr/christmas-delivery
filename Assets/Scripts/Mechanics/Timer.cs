using UnityEngine;

namespace Platformer.Mechanics
{

    public class Timer : MonoBehaviour
    {
        public static float SecondsRemaining { get; set; } = 60f;

        public static void AddTime(float seconds = 1.0f)
        {
            SecondsRemaining += seconds;
        }

        void Update()
        {
            if (GameController.IsGameOver())
            {
                return;
            }

            if (SecondsRemaining > 1)
            {
                SecondsRemaining -= Time.deltaTime;
            }
            else
            {
                // Sets lose conditions
                SecondsRemaining = 0;
            }
        }
    }
}
