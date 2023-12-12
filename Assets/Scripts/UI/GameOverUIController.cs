using Platformer.Mechanics;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class GameOverUIController : MonoBehaviour
    {
        private bool gameOverUIEnabled = false;

        private TextMeshProUGUI gameOverUI;
        private Button retryButton;

        void Awake()
        {
            gameOverUI = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
            retryButton = gameOverUI.GetComponentInChildren<Button>();

            retryButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!gameOverUI)
            {
                return;
            }

            if (!GameController.IsGameOver())
            {
                return;
            }

            if (gameOverUIEnabled)
            {
                return;
            }

            gameOverUIEnabled = true;

            EnablePlayAgainButton();

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

            gameOverUI.SetText(
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

            gameOverUI.SetText(
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

        private void EnablePlayAgainButton()
        {
            retryButton.gameObject.SetActive(true);
        }
    }
}