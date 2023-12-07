using Platformer.Mechanics;
using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        private TextMeshProUGUI displayScore;

        private void Start()
        {
            displayScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
        void LateUpdate()
        {
            if (!displayScore)
            {
                return;
            }

            displayScore.SetText($"Score: {ScoreController.Score}");
        }
    }
}