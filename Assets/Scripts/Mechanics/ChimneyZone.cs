using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// ChimneyZone components mark a collider which will schedule a
    /// GiftEnteredChimneyZone event when a gift enters the trigger.
    /// </summary>
    public class ChimneyZone : MonoBehaviour
    {
        public GameObject completedIndicator;
        public bool IsActive { get; set; } = true;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (!collider.gameObject.TryGetComponent<DeliveryInstance>(out var gift))
            {
                return;
            }

            if (!completedIndicator)
            {
                Debug.Log("Missing a completed indicator...");
                return;
            }

            if (!IsActive)
            {
                return;
            }

            IsActive = false;

            GiftEnteredChimneyZone ev = Schedule<GiftEnteredChimneyZone>();
            ev.gift = gift;
            ev.completedIndicator = completedIndicator;

        }
    }
}