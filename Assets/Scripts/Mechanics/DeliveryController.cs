using System.Linq;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DeliveryController : MonoBehaviour
    {
        private ChimneyZone[] chimneys = { };
        private int chimneyCount = 0;

        // Win condition
        public static bool AllDeliveriesComplete { get; private set; } = false;

        void Awake()
        {
            if (chimneys.Length == 0)
            {
                FindAllChimneysInScene();
            }
        }

        void LateUpdate()
        {
            AllDeliveriesComplete = AreAllDeliveriesComplete();
        }

        [ContextMenu("Find All Chimneys")]
        private void FindAllChimneysInScene()
        {
            chimneys = FindObjectsOfType<ChimneyZone>();
            chimneyCount = chimneys.Length;
        }

        private int GetActiveChimneyCount()
        {
            return chimneys.Where(c => c.isActive).Count();
        }

        private bool AreAllDeliveriesComplete()
        {
            if (chimneyCount == 0)
            {
                Debug.Log("No chimneys detected.");
                return true;
            }

            return GetActiveChimneyCount() == 0;
        }
    }
}
