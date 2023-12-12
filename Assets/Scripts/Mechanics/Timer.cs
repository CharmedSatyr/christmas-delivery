using UnityEngine;

namespace Platformer.Mechanics
{
    public class Timer : MonoBehaviour
    {
        private static readonly float startingSeconds = 60f;
        public static float SecondsRemaining { get; set; }

        public float almostUpTime = 10f;  // Time (in seconds) when the almost-up sound should play
        public AudioClip almostUpSound;   // Sound to play when time is almost up
        public AudioClip timeUpSound;      // Sound to play when time is up

        private AudioSource audioSource;
        private static bool almostUpSoundPlayed = false;
        private static bool timeUpSoundPlayed = false;

        public static float raceCountDown = 3;

        void Start()
        {
            SecondsRemaining = startingSeconds;
            audioSource = GetComponent<AudioSource>();
        }

        public static void AddTime(float seconds = 1.0f)
        {
            SecondsRemaining += seconds;
        }

        void Update()
        {
            CountDownToStart();

            if (!GameController.DidGameStart())
            {
                return;
            }

            UpdateRaceTimer();
        }

        private void UpdateRaceTimer()
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

        public static void Reset()
        {
            SecondsRemaining = startingSeconds;
            almostUpSoundPlayed = false;
            timeUpSoundPlayed = false;
            raceCountDown = 3;
        }

        private static void CountDownToStart()
        {
            if (raceCountDown > -1)
            {
                Debug.Log(Time.deltaTime);
                raceCountDown -= Time.deltaTime;
            }
        }
    }
}
