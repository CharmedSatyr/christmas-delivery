using UnityEngine;

public class Sun : MonoBehaviour
{
    public float sunRiseSpeed = 0.0001f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, sunRiseSpeed, 0);
    }
}
