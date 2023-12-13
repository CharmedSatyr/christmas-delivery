using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sky : MonoBehaviour
{
    public float targetGlobalLightIntensity = 1f;
    public float globalLightIntensityGainSpeed = 0.01f;

    Light2D globalLight;

    // Start is called before the first frame update
    void Awake()
    {
        globalLight = GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalLight == null)
        {
            Debug.Log("Global light not found.");
            return;
        }

        globalLight.intensity = Mathf.MoveTowards(globalLight.intensity, targetGlobalLightIntensity, globalLightIntensityGainSpeed * Time.deltaTime);
    }
}
