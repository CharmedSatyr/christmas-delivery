using Platformer.Mechanics;
using System;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class GameOverUIController : MonoBehaviour
    {
        private TextMeshProUGUI displayGameOver;

        private void Start()
        {
            displayGameOver = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (!displayGameOver)
            {
                return;
            }

            if (!GameController.IsGameOver())
            {
                return;
            }

            if (DeliveryController.AllDeliveriesComplete || GameController.PlayerEnteredVictoryZone)
            {
                SetPlayerVictoryText();
                return;

            }

            SetPlayerLostText();
        }

        private void SetPlayerVictoryText()
        {
            int finalScore = ScoreController.Score + ScoreController.CalculateTimeBonus() - ScoreController.CalculatePenalty();
            finalScore = finalScore > 0 ? finalScore : 0;

            displayGameOver.SetText(
                    String.Join(Environment.NewLine,
                    "Level Complete!",
                    $"Gifts Delivered: {DeliveryController.GetCompletedDeliveriesCount()}",
                    $"Deliveries Missed: {DeliveryController.GetIncompleteDeliveriesCount()}",
                    "",
                    $"Score: {ScoreController.Score}",
                    $"Penalty: {-1 * ScoreController.CalculatePenalty()}",
                    $"Time Bonus: {ScoreController.CalculateTimeBonus()}",
                    $"Final: {finalScore}")
                );
        }

        private void SetPlayerLostText()
        {
            int finalScore = ScoreController.Score - ScoreController.CalculatePenalty();
            finalScore = finalScore > 0 ? finalScore : 0;

            displayGameOver.SetText(
                String.Join(Environment.NewLine,
                "Out of time!",
                $"Gifts Delivered: {DeliveryController.GetCompletedDeliveriesCount()}",
                $"Deliveries Missed: {DeliveryController.GetIncompleteDeliveriesCount()}",
                "",
                $"Score: {ScoreController.Score}",
                $"Penalty: {-1 * ScoreController.CalculatePenalty()}",
                $"Final: {finalScore}")
            );
        }
    }
}