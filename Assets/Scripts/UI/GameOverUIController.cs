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
            displayGameOver.SetText(
                String.Join(Environment.NewLine,
                "Level Complete!",
                $"Score: {ScoreController.Score}",
                $"Penalty: {-1 * ScoreController.CalculatePenalty()}",
                $"Time Bonus: {ScoreController.CalculateTimeBonus()}",
                $"Final: {ScoreController.Score + ScoreController.CalculateTimeBonus() - ScoreController.CalculatePenalty()}")
            );
        }

        private void SetPlayerLostText()
        {
            displayGameOver.SetText(
                String.Join(Environment.NewLine,
                "Out of time!",
                $"Score: {ScoreController.Score}",
                $"Penalty: {-1 * ScoreController.CalculatePenalty()}",
                $"Final: {ScoreController.Score - ScoreController.CalculatePenalty()}")
            );
        }
    }
}