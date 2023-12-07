using UnityEngine;

namespace Platformer.Mechanics
{
    public class ScoreController : MonoBehaviour
    {
        public static int Score { get; private set; } = 0;

        private static readonly int BonusPerSecond = 1;
        private static readonly int PenaltyPerIncompleteDelivery = 1;

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

        public static void HandleGameOver()
        {
            if (DeliveryController.AllDeliveriesComplete)
            {
                Modify(CalculateTimeBonus());
                return;
            }

            int penalty = -1 * CalculatePenalty();
            Debug.Log("penalty " + penalty);
            Modify(penalty);
        }
    }
}