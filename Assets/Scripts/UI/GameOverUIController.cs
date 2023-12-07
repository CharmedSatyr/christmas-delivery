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

            if (DeliveryController.AllDeliveriesComplete)
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
                "Merry Christmas!",
                "You Win!",
                $"Final Score: {ScoreController.Score}")
            );
        }

        private void SetPlayerLostText()
        {
            displayGameOver.SetText(
                String.Join(Environment.NewLine,
                "Game Over.",
                "Out of time!",
                $"Final Score: {ScoreController.Score}")
            );
        }
    }
}