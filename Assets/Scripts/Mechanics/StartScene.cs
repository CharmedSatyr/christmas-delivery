using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A utility class to load a scene.
    /// </summary>
    public class StartScene : MonoBehaviour
    {
        public string LevelName = "SnowyScene";

        public void LoadLevel()
        {
            SceneManager.LoadScene(LevelName);
        }
    }
}