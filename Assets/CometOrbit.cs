using UnityEngine;

public class CometOrbit : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.316f, 0f, 0f);
    public float gravity = 0.2f;

    void Update()
    {
        Vector3 position = transform.position;

        Vector3 planetPosition = new Vector3(0f, 6.12f, 0f);

        Vector3 direction = planetPosition - position;

        float distance = direction.magnitude;

        Vector3 acceleration = gravity * direction / Mathf.Pow(distance, 3);

        velocity += acceleration * Time.deltaTime;

        position += velocity * Time.deltaTime;

        transform.position = position;
    }
}