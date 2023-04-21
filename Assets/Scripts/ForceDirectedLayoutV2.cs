using UnityEngine;
using System;
using System.Collections;

public class ForceDirectedLayoutV2 : MonoBehaviour
{
    public GameObject prefab;
    public int numObjects = 100;
    public float springForce = 0.1f;
    public float repulsionForce = 0.5f;
    public float damping = 0.1f;
    public float maxVelocity = 10.0f;

    private GameObject[] objects;
    private Vector3[] velocities;

    private void Start()
    {
        // Instantiate the prefabs
        objects = new GameObject[numObjects];
        for (int i = 0; i < numObjects; i++)
        {
            objects[i] = Instantiate(prefab, UnityEngine.Random.insideUnitSphere * 10.0f, Quaternion.identity);
        }

        // Initialize the velocities
        velocities = new Vector3[numObjects];

        // Start the force-directed layout simulation
        StartCoroutine(Simulate());
    }

    private IEnumerator Simulate()
    {
        while (true)
        {
            // Calculate the forces
            Vector3[] forces = new Vector3[numObjects];
            for (int i = 0; i < numObjects; i++)
            {
                for (int j = i + 1; j < numObjects; j++)
                {
                    Vector3 direction = objects[j].transform.position - objects[i].transform.position;
                    float distance = direction.magnitude;
                    direction.Normalize();
                    forces[i] -= direction * repulsionForce / (distance * distance);
                    forces[j] += direction * repulsionForce / (distance * distance);
                }
            }
            for (int i = 0; i < numObjects; i++)
            {
                forces[i] -= velocities[i] * damping;
            }
            for (int i = 0; i < numObjects; i++)
            {
                for (int j = i + 1; j < numObjects; j++)
                {
                    Vector3 direction = objects[j].transform.position - objects[i].transform.position;
                    float distance = direction.magnitude;
                    direction.Normalize();
                    float springLength = 2.0f;
                    float springForceMagnitude = springForce * (distance - springLength);
                    forces[i] += direction * springForceMagnitude;
                    forces[j] -= direction * springForceMagnitude;
                }
            }

            // Update the velocities and positions
            for (int i = 0; i < numObjects; i++)
            {
                velocities[i] += forces[i] * Time.deltaTime;
                velocities[i] = Vector3.ClampMagnitude(velocities[i], maxVelocity);
                objects[i].transform.position += velocities[i] * Time.deltaTime;
            }

            yield return null;
        }
    }
}
