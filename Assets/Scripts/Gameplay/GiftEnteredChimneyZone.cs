using Platformer.Core;
using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Gift collides with a ChimneyZone.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class GiftEnteredChimneyZone : Simulation.Event<GiftEnteredChimneyZone>
    {
        public DeliveryInstance gift;
        public GameObject completedIndicator;

        private readonly int giftPointValue = 10;
        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(gift.deliveryAudio, 0.9f * Camera.main.transform.position + 0.1f * gift.transform.position);

            ScoreController.Increment(giftPointValue);
            ScoreUIController.UpdateScore();

            gift.gameObject.SetActive(false);
            completedIndicator.SetActive(true);
        }
    }
}