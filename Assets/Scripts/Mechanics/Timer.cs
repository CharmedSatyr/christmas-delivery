using UnityEngine;

namespace Platformer.Mechanics
{

    public class Timer : MonoBehaviour
    {
        public static float SecondsRemaining { get;  set; } = 90f;

        public void AddTime()
        {
            SecondsRemaining += 1.0f;
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
                ScoreController.HandleGameOver();
            }
        }
    }
}
