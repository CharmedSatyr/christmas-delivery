using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int Score { get; private set; } = 0;

    public static void Increment(int value)
    {
        Score += value;
    }

    public static void Reset()
    {
        Score = 0;
    }
}
