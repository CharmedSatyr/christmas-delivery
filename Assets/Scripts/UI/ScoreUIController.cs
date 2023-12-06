using TMPro;
using UnityEngine;

namespace Platformer.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        private void Update()
        {
            if (GameObject.Find("Score").TryGetComponent(out TextMeshProUGUI displayScore))
            {
                displayScore.SetText($"Score: {ScoreController.Score}");
            }
        }
    }
}