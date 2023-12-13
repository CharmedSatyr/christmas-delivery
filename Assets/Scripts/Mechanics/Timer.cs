using System.Collections;
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

        public AudioClip countdownJingle;
        public static float RaceCountDown { get; private set; } = 3;
        public static bool Counting = false;

        private void Awake()
        {
            SecondsRemaining = startingSeconds;
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            CountDownToStart();
        }

        public static void AddTime(float seconds = 1.0f)
        {
            SecondsRemaining += seconds;
        }

        void Update()
        {
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
            RaceCountDown = 3;
        }

        private IEnumerator Countdown()
        {
            Counting = true;

            while (RaceCountDown >= -2)
            {
                if (RaceCountDown >= 0)
                {
                    audioSource.PlayOneShot(countdownJingle);
                }

                yield return new WaitForSeconds(1);

                RaceCountDown--;
            }

            Counting = false;
        }

        private IEnumerator WaitThenCountdown(int seconds)
        {
            yield return new WaitForSeconds(seconds);

            StartCoroutine(Countdown());
        }

        private void CountDownToStart()
        {
            StartCoroutine(WaitThenCountdown(2));
        }
    }
}
