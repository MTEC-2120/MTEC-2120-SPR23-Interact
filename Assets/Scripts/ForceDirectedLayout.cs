using UnityEngine;

public class ForceDirectedLayout : MonoBehaviour
{
    public GameObject prefab;
    public float k = 100f;  // Repulsion force coefficient
    public float c = 0.1f;  // Spring force coefficient
    public float maxVelocity = 10f;

    private GameObject[] nodes;
    private Vector3[] velocities;

    private void Start()
    {
        // Instantiate 100 nodes
        nodes = new GameObject[100];
        velocities = new Vector3[100];

        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = Instantiate(prefab, Random.insideUnitCircle * 10f, Quaternion.identity);
            velocities[i] = Random.insideUnitSphere * 2f;
        }
    }

    private void Update()
    {
        // Apply forces to each node
        for (int i = 0; i < nodes.Length; i++)
        {
            Vector3 force = Vector3.zero;

            // Apply repulsion force from all other nodes
            for (int j = 0; j < nodes.Length; j++)
            {
                if (i != j)
                {
                    Vector3 direction = nodes[j].transform.position - nodes[i].transform.position;
                    float distance = direction.magnitude;
                    force -= direction.normalized * k / (distance * distance);
                }
            }

            // Apply spring force to adjacent nodes
            if (i > 0)
            {
                Vector3 direction = nodes[i - 1].transform.position - nodes[i].transform.position;
                float distance = direction.magnitude;
                force += direction.normalized * c * (distance - 2f);
            }
            if (i < nodes.Length - 1)
            {
                Vector3 direction = nodes[i + 1].transform.position - nodes[i].transform.position;
                float distance = direction.magnitude;
                force += direction.normalized * c * (distance - 2f);
            }

            // Apply force to velocity
            velocities[i] += force * Time.deltaTime;

            // Limit velocity to max velocity
            velocities[i] = Vector3.ClampMagnitude(velocities[i], maxVelocity);

            // Update node position based on velocity
            nodes[i].transform.position += velocities[i] * Time.deltaTime;
        }
    }
}
