using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    // Reference to the Light component
    private Light lightComponent;

    // Minimum and maximum intensity of the light
    public float minIntensity = 0f;
    public float maxIntensity = 1f;

    // Flicker speed
    public float flickerSpeed = 0.1f;

    // Time accumulator
    private float _timer;

    void Start()
    {
        // Get the Light component attached to this GameObject
        lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        // Accumulate time
        _timer += Time.deltaTime * flickerSpeed;

        // Set the light intensity to a random value between minIntensity and maxIntensity
        lightComponent.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(_timer, 0f));
    }
}