using UnityEngine;

namespace Platformer.Mechanics
{
    public class Timer : MonoBehaviour
    {
        public static float SecondsRemaining { get; set; } = 60f;

        public float almostUpTime = 10f;  // Time (in seconds) when the almost-up sound should play
        public AudioClip almostUpSound;   // Sound to play when time is almost up
        public AudioClip timeUpSound;      // Sound to play when time is up

        private AudioSource audioSource;
        private bool almostUpSoundPlayed = false;
        private bool timeUpSoundPlayed = false;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

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

                // Check if it's time to play the almost-up sound
                if (SecondsRemaining <= almostUpTime && almostUpSound != null && !almostUpSoundPlayed)
                {
                    audioSource.PlayOneShot(almostUpSound);
                    almostUpSoundPlayed = true;
                }
            }
            else
            {
                // Sets lose conditions and play time up sound
                SecondsRemaining = 0;

                if (timeUpSound != null && !timeUpSoundPlayed)
                {
                    audioSource.PlayOneShot(timeUpSound);
                    timeUpSoundPlayed = true;
                }
            }
        }
    }
}
