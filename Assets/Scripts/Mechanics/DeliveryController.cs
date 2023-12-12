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

        // Sounds for deliveries
        public AudioClip correctDeliverySound; // Sound for correct delivery
        public AudioClip wrongDeliverySound;   // Sound for wrong delivery

        private AudioSource audioSource;

        void Awake()
        {
            // Get the AudioSource component attached to this GameObject
            audioSource = GetComponent<AudioSource>();

            if (chimneys.Length == 0)
            {
                FindAllChimneysInScene();
            }
        }

        void Update()
        {
            // Update the win condition based on delivery status
            AllDeliveriesComplete = AreAllDeliveriesComplete();
        }

        [ContextMenu("Find All Chimneys")]
        private void FindAllChimneysInScene()
        {
            // Find all ChimneyZone objects in the scene and store them in the chimneys array
            chimneys = FindObjectsOfType<ChimneyZone>();
            chimneyCount = chimneys.Length;
        }

        private static int GetActiveChimneyCount()
        {
            // Count the number of active chimneys (chimneys with IsActive property set to true)
            return chimneys.Where(c => c.IsActive).Count();
        }

        private bool AreAllDeliveriesComplete()
        {
            if (chimneyCount == 0)
            {
                // Log a message if no chimneys are detected
                Debug.Log("No chimneys detected.");
                return true;
            }

            int activeChimneys = GetActiveChimneyCount();

            // Play sound for correct or wrong delivery based on the delivery status
            if (activeChimneys == 0 && correctDeliverySound != null)
            {
                audioSource.PlayOneShot(correctDeliverySound);
            }
            else if (activeChimneys > 0 && wrongDeliverySound != null)
            {
                audioSource.PlayOneShot(wrongDeliverySound);
            }

            // Return true if all deliveries are complete, false otherwise
            return activeChimneys == 0;
        }

        public static int GetIncompleteDeliveriesCount()
        {
            // Get the count of active chimneys (incomplete deliveries)
            return GetActiveChimneyCount();
        }

        public static int GetCompletedDeliveriesCount()
        {
            // Calculate the count of completed deliveries
            return chimneyCount - GetIncompleteDeliveriesCount();
        }
    }
}
