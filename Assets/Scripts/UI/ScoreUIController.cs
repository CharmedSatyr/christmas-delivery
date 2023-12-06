using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        public static void UpdateScore()
        {
            if (GameObject.Find("Score").TryGetComponent(out TextMeshProUGUI displayScore))
            {
                displayScore.SetText($"Score: {ScoreController.Score}");
            }
        }
    }
}