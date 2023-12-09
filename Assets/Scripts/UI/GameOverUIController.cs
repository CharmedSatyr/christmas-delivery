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
                "Level Complete!",
                //$"Score: {ScoreController.Score - ScoreController.CalculateTimeBonus()}",
                $"Score: {ScoreController.Score}",
                $"Time Bonus: {ScoreController.CalculateTimeBonus()}",
                //$"Final: {ScoreController.Score}")
                $"Final: {ScoreController.Score + ScoreController.CalculateTimeBonus()}")
            );
        }

        private void SetPlayerLostText()
        {

            int baseScore = ScoreController.Score + ScoreController.CalculatePenalty();
            if (baseScore == ScoreController.CalculatePenalty())
            {
                baseScore = 0;
            }

            displayGameOver.SetText(
                String.Join(Environment.NewLine,
                "Out of time!",
                $"Score: {baseScore}",
                $"Penalty: -{ScoreController.CalculatePenalty()}",
                $"Final: {ScoreController.Score}")
            );
        }
    }
}