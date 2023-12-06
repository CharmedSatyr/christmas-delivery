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
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (!collider.gameObject.TryGetComponent<GiftInstance>(out var gift))
            {
                return;
            }

            var ev = Schedule<GiftEnteredChimneyZone>();
            ev.gift = gift;
        }
    }
}