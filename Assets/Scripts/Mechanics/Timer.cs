using UnityEngine;

namespace Platformer.Mechanics
{

    public class Timer : MonoBehaviour
    {
        public static float SecondsRemaining { get; private set; } = 30f;

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
