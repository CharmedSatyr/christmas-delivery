using Platformer.Core;
using Platformer.Mechanics;
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

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(gift.deliveryAudio, gift.transform.position);

            ScoreController.Modify(ScoreController.DeliveryPointValue);
            Timer.AddTime(2f);

            gift.gameObject.SetActive(false);
            completedIndicator.SetActive(true);
        }
    }
}