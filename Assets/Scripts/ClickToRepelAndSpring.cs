using UnityEngine;

public class ClickToRepelAndSpring : MonoBehaviour
{
    public int gridSize = 10;
    public GameObject prefab;
    public float repelForce = 100.0f;
    public float springForce = 10.0f;
    public float springLength = 2.0f;

    private GameObject[,] cubes;

    private void Start()
    {
        // Initialize the cubes array
        cubes = new GameObject[gridSize, gridSize];

        // Instantiate the cubes and position them in a grid
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject cube = Instantiate(prefab, transform);
                cube.transform.position = new Vector3(x, 0.0f, y);
                cubes[x, y] = cube;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Calculate the repulsive force from the clicked object
                Vector2 hitPosition = new Vector2(hit.point.x, hit.point.z);
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        GameObject cube = cubes[x, y];
                        Vector2 direction = new Vector2(cube.transform.position.x, cube.transform.position.z) - hitPosition;
                        float distance = direction.magnitude;
                        if (distance < 1.0f)
                        {
                            distance = 1.0f;
                        }
                        float force = repelForce / (distance * distance);
                        Vector3 force2D = new Vector3(direction.normalized.x * force, 0.0f, direction.normalized.y * force);
                        cube.GetComponent<Rigidbody>().AddForce(force2D, ForceMode.Impulse);

                        // Apply spring force to all other cubes
                        for (int i = 0; i < gridSize; i++)
                        {
                            for (int j = 0; j < gridSize; j++)
                            {
                                if (i == x && j == y)
                                {
                                    continue;
                                }

                                GameObject otherCube = cubes[i, j];
                                Vector3 springDirection = otherCube.transform.position - cube.transform.position;
                                float springDistance = springDirection.magnitude;
                                if (springDistance > springLength)
                                {
                                    continue;
                                }
                                float springForceMagnitude = springForce * (springDistance - springLength);
                                Vector3 springForceVector = springDirection.normalized * springForceMagnitude;
                                cube.GetComponent<Rigidbody>().AddForce(springForceVector, ForceMode.Impulse);
                                otherCube.GetComponent<Rigidbody>().AddForce(-springForceVector, ForceMode.Impulse);
                            }
                        }
                    }
                }
            }
        }
    }
}
