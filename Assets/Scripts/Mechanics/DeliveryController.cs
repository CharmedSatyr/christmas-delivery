using System.Linq;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DeliveryController : MonoBehaviour
    {
        private static ChimneyZone[] chimneys = { };
        private static int chimneyCount = 0;

        // Win condition
        public static bool AllDeliveriesComplete { get; private set; } = false;

        void Awake()
        {
            if (chimneys.Length == 0)
            {
                FindAllChimneysInScene();
            }
        }

        void Update()
        {
            AllDeliveriesComplete = AreAllDeliveriesComplete();
        }

        [ContextMenu("Find All Chimneys")]
        private void FindAllChimneysInScene()
        {
            chimneys = FindObjectsOfType<ChimneyZone>();
            chimneyCount = chimneys.Length;
        }

        private static int GetActiveChimneyCount()
        {
            return chimneys.Where(c => c.IsActive).Count();
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

        public static int GetIncompleteDeliveriesCount()
        {
            return GetActiveChimneyCount();
        }

        public static int GetCompletedDeliveriesCount()
        {
            return chimneyCount - GetIncompleteDeliveriesCount();
        }
    }
}
