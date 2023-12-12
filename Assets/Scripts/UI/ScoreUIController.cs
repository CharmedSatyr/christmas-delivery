using Platformer.Mechanics;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        private TextMeshProUGUI score;
        private TextMeshProUGUI highScore;

        private void Start()
        {
            score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            highScore = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        }

        void LateUpdate()
        {
            if (!score || !highScore)
            {
                return;
            }

            score.SetText($"Score: {ScoreController.Score}");
            highScore.SetText($"High Score: {ScoreController.HighScore}");
        }
    }
}