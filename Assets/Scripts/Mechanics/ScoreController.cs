using UnityEngine;

namespace Platformer.Mechanics
{
    public class ScoreController : MonoBehaviour
    {
        public static int Score { get; private set; } = 0;

        public static readonly int DeliveryPointValue = 50;
        private static readonly int PenaltyPerIncompleteDelivery = 100;
        public static readonly int TokenPointValue = 10;
        private static readonly int BonusPerSecond = 1;

        public static void Modify(int value)
        {
            Score += value;
        }

        public static void Reset()
        {
            Score = 0;
        }

        public static int CalculateTimeBonus()
        {
            if (Timer.SecondsRemaining > 0)
            {
                return Mathf.RoundToInt(Mathf.Floor(Timer.SecondsRemaining * BonusPerSecond));
            }

            return 0;
        }

        public static int CalculatePenalty()
        {
            return DeliveryController.GetIncompleteDeliveriesCount() * PenaltyPerIncompleteDelivery;
        }
    }
}