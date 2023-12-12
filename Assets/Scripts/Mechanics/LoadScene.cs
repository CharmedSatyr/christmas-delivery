using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A utility class to load a scene.
    /// </summary>
    public class LoadScene : MonoBehaviour
    {
        public string SceneName = "SnowyScene";

        public void Load()
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}