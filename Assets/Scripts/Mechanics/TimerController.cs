using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static float secondsRemaining = 90f;

    void Update()
    {
        if (secondsRemaining > 1)
        {
            secondsRemaining -= Time.deltaTime;
        }
    }
}
