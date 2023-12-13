using Platformer.Mechanics;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class GameOverUIController : MonoBehaviour
    {
        private TextMeshProUGUI gameOverUI;
        private TextMeshProUGUI result;
        private TextMeshProUGUI details;
        private TextMeshProUGUI highScore;
        private Button retryButton;

        void Awake()
        {
            gameOverUI = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
            result = GameObject.Find("GameOver/Result").GetComponent<TextMeshProUGUI>();
            details = GameObject.Find("GameOver/Details").GetComponent<TextMeshProUGUI>();
            highScore = GameObject.Find("GameOver/Details/HighScoreStamp").GetComponent<TextMeshProUGUI>();
            retryButton = gameOverUI.GetComponentInChildren<Button>();
        }

        void Start()
        {
            result.SetText("");
            details.SetText("");
            highScore.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!gameOverUI || !retryButton || !result || !details || !highScore)
            {
                Debug.Log("Missing game over UI elements");
                return;
            }

            if (!GameController.IsGameOver())
            {
                return;
            }

            EnableGameOverUI();

            if (GameController.PlayerEnteredVictoryZone)
            {
                SetPlayerVictoryText();
                return;
            }

            SetPlayerLostText();
        }

        private void SetPlayerVictoryText()
        {
            result.SetText("Level Complete!");

            BuildDetails();
        }

        private void SetPlayerLostText()
        {
            result.SetText("Out of Time!");

            BuildDetails();
        }

        private void BuildDetails()
        {
            int finalScore = ScoreController.CalculateFinalScore();

            if (finalScore > ScoreController.HighScore)
            {
                highScore.gameObject.SetActive(true);
            }

            details.SetText(
                string.Join(Environment.NewLine,
                $"Gifts Delivered: {DeliveryController.GetCompletedDeliveriesCount()}",
                $"Deliveries Missed: {DeliveryController.GetIncompleteDeliveriesCount()}",
                string.Empty,
                $"Score: {ScoreController.Score}",
                $"Penalty: {-1 * ScoreController.CalculatePenalty()}",
                $"Time Bonus: {ScoreController.CalculateTimeBonus()}",
                $"Final: {finalScore}")
            );
        }

        private void EnableGameOverUI()
        {
            retryButton.gameObject.SetActive(true);
        }

        public void Reset()
        {
            result.SetText("");
            details.SetText("");
            highScore.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
        }
    }
}