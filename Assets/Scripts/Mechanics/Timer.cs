using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float SecondsRemaining { get; private set; } = 30f;

    void Update()
    {
        if (SecondsRemaining > 1)
        {
            SecondsRemaining -= Time.deltaTime;
        }
        else
        {
            SecondsRemaining = 0;
        }
    }
}
