using Platformer.Core;
using Platformer.Model;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public static bool PlayerEnteredVictoryZone = false;

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }

        public static bool IsGameOver()
        {
            // Win
            if (DeliveryController.AllDeliveriesComplete || PlayerEnteredVictoryZone)
            {
                return true;
            }

            // Loss
            if (Timer.SecondsRemaining == 0)
            {
                return true;
            }

            return false;
        }

        public static void ResetGame()
        {
            ScoreController.Reset();
            Timer.Reset();
            GameOverUIController.Reset();
            PlayerEnteredVictoryZone = false;
            Instance.GetComponent<StartScene>().LoadLevel();
        }
    }
}